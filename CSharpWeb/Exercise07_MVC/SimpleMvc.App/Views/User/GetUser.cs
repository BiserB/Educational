namespace SimpleMvc.App.Views.User
{
    using SimpleMvc.App.Utils;
    using SimpleMVC.Framework.Interfaces;
    using System.IO;

    public class GetUser : IRenderable
    {
        public string Render()
        {
            string getUserForm = File.ReadAllText(Paths.FilePath + "getUser.html");

            return getUserForm;
        }
    }
}