using SimpleMVC.Framework.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SimpleMVC.Framework.Views
{
    public class View : IRenderable
    {
        public const string BaseLayoutFileName = "Layout";

        public const string ContentPlaceholder = "{{{content}}}";

        public const string HtmlExtension = ".html";

        public const string LocalErrorPath = "\\SimpleMvc.Framework\\Errors\\error.html";

        public readonly string templateFullQualifiedName;

        public readonly IDictionary<string, string> viewData;

        public View(string templateFullQualifiedName, IDictionary<string, string> viewData)
        {
            this.templateFullQualifiedName = templateFullQualifiedName;
            this.viewData = viewData;
        }

        public string Render()
        {
            string fullHtml = ReadFile();

            if (this.viewData.Any())
            {
                foreach (var parameter in this.viewData)
                {
                    fullHtml = fullHtml.Replace($"{{{{{{{parameter.Key}}}}}}}", parameter.Value);
                }
            }

            return fullHtml;
        }

        private string ReadFile()
        {
            string layoutHtml = this.RenderLayoutHtml();

            string fullQualifiedNameWithExtension = @"..\..\..\" + this.templateFullQualifiedName + HtmlExtension;

            if (!File.Exists(fullQualifiedNameWithExtension))
            {
                return RegisterError("Request path doesn't exist!");
            }

            string content = File.ReadAllText(fullQualifiedNameWithExtension);

            string result = layoutHtml.Replace(ContentPlaceholder, content);

            return result;
        }

        private string RenderLayoutHtml()
        {
            string layoutHtmlQualifiedName = string.Format(@"..\..\..\{0}\\{1}{2}",
                                                    MvcContext.Get.ViewsFolder,
                                                    BaseLayoutFileName,
                                                    HtmlExtension);
            if (!File.Exists(layoutHtmlQualifiedName))
            {
                return RegisterError("Layout view doesn't exist!");
            }

            string layoutHtmlFileContent = File.ReadAllText(layoutHtmlQualifiedName);

            return layoutHtmlFileContent;
        }

        private string RegisterError(string message)
        {
            string errorPath = this.GetErrorPath();
            string errorHtml = File.ReadAllText(errorPath);
            if (!this.viewData.ContainsKey("error"))
            {
                this.viewData["error"] = "";
            }
            this.viewData["error"] += $"{message} <br />";
            return errorHtml;
        }

        private string GetErrorPath()
        {
            string execPath = Assembly.GetExecutingAssembly().Location;

            string solutionBasePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(execPath), @"..\..\..\.."));

            string errorPagePath = solutionBasePath + LocalErrorPath;

            return errorPagePath;
        }
    }
}