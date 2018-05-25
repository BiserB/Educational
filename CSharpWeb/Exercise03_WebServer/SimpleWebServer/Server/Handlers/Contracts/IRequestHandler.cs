using SimpleWebServer.Server.HTTP.Contracts;

namespace SimpleWebServer.Server.Handlers.Contracts
{
    public interface IRequestHandler
    {
        IHttpResponse Handle(IHttpContext httpContext);
    }
}