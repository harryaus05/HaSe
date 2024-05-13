using System.Linq.Expressions;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaSe.Pages.Controls {
    public static class HtmlShowItem {
        public static IHtmlContent ShowItem<TModel, TValue>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string? value = null) {
            var displayName = helper.DisplayNameFor(expression);
            var displayValue = helper.DisplayFor(expression);

            var dt = new TagBuilder("dt");
            dt.AddCssClass("col-sm-2");
            dt.InnerHtml.Append(displayName);

            var dd = new TagBuilder("dd");
            dd.AddCssClass("col-sm-10");
            dd.InnerHtml.AppendHtml(displayValue);

            var combinedTag = new TagBuilder("combinedTag");
            combinedTag.AddCssClass("row");
            combinedTag.InnerHtml.AppendHtml(dt);
            combinedTag.InnerHtml.AppendHtml(dd);

            var writer = new StringWriter();
            combinedTag.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }
    }
}