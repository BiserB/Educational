using System.Collections.Generic;

namespace BookLibrary.App.Auxiliary
{
    public static class StaticMessages
    {
        public static Dictionary<int, string> Msg = new Dictionary<int, string>()
        {
            {1, "The item is returned." },
            {2, "No such borrower." },
            {3, "No such loan." },
            {4, "No such movie." },
        };
    }
}