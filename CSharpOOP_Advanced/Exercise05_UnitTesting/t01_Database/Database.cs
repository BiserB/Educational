using System;
using System.Collections.Generic;
using System.Text;
using t01_Database.Contracts;

namespace t01_Database
{
    // Store integers. Capacity is exactly 16 integers.

    public class Database : IDatabase
    {
        private readonly string INVALID_COUNT = "Count of the elements exceed capacity!";
        private readonly string FULL_DATABASE = "Database is full!";
        private readonly string EMPTY_DATABASE = "Database is empty!";

        private readonly int CAPACITY = 16;

        private int[] storage;
        private int pointer;

        public Database()
        {
            this.storage = new int[CAPACITY];
            this.pointer = 0;
        }

        public Database(params int[] elements) : this()
        {
            CheckCapacity(elements.Length);            

            EnterData(elements);
        }

        private void EnterData(int[] elements)
        {
            Array.Copy(elements, this.storage, elements.Length);

            this.pointer = elements.Length;
        }

        public void Add(int element)
        {
            if (this.pointer == CAPACITY)
            {
                throw new InvalidOperationException(FULL_DATABASE);
            }

            this.storage[pointer] = element;
            pointer++;
        }        

        public void Remove()
        {
            if (pointer == 0)
            {
                throw new InvalidOperationException(EMPTY_DATABASE);
            }

            pointer--;
            this.storage[pointer] = 0;
        }

        public int[] Fetch()
        {
            int[] result = new int[pointer];

            Array.Copy(storage, result, pointer);

            return result;
        }

        private void CheckCapacity(int count)
        {
            if (count > 16)
            {
                throw new InvalidOperationException(INVALID_COUNT);
            }

        }
    }
}
