using System.IO;
using System.Reflection;

namespace MyTube.App.Utils
{
    public static class Paths
    {
        public static readonly string ExecPath = Assembly.GetExecutingAssembly().Location;

        public static readonly string SolutionBasePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(ExecPath), @"..\..\..\.."));

        public static readonly string PartialViewsPath = SolutionBasePath + $@"\MyTube.App\Views\Partial\";
    }
}