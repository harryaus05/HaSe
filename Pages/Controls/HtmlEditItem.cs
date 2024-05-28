using System.Linq.Expressions;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaSe.Pages.Controls {
    public static class HtmlEditItem {
        public static IHtmlContent EditItem<TModel, TValue>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> e) {

            var lab = h.LabelFor(e, new { @class = "control-label" });
            var ed = h.EditorFor(e, new { htmlAttributes = new { @class = "form-control" } });
            var val = h.ValidationMessageFor(e, string.Empty, new { @class = "text-danger" });

            return HtmlControl.Control(lab, ed, val);
        }
    }
}