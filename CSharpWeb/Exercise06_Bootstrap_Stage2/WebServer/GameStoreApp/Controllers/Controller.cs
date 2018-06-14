namespace HTTPServer.GameStoreApp.Infrastructure
{
    using HTTPServer.GameStoreApp.Utilities;
    using HTTPServer.GameStoreApp.Views;
    using HTTPServer.Server.Http;
    using Server.Enums;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public abstract class Controller
    {
        private string DefaultPath = Config.DefaultPath;
        public const string ContentPlaceholder = "{{{content}}}";

        protected Controller()
        {
            this.ViewData = new Dictionary<string, string>
            {
                ["authDisplay"] = "block",
                ["login"] = "block",
                ["register"] = "block",
                ["admin"] = "",
                ["logout"] = "none",
            };
        }

        protected IDictionary<string, string> ViewData { get; private set; }

        protected IHttpResponse FileViewResponse(string fileName)
        {
            var result = this.ProcessFileHtml(fileName);

            if (this.ViewData.Any())
            {
                foreach (var value in this.ViewData)
                {
                    result = result.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
                }
            }

            return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
        }

        private string ProcessFileHtml(string fileName)
        {
            var layoutHtml = File.ReadAllText(string.Format(DefaultPath, "layout"));

            var fileHtml = File.ReadAllText(string.Format(DefaultPath, fileName));

            var result = layoutHtml.Replace(ContentPlaceholder, fileHtml);

            return result;
        }

        public bool LoginCheck(IHttpRequest req)
        {
            bool loggedIn = false;

            if (req.Session.Contains(SessionStore.CurrentUserKey))
            {
                this.ViewData["login"] = "none";
                this.ViewData["register"] = "none";
                this.ViewData["logout"] = "block";

                loggedIn = true;
            }

            if (req.Session.Contains(SessionStore.AdminKey))
            {
                this.ViewData["admin"] = File.ReadAllText(string.Format(Config.DefaultPath, "adminMenu"));
            }

            return loggedIn;
        }
    }
}