using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace HaSe.Pages.Controls;
public static class HtmlSelectItem {
    public static IHtmlContent SelectItem<TModel, TValue>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> e, string controller) {

        var lab = h.LabelFor(e, new { @class = "control-label" });
        var n = h.NameFor(e);
        var v = h.ValueFor(e);
        var ed = new HtmlString(
            $"<select name=\"{n}\" " +
            "class=\"selectItems2 form-control\" " +
            $"data-controller=\"{controller}\" " +
            $"data-id=\"{v}\">" +
            "</select>"
        );
        var val = h.ValidationMessageFor(e, string.Empty, new { @class = "text-danger" });

        return HtmlControl.Control(lab, ed, val);
    }
}
