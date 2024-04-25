using System.ComponentModel;
using System.Reflection;
using System.Text.Encodings.Web;
using HaSe.Domain;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaSe.Pages.Controls {
    public static class HtmlShowTable {
        public static IHtmlContent ShowTable<TModel>(this IHtmlHelper<IEnumerable<TModel>> helper, IEnumerable<TModel> items, string sortOrder, string searchString, int pageNumber) where TModel : IEntity {
            var table = new TagBuilder("table");
            table.AddCssClass("table");

            var properties = GetProperties(typeof(TModel));

            var thead = helper.CreateHead(properties, sortOrder, searchString, pageNumber);
            table.InnerHtml.AppendHtml(thead);

            var tbody = helper.CreateBody(properties, items);
            table.InnerHtml.AppendHtml(tbody);

            var writer = new StringWriter();
            table.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }

        private static TagBuilder CreateHead<TModel>(this IHtmlHelper<IEnumerable<TModel>> helper, PropertyInfo[] properties, string sortOrder, string searchString, int pageNumber) {
            var thead = new TagBuilder("thead");
            var tr = new TagBuilder("tr");
            foreach (var property in properties) {
                helper.AddColumnWithDisplayName(tr, property, sortOrder, searchString, pageNumber);
            }

            helper.AddColumn(tr, string.Empty);
            thead.InnerHtml.AppendHtml(tr);
            return thead;
        }

        private static TagBuilder CreateBody<TModel>(this IHtmlHelper<IEnumerable<TModel>> helper, PropertyInfo[] properties, IEnumerable<TModel> items) where TModel : IEntity {
            var tbody = new TagBuilder("tbody");
            foreach (var item in items) {
                var tr = new TagBuilder("tr");
                TagBuilder td;
                foreach (var property in properties) {
                    td = new TagBuilder("td");
                    var v = (property?.GetValue(item) is DateTime dateTime) ? dateTime.ToString("dd/MM/yyyy") : property?.GetValue(item)?.ToString() ?? String.Empty;
                    var value = helper.Raw(v);
                    td.InnerHtml.AppendHtml(value);
                    tr.InnerHtml.AppendHtml(td);
                }

                var id = item?.Id.ToString() ?? string.Empty;
                td = new TagBuilder("td");
                helper.AddLink("Edit", id, td);
                helper.AddLink("Details", id, td);
                helper.AddLink("Delete", id, td, true);
                tr.InnerHtml.AppendHtml(td);
                tbody.InnerHtml.AppendHtml(tr);
            }

            return tbody;
        }

        private static void AddLink<TModel>(this IHtmlHelper<IEnumerable<TModel>> helper, string action, string id, TagBuilder td, bool isLast = false) {
            var link = helper.ActionLink(action, action, new { Id = id });
            td.InnerHtml.AppendHtml(link);
            if (isLast)
                return;
            td.InnerHtml.AppendHtml(new HtmlString(" | "));
        }

        private static string NewName(string displayName, string propertyName, string sortOrder) {
            if (string.IsNullOrEmpty(sortOrder))
                return displayName;
            if (!sortOrder.StartsWith(propertyName))
                return displayName;
            if (sortOrder.EndsWith("_desc"))
                return $"{displayName} ↑";
            return $"{displayName} ↓";
        }

        private static string NewSortOrder(string name, string sortOrder) {
            if (name is null)
                return string.Empty;
            if (sortOrder is null)
                return name;
            if (!sortOrder.StartsWith(name))
                return name;
            if (sortOrder.EndsWith("_desc"))
                return name;
            return name + "_desc";
        }

        private static void AddColumn<TModel>(this IHtmlHelper<IEnumerable<TModel>> helper, TagBuilder tr, string value, string tag = "td") {
            var th = new TagBuilder(tag);
            var v = helper.Raw(value);
            th.InnerHtml.AppendHtml(v);
            tr.InnerHtml.AppendHtml(th);
        }

        private static PropertyInfo[] GetProperties(Type type) {
            return type?.GetProperties()?.Where(x => x.Name != "Id")?.ToArray() ?? [];
        }

        private static void AddColumnWithDisplayName<TModel>(this IHtmlHelper<IEnumerable<TModel>> helper, TagBuilder tr, PropertyInfo property, string sortOrder, string searchString, int pageNumber, string tag = "td") {
            var displayName = property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? property.Name;
            var propertyName = property.Name;
            sortOrder = NewSortOrder(propertyName, sortOrder);
            var th = new TagBuilder(tag);
            var v = helper.ActionLink(NewName(displayName, propertyName, sortOrder), "Index", new { SortOrder = sortOrder, SearchString = searchString, PageNumber = pageNumber });
            th.InnerHtml.AppendHtml(v);
            tr.InnerHtml.AppendHtml(th);
        }
    }
}