using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Text.Encodings.Web;

namespace SoftUni.App.Helpers
{
    public static class FormGroupHelper
    {
        public static IHtmlContent FormGroupFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper,
                                                        Expression<Func<TModel, TResult>> expression)
        {
            using (var writer = new StringWriter())
            {
                var label = htmlHelper.LabelFor(expression);
                var editor = htmlHelper.EditorFor(expression, new { htmlAttributes = new { @class = "form-control" } });
                var validationMessage = htmlHelper.ValidationMessageFor(expression, null, new { @class = "text-danger" });

                writer.Write("<div class=\"form-group row\">");
                label.WriteTo(writer, HtmlEncoder.Default);
                editor.WriteTo(writer, HtmlEncoder.Default);
                validationMessage.WriteTo(writer, HtmlEncoder.Default);
                writer.Write("</div>");

                return new HtmlString(writer.ToString());
            }
        }
    }
}