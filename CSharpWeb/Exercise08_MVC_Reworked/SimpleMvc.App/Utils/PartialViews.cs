using System.IO;

namespace SimpleMvc.App.Utils
{
    public static class PartialViews
    {
        public static readonly string NoteView = File.ReadAllText(Paths.NoteOperationsPath);
    }
}