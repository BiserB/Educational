using SimpleMVC.Server.Contracts;
using SimpleMVC.Server.HTTP;
using System;

namespace SimpleMVC.Server.Handlers
{
    public class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpRequest, IHttpResponse> handlerFunc;

        public RequestHandler(Func<IHttpRequest, IHttpResponse> handlerFunc)
        {
            this.handlerFunc = handlerFunc;
        }

        public IHttpResponse Handle(IHttpRequest httpRequest)
        {            
            string sessionIdToSend = null;            

            if (!httpRequest.CookieCollection.ContainsKey(SessionStore.SessionCookieKey))
            {
                string sessionId = Guid.NewGuid().ToString();

                httpRequest.Session = SessionStore.Get(sessionId);

                sessionIdToSend = sessionId;
            }

            IHttpResponse response = this.handlerFunc(httpRequest);

            response.AddHeader("Content-Type", "text/html");

            if (sessionIdToSend != null)
            {
                response.AddHeader("Set-Cookie",
                    $"{SessionStore.SessionCookieKey}={sessionIdToSend}; HttpOnly; path=/");
            }            

            foreach (var cookie in response.CookieCollection)
            {
                response.AddHeader("Set-Cookie", cookie.ToString());
            }
                        
            return response;
        }
    }
}