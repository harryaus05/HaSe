using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaSe.Pages.Controls;

public static class HtmlShowItem {
    public static IHtmlContent ShowItem<TModel, TValue>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TValue>> e, string? value = null) {
        var lab = h.LabelFor(e);
        var val = (value is null) ? h.DisplayFor(e) : h.Raw(value);

        return HtmlControl.Control(lab, val);
    }
}
