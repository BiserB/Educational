namespace SimpleMvc.App.Views.User
{
    using SimpleMvc.App.Utils;
    using SimpleMvc.App.ViewModels;
    using SimpleMVC.Framework.Interfaces.Generic;
    using System.IO;
    using System.Text;

    public class Profile : IRenderable<UserProfileViewModel>
    {
        public UserProfileViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder allNotes = new StringBuilder();

            allNotes.AppendLine("<ul>");
            foreach (var note in Model.Notes)
            {
                allNotes.AppendLine($"<li><strong>{note.Title}</strong> - {note.Content}</li>");
            }
            allNotes.AppendLine("</ul>");

            string profileForm = File.ReadAllText(Paths.FilePath + "profile.html");

            string result = profileForm.Replace("{{{username}}}", Model.Username);
            result = result.Replace("{{{userId}}}", Model.UserId.ToString());
            result = result.Replace("{{{allNotes}}}", allNotes.ToString());

            return result;
        }
    }
}