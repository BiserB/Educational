using System;
using System.Collections.Generic;
using System.Linq;
using BookLibrary.Data;

namespace BookLibrary.App.Auxiliary
{
    public static class BookStatus
    {
        public static int AtHome => 1;

        public static int Borrowed => 2;
    }
}
