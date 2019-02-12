using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.App.Auxiliary
{
    public static class StaticMessages
    {   
        public static Dictionary<int, string> Msg = new Dictionary<int, string>()
        {
            {1, "The book is returned." },
            {2, "No such borrower." }
        };
    }
}
