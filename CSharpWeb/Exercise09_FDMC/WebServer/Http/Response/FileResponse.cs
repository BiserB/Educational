namespace WebServer.Http.Response
{
    using Enums;
    using Exceptions;

    public class FileResponse : HttpResponse
    {
        public FileResponse(HttpStatusCode statusCode, byte[] fileData, string mimeType)
        {
            this.ValidateStatusCode(statusCode);

            this.StatusCode = statusCode;
            this.FileData = fileData;

            this.Headers.Add(HttpHeader.ContentLength, this.FileData.Length.ToString());
            this.Headers.Add(HttpHeader.ContentType, mimeType);
            this.Headers.Add(HttpHeader.ContentDisposition, "attachment");
        }

        private void ValidateStatusCode(HttpStatusCode statusCode)
        {
            int numberOfStatusCode = (int)statusCode;

            if (!(200 <= numberOfStatusCode && numberOfStatusCode < 300))
            {
                throw new InvalidResponseException("File response need a status code between 200 and 300");
            }
        }

        public byte[] FileData { get; }
    }
}