using System;
using System.IO;


namespace SimpleMVC.ByTheCakeApp.Utilities
{
    public static class Paths
    {
        public static readonly string basePath = Path
            .Combine(AppContext.BaseDirectory, "..\\..\\..\\");

        public static readonly string resourcePath = @"ByTheCakeApp\Resources\";

        public static readonly string dataPath = @"ByTheCakeApp\Data\";
    }
}
