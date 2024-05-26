using System.Linq.Expressions;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaSe.Pages.Controls {
    public static class HtmlEditItem {
        public static IHtmlContent EditItem<TModel, TValue>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression) {
            var label = helper.LabelFor(expression, new { @class = "control-label" });
            var editor = helper.EditorFor(expression, new { htmlAttributes = new { @class = "form-control" } });
            var validation = helper.ValidationMessageFor(expression, string.Empty, new { @class = "text-danger" });

            var div = new TagBuilder("div");
            div.AddCssClass("form-group");
            div.InnerHtml.AppendHtml(label);
            div.InnerHtml.AppendHtml(editor);
            div.InnerHtml.AppendHtml(validation);

            var writer = new StringWriter();
            div.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }
    }
}