using System.ComponentModel;
using System.Reflection;
using System.Text.Encodings.Web;
using HaSe.Domain;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaSe.Pages.Controls {
    public class ShowTableProperties<TEntity>(dynamic? viewBag = null) {
        public IEnumerable<TEntity> Items { get; set; } = [];
        public string? SortOrder { get; set; } = viewBag?.SortOrder;
        public string? SearchString { get; set; } = viewBag?.SearchString;
        public int? PageNumber { get; set; } = viewBag?.PageNumber;
        public bool IsEditable { get; set; } = true;
        public string? Controller { get; set; }
        public string? MasterController { get; set; }
        public int? MasterId { get; set; }
        public IHtmlContent? Label { get; set; }
        public PropertyInfo[] Properties { get; set; } = [];
    }
    public static class HtmlShowTable {
        public static IHtmlContent ShowTable<TModel, TEntity>(this IHtmlHelper<TModel> h,
            ShowTableProperties<TEntity> p) where TEntity : IEntity {

            p.Properties = getProperties(typeof(TEntity));
            var thead = h.createHead(p);
            var body = h.createBody(p);
            var searchForm = createControls(h, p);

            var div = new TagBuilder("div");
            if (p.MasterController is not null && searchForm is not null) div.InnerHtml.AppendHtml(searchForm);
            var table = new TagBuilder("table");
            table.AddCssClass("table");
            table.InnerHtml.AppendHtml(thead);
            table.InnerHtml.AppendHtml(body);
            div.InnerHtml.AppendHtml(table);

            if (p.Label is not null) return HtmlControl.Control(p.Label, div);
            var writer = new StringWriter();
            div.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }

        private static TagBuilder? createControls<TModel, TEntity>(this IHtmlHelper<TModel> h, ShowTableProperties<TEntity> p) {

            if (!p.IsEditable) return null;
            var createNew = h.ActionLink("Create New", "Create", p.Controller, new { masterController = p.MasterController, masterId = p.MasterId });
            var div = new TagBuilder("div");
            div.AddCssClass("form-actions no-color");
            div.InnerHtml.AppendHtml(createNew);
            return div;
        }

        private static TagBuilder createHead<TModel, TEntity>(this IHtmlHelper<TModel> h,
            ShowTableProperties<TEntity> p) {
            var thead = new TagBuilder("thead");
            var tr = new TagBuilder("tr");
            foreach (var pi in p.Properties) h.addColumn(tr, pi, p.SortOrder, p.SearchString, p.PageNumber, p.MasterController is null);
            if (p.IsEditable) h.addColumn(tr, string.Empty);
            thead.InnerHtml.AppendHtml(tr);
            return thead;
        }
        private static TagBuilder createBody<TModel, TEntity>(this IHtmlHelper<TModel> h,
            ShowTableProperties<TEntity> p) where TEntity : IEntity {
            var tbody = new TagBuilder("tbody");
            foreach (var i in p.Items) {
                var tr = new TagBuilder("tr");
                TagBuilder td;
                foreach (var pi in p.Properties) {
                    td = new TagBuilder("td");
                    var v = pi?.GetValue(i)?.ToString() ?? string.Empty;
                    var value = h.Raw(v);
                    td.InnerHtml.AppendHtml(value);
                    tr.InnerHtml.AppendHtml(td);
                }
                var id = i?.Id.ToString() ?? string.Empty;
                if (p.IsEditable) {
                    td = new TagBuilder("td");
                    h.addLink("Edit", p.Controller, id, td, p.MasterController, p.MasterId);
                    h.addLink("Details", p.Controller, id, td, p.MasterController, p.MasterId);
                    h.addLink("Delete", p.Controller, id, td, p.MasterController, p.MasterId, true);
                    tr.InnerHtml.AppendHtml(td);
                }
                tbody.InnerHtml.AppendHtml(tr);
            }
            return tbody;
        }
        private static void addLink<TModel>(this IHtmlHelper<TModel> h,
            string action, string? controller, string id, TagBuilder td, string? masterController, int? masterId, bool isLast = false) {
            var link = (controller is null)
                ? h.ActionLink(action, action, new { Id = id })
                : h.ActionLink(action, action, controller, new { Id = id, MasterController = masterController, MasterId = masterId });
            td.InnerHtml.AppendHtml(link);
            if (isLast) return;
            td.InnerHtml.AppendHtml(new HtmlString(" | "));
        }
        private static void addColumn<TModel>(this IHtmlHelper<TModel> h,
            TagBuilder tr, PropertyInfo p, string? sortOrder, string? searchString, int? pageNumber, bool isEditable, string tag = "td") {
            var n = newName(p, sortOrder);
            sortOrder = newSortOrder(p.Name, sortOrder);
            var th = new TagBuilder(tag);
            var v = isEditable
                ? h.ActionLink(n, "Index", new { SortOrder = sortOrder, SearchString = searchString, PageNumer = pageNumber })
                : h.Raw(n);
            th.InnerHtml.AppendHtml(v);
            tr.InnerHtml.AppendHtml(th);
        }
        private static string newName(PropertyInfo p, string? sortOrder) {
            var name = p.Name;
            var displayName = p.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? name;
            if (string.IsNullOrEmpty(sortOrder)) return displayName;
            if (!sortOrder.StartsWith(name)) return displayName;
            if (sortOrder.EndsWith("_desc")) return $"{displayName} ↓";
            return $"{displayName} ↑";
        }
        private static void addColumn<TModel>(this IHtmlHelper<TModel> h,
            TagBuilder tr, string name, string tag = "td") {
            var th = new TagBuilder(tag);
            var v = h.Raw(name);
            th.InnerHtml.AppendHtml(v);
            tr.InnerHtml.AppendHtml(th);
        }
        private static string newSortOrder(string? name, string? sortOrder) {
            if (name is null) return string.Empty;
            if (sortOrder is null) return name;
            if (!sortOrder.StartsWith(name)) return name;
            if (sortOrder.EndsWith("_desc")) return name;
            return name + "_desc";
        }
        private static PropertyInfo[] getProperties(Type t)
            => t?.GetProperties()?.Where(x => x.Name != "Id")?.ToArray() ?? [];
    }
}