namespace SimpleMvc.App.Views.User
{
    using SimpleMvc.App.Utils;
    using SimpleMVC.Framework.Interfaces;
    using System.IO;

    public class Register : IRenderable
    {
        public string Render()
        {
            string regForm = File.ReadAllText(Paths.FilePath + "register.html");

            return regForm;
        }
    }
}