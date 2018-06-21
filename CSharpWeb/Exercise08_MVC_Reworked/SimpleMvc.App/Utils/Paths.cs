using System.IO;
using System.Reflection;

namespace SimpleMvc.App.Utils
{
    public static class Paths
    {
        public static readonly string ExecPath = Assembly.GetExecutingAssembly().Location;

        public static readonly string SolutionBasePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(ExecPath), @"..\..\..\.."));

        public static readonly string NoteOperationsPath = SolutionBasePath + $@"\SimpleMvc.App\Views\Note\NoteView.html";
    }
}