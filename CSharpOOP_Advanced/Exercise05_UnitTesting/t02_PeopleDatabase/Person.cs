using System;
using t02_PeopleDatabase.Contracts;

namespace t02_PeopleDatabase
{
    public class Person : IPerson
    {
        private long id;
        private string username;

        public Person(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public long Id
        {
            get { return id; }
            private set { id = value; }
        }

        public string Username
        {
            get { return username; }
            private set { username = value; }
        }

    }
}
