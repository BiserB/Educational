using System;
using System.Collections.Generic;
using System.Linq;
using t02_PeopleDatabase.Contracts;

namespace t02_PeopleDatabase
{
    public class Database : IDatabase
    {
        private List<IPerson> register;

        public Database()
        {
            register = new List<IPerson>();
        }

        public Database(ICollection<IPerson> persons): this()
        {            
            EnterData(persons);
        }        


        private void EnterData(ICollection<IPerson> persons)
        {
            foreach (var person in persons)
            {
                register.Add(person);
            }
        }

        public void Add(IPerson person)
        {
            long id = person.Id;
            string username = person.Username;
            if (FoundId(id))
            {
                throw new InvalidOperationException("Duplicate Id!");
            }
            if (FoundUsername(username))
            {
                throw new InvalidOperationException("Duplicate Username!");
            }
            register.Add(person);
        }

        public void Remove()
        {
            register.RemoveAt(register.Count - 1);
        }

        public IPerson[] Fetch()
        {
            IPerson[] result = register.ToArray();

            return result;
        }

        private bool FoundId(long id)
        {
            foreach (var record in register)
            {
                if (record.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        private bool FoundUsername(string username)
        {
            foreach (var record in register)
            {
                if (record.Username == username)
                {
                    return true;
                }
            }
            return false;
        }

        public IPerson FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Empty username!");
            }

            if (!FoundUsername(username))
            {
                throw new InvalidOperationException("Username doesn't exist!");
            }

            IPerson result = register.First(p => p.Username == username);

            return result;
        }

        public IPerson FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Negative Id!");
            }

            if (!FoundId(id))
            {
                throw new InvalidOperationException("Id doesn't exist!");
            }

            IPerson result = register.First(p => p.Id == id);

            return result;
        }
    }
}
