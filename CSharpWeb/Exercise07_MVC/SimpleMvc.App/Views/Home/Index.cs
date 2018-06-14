namespace SimpleMvc.App.Views.Home
{
    using SimpleMvc.App.Utils;
    using SimpleMVC.Framework.Interfaces;
    using System.IO;

    public class Index : IRenderable
    {
        public string Render()
        {
            string index = File.ReadAllText(Paths.FilePath + "index.html");

            return index;
        }
    }
}