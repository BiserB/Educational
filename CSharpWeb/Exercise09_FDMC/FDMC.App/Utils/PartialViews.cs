using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace FDMC.App.Utils
{
    public static class PartialViews
    {
        public static readonly string ExecPath = Assembly.GetExecutingAssembly().Location;

        public static readonly string SolutionBasePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(ExecPath), @"..\..\..\.."));

        public static readonly string PartialViewsPath = SolutionBasePath + $@"\FDMC.App\Views\Partial\";

        public static readonly string LoginButton = File.ReadAllText(PartialViewsPath + "LoginButton.html");

        public static readonly string LogoutButton = File.ReadAllText(PartialViewsPath + "LogoutButton.html");

        public static readonly string RegisterButton = File.ReadAllText(PartialViewsPath + "RegisterButton.html");

        public static readonly string AllKittenButton = File.ReadAllText(PartialViewsPath + "AllKittenButton.html");

        public static readonly string AddKittenButton = File.ReadAllText(PartialViewsPath + "AddKittenButton.html");

        public static readonly string KittenView = File.ReadAllText(PartialViewsPath + "KittenView.html");

        public static readonly Dictionary<int, string> ImageSource = new Dictionary<int, string>()
        {
            {0, "/Images/street-transcended.jpg"},
            {1, "/Images/american-shorthair.jpg"},
            {2, "/Images/munchkin.jpg"},
            {3, "/Images/siamese.jpg"}
        };


    }
}
