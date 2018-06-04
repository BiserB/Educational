namespace SimpleMVC.Server.Contracts
{
    public interface IRequestHandler
    {
        IHttpResponse Handle(IHttpRequest httpRequest);
    }
}