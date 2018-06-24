namespace SimpleMVC.Framework.Routers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using WebServer.Contracts;
    using WebServer.Enums;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ResourceRouter : IHandleable
    {
        private static readonly Dictionary<string, string> MIME_types = new Dictionary<string, string>()
        {
            {"js", "application/javascript" },
            {"css", "text/css" },
            {"html", "text/html" },
            {"jpeg", "image/jpeg" },
            {"jpg", "image/jpeg" },
            {"bmp", "image/bmp" },
            {"gif", "image/gif" },
            {"png", "image/png" }
        };

        public IHttpResponse Handle(IHttpRequest request)
        {
            string filename = request.Path.Split('/').Last();

            string fileExtension = filename.Split('.').Last();

            if (!MIME_types.ContainsKey(fileExtension))
            {
                return new NotFoundResponse();
            }

            try
            { 
                string mimeType = MIME_types[fileExtension];

                byte[] content = this.ReadFileContent(request.Path);

                var response = new FileResponse(HttpStatusCode.Ok, content, mimeType);

                return response;
            }
            catch (Exception)
            {
                return new NotFoundResponse();
            }
        }

        private byte[] ReadFileContent(string filename)
        {
            string correctedFilePath = filename.Replace('/', '\\');

            string path = $@"{MvcContext.Get.ResourceFolder}{correctedFilePath}";

            return File.ReadAllBytes(path);
        }
    }
}