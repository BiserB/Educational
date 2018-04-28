using System;
using System.Collections.Generic;
using System.Text;

namespace t01_Database.Contracts
{
    public interface IDatabase
    {        
        void Add(int element);

        void Remove();

        int[] Fetch();
    }
}
