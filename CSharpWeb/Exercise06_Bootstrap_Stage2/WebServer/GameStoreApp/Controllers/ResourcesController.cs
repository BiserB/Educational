namespace HTTPServer.GameStoreApp.Controllers
{
    using HTTPServer.Server;
    using HTTPServer.Server.Enums;
    using HTTPServer.Server.Http.Contracts;
    using HTTPServer.Server.Http.Response;
    using System.IO;

    public class ResourcesController
    {
        public IHttpResponse GetFile(IHttpRequest req)
        {
            string path = req.Path;

            string correctPath = path.Replace('/', '\\');

            string filepath = Paths.GameStoreApp + correctPath;

            if (!File.Exists(filepath))
            {
                return new NotFoundResponse();
            }

            byte[] content = File.ReadAllBytes(filepath);

            string contentType = "";
            string extension = Path.GetExtension(filepath);
            string ext = extension.Substring(1, extension.Length - 1);

            switch (ext)
            {
                case "jpeg":
                case "jpg":
                case "bmp":
                case "png":
                case "webp":
                case "gif":
                    contentType = $"image/{ext}";
                    break;

                case "css":
                    contentType = $"text/css";
                    break;

                case "js":
                    contentType = $"text/javascript";
                    break;

                default:
                    contentType = "*/*";
                    break;
            }

            return new FileResponse(HttpStatusCode.Ok, content, contentType);
        }
    }
}