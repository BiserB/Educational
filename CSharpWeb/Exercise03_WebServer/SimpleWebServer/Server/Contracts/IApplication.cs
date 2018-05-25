using SimpleWebServer.Server.Routing.Contracts;

namespace SimpleWebServer.Server.Contracts
{
    public interface IApplication
    {
        void Configure(IAppRouteConfig appRouteConfig);
    }
}