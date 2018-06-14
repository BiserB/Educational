using System.IO;

namespace SimpleMvc.App.Utils
{
    public static class HtmlStrings
    {
        public static readonly string HtmlPath = @"..\..\..\Html\";

        public static readonly string RegisterForm = File.ReadAllText(HtmlPath + "register.html");
    }
}