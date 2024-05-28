using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaSe.Pages.Controls;

public static class HtmlControl {
    public static IHtmlContent Control(IHtmlContent label, IHtmlContent context, IHtmlContent? validationMsg = null) {

        var dt = new TagBuilder("dt");
        dt.AddCssClass("col-sm-2");
        dt.InnerHtml.AppendHtml(label);

        var dd = new TagBuilder("dd");
        dd.AddCssClass("col-sm-10");
        dd.InnerHtml.AppendHtml(context);
        if (validationMsg is not null) dd.InnerHtml.AppendHtml(validationMsg);

        var writer = new StringWriter();
        dt.WriteTo(writer, HtmlEncoder.Default);
        dd.WriteTo(writer, HtmlEncoder.Default);

        return new HtmlString(writer.ToString());

    }
}
