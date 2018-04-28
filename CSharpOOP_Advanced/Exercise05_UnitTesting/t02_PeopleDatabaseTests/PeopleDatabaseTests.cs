using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using t02_PeopleDatabase;
using t02_PeopleDatabase.Contracts;

namespace t02_PeopleDatabaseTests
{
    public class PeopleDatabaseTests
    {
        private Person testPerson1 = new Person(1, "admin");
        private Person testPerson2 = new Person(2, "moderator");
        

        [Test]
        public void CheckEmptyConstructor()
        {
            Database db = new Database();

            Type dbtype = db.GetType();

            FieldInfo[] Fields = dbtype.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo wantedField = Fields.FirstOrDefault(f => f.FieldType == typeof(List<IPerson>));

            Assert.That(wantedField != null);
        }

        [Test]
        public void CheckConstructorWithArguments()
        {  
            Database db = new Database(new List<IPerson>() { testPerson1, testPerson2 });

            Type dbtype = db.GetType();

            FieldInfo[] Fields = dbtype.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo wantedField = Fields.FirstOrDefault(f => f.FieldType == typeof(List<IPerson>));

            List<IPerson> result = (List<IPerson>)wantedField.GetValue(db);

            Assert.That(result.Count == 2);
        }

        [Test]
        public void AddValidPersons()
        {
            Database db = new Database();

            db.Add(testPerson1);
            db.Add(testPerson2);

            Type dbtype = db.GetType();

            FieldInfo[] Fields = dbtype.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo wantedField = Fields.FirstOrDefault(f => f.FieldType == typeof(List<IPerson>));

            List<IPerson> result = (List<IPerson>)wantedField.GetValue(db);

            var result1 = result[0];
            var result2 = result[1];

            Assert.That(result1.Equals(testPerson1) && result2.Equals(testPerson2));
        }

        [Test]
        public void ThrowExceptionWhenDuplicateIds()
        {
            Database db = new Database();

            db.Add(new Person(1, "fakeAdmin"));

            Assert.That(() => db.Add(testPerson1), Throws.InvalidOperationException);
        }

        [Test]
        public void ThrowExceptionWhenDuplicateUsernames()
        {
            Database db = new Database();

            db.Add(new Person(101, "admin"));

            Assert.That(() => db.Add(testPerson1), Throws.InvalidOperationException);
        }

        [Test]
        public void RemovePersonFromDatabase()
        {
            Database db = new Database(new List<IPerson>() { testPerson1, testPerson2 });

            db.Remove();
            db.Remove();

            Type dbtype = db.GetType();

            FieldInfo[] Fields = dbtype.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo wantedField = Fields.FirstOrDefault(f => f.FieldType == typeof(List<IPerson>));

            List<IPerson> result = (List<IPerson>)wantedField.GetValue(db);

            Assert.That(result.Count == 0);
        }

        [Test]
        public void FindPersonByUsername()
        {
            Database db = new Database(new List<IPerson>() { testPerson1, testPerson2 });

            IPerson result = db.FindByUsername("admin");

            Assert.That(result, Is.EqualTo(testPerson1));
        }

        [Test]
        public void FindPersonById()
        {
            Database db = new Database(new List<IPerson>() { testPerson1, testPerson2 });

            IPerson result = db.FindById(1);

            Assert.That(result, Is.EqualTo(testPerson1));
        }

        [Test]
        public void ThrowExceptionWhenSearchPersonByEmptyUsername()
        {
            Database db = new Database(new List<IPerson>() { testPerson1, testPerson2 });
            
            Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        public void ThrowExceptionWhenSearchByNonexistentUsername()
        {
            Database db = new Database(new List<IPerson>() { testPerson1, testPerson2 });

            Assert.That(() => db.FindByUsername("ADMIN"), Throws.InvalidOperationException);
        }

        [Test]
        public void ThrowExceptionWhenSearchPersonByNegativeId()
        {
            Database db = new Database(new List<IPerson>() { testPerson1, testPerson2 });

            Assert.Throws(typeof(ArgumentOutOfRangeException),() => db.FindById(-101));
        }

        [Test]
        public void ThrowExceptionWhenSearchByNonexistentID()
        {
            Database db = new Database(new List<IPerson>() { testPerson1, testPerson2 });

            Assert.That(() => db.FindById(999), Throws.InvalidOperationException);
        }
    }
}
