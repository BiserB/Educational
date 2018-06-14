namespace SimpleMvc.App.Views.User
{
    using SimpleMvc.App.Utils;
    using SimpleMvc.App.ViewModels;
    using SimpleMVC.Framework.Interfaces.Generic;
    using System.IO;
    using System.Text;

    public class All : IRenderable<AllUsernamesViewModel>
    {
        public AllUsernamesViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var username in Model.Usernames)
            {
                sb.AppendLine($"<li>{username}</li>");
            }

            string usernames = $"<ul>{sb.ToString()}</ul>";

            string htmlList = File.ReadAllText(Paths.FilePath + "list.html");

            string usernamesList = htmlList.Replace("{{{usernames}}}", usernames);

            return usernamesList;
        }
    }
}