using SimpleMVC.Server.Contracts;
using System;

namespace SimpleMVC.Application.Views
{
    public class SessionTestView : IView
    {
        private readonly DateTime dateTime;

        public SessionTestView(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public string View()
        {
            return $"<h1>Registered on {dateTime}</h1>";
        }
    }
}
