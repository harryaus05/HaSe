﻿using System.ComponentModel;
using System.Reflection;
using System.Text.Encodings.Web;
using HaSe.Domain;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaSe.Pages.Controls {
    public static class HtmlShowTable {
        public static IHtmlContent ShowTable<TModel, TEntity>(this IHtmlHelper<TModel> h,
               IEnumerable<TEntity> items, string sortOrder, string searchString, int pageNumber, bool isEditable = true) where TEntity : IEntity {
            var table = new TagBuilder("table");
            table.AddCssClass("table");

            var properties = GetProperties(typeof(TEntity));

            var thead = h.CreateHead(properties, sortOrder, searchString, pageNumber, isEditable);
            table.InnerHtml.AppendHtml(thead);

            var body = h.CreateBody(properties, items, isEditable);
            table.InnerHtml.AppendHtml(body);

            var writer = new StringWriter();
            table.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }

        private static TagBuilder CreateHead<TModel>(this IHtmlHelper<TModel> h,
            PropertyInfo[] properties, string sortOrder, string searchString, int pageNumber, bool isEditable) {
            var thead = new TagBuilder("thead");
            var tr = new TagBuilder("tr");
            foreach (var p in properties) h.AddColumn(tr, p, sortOrder, searchString, pageNumber, isEditable);
            if (isEditable) h.AddColumn(tr, string.Empty);
            thead.InnerHtml.AppendHtml(tr);
            return thead;
        }
        private static TagBuilder CreateBody<TModel, TEntity>(this IHtmlHelper<TModel> h,
            PropertyInfo[] properties, IEnumerable<TEntity> items, bool isEditable) where TEntity : IEntity {
            var tbody = new TagBuilder("tbody");
            foreach (var i in items) {
                var tr = new TagBuilder("tr");
                TagBuilder td;
                foreach (var p in properties) {
                    td = new TagBuilder("td");
                    var v = p?.GetValue(i)?.ToString() ?? string.Empty;
                    var value = h.Raw(v);
                    td.InnerHtml.AppendHtml(value);
                    tr.InnerHtml.AppendHtml(td);
                }
                var id = i?.Id.ToString() ?? string.Empty;
                if (isEditable) {
                    td = new TagBuilder("td");
                    h.AddLink("Edit", id, td);
                    h.AddLink("Details", id, td);
                    h.AddLink("Delete", id, td, true);
                    tr.InnerHtml.AppendHtml(td);
                }
                tbody.InnerHtml.AppendHtml(tr);
            }
            return tbody;
        }
        private static void AddLink<TModel>(this IHtmlHelper<TModel> h,
            string action, string id, TagBuilder td, bool isLast = false) {
            var link = h.ActionLink(action, action, new { Id = id });
            td.InnerHtml.AppendHtml(link);
            if (isLast) return;
            td.InnerHtml.AppendHtml(new HtmlString(" | "));
        }
        private static void AddColumn<TModel>(this IHtmlHelper<TModel> h,
            TagBuilder tr, PropertyInfo p, string sortOrder, string searchString, int pageNumber, bool isEditable, string tag = "td") {
            var n = NewName(p, sortOrder);
            sortOrder = NewSortOrder(p.Name, sortOrder);
            var th = new TagBuilder(tag);
            var v = isEditable
                ? h.ActionLink(n, "Index", new { SortOrder = sortOrder, SearchString = searchString, PageNumer = pageNumber })
                : h.Raw(n);
            th.InnerHtml.AppendHtml(v);
            tr.InnerHtml.AppendHtml(th);
        }
        private static string NewName(PropertyInfo p, string sortOrder) {
            var name = p.Name;
            var displayName = p.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? name;
            if (string.IsNullOrEmpty(sortOrder)) return displayName;
            if (!sortOrder.StartsWith(name)) return displayName;
            if (sortOrder.EndsWith("_desc")) return $"{displayName} ↓";
            return $"{displayName} ↑";
        }
        private static void AddColumn<TModel>(this IHtmlHelper<TModel> h,
            TagBuilder tr, string name, string tag = "td") {
            var th = new TagBuilder(tag);
            var v = h.Raw(name);
            th.InnerHtml.AppendHtml(v);
            tr.InnerHtml.AppendHtml(th);
        }
        private static string NewSortOrder(string name, string sortOrder) {
            if (name is null) return string.Empty;
            if (sortOrder is null) return name;
            if (!sortOrder.StartsWith(name)) return name;
            if (sortOrder.EndsWith("_desc")) return name;
            return name + "_desc";
        }
        private static PropertyInfo[] GetProperties(Type t)
            => t?.GetProperties()?.Where(x => x.Name != "Id")?.ToArray() ?? [];
    }
}