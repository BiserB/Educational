using System;
using System.Collections.Generic;
using System.Linq;

namespace t03_ListIterator
{
    public class ListIterator
    {
        private List<string> list;
        private int pointer;

        public ListIterator()
        {
            this.list = new List<string>();
            this.pointer = 0;
        }

        public ListIterator(ICollection<string> collection) : this()
        {
            EnterData(collection);
        }

        private void EnterData(ICollection<string> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Parameter  cannot be null!");
            }

            list = collection.ToList();
        }

        public bool HasNext()
        {
            if (pointer < list.Count - 1)
            {
                return true;
            }
            return false;
        }

        public bool Move()
        {
            if (HasNext())
            {
                pointer++;
                return true;
            }
            return false;
        }

        public string Print()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation!");
            }
            return list[pointer];
        }
    }
}
