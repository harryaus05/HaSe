using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Encodings.Web;
using HaSe.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaSe.Pages.Controls {
    public static class HtmlEditEnum {
        public static IHtmlContent EditEnum<TModel, TValue>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression) where TValue : Enum {
            var label = helper.LabelFor(expression, new { @class = "control-label" });
            var editor = helper.DropDownListFor(expression, SelectList<TValue>(), new { @class = "form-control" });
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

        internal static List<SelectListItem> SelectList<TValue>() where TValue : Enum {
            var list = Enum.GetValues(typeof(TValue)).Cast<TValue>().Select(x => new SelectListItem {
                Text = x.ToString(),
                Value = x.ToString()
            }).ToList();
            list.Insert(0, new SelectListItem{ Text = $"-- {Constants.Select} {ToDescription(typeof(TValue))} --", Value = ""});
            return list;
        }

        internal static string ToDescription<TValue>(TValue value) where TValue : Enum {
            var field = value.GetType()?.GetField(value.ToString() ?? string.Empty);
            var attribute = field?.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute?.Description ?? value.ToString() ?? string.Empty;
        }

        internal static string ToDescription(Type type) {
            var attribute = type?.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute?.Description ?? type?.Name ?? string.Empty;
        }
    }
}
