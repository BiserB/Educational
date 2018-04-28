using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;
using t01_Database;

namespace DatabaseTester
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { -999999999, 999999999 })]
        public void CreateDatabaseWithValidElements(int[] sampleData)
        {
            int[] expectedData = new int[16];

            Array.Copy(sampleData, expectedData, sampleData.Length);

            Type databaseType = typeof(Database);

            var db = new Database(sampleData);

            FieldInfo[] dbFields = databaseType
                                   .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo wantedField = dbFields
                                    .First(f => f.FieldType == typeof(int[]));

            int[] resultData = (int[])wantedField.GetValue(db);

            Assert.That(resultData, Is.EquivalentTo(expectedData), "The Database differs from expected");

        }

        [Test]
        public void ThrowExceptionWhenElementsAreTooMuch()
        {
            int[] sampleData = new int[32];            

            var db = new Database();

            Assert.Throws(typeof(InvalidOperationException), () => new Database(sampleData));
        }

        [Test]
        public void AddAllElemets()
        {
            int elementsCount = 16;

            Type databaseType = typeof(Database);

            var db = new Database();

            int[] expectedData = new int[elementsCount];

            for (int num = 0; num < elementsCount; num++)
            {
                expectedData[num] = num;
                db.Add(num);
            }

            FieldInfo[] dbFields = databaseType
                                   .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo wantedField = dbFields
                                    .First(f => f.FieldType == typeof(int[]));

            int[] resultData = (int[])wantedField.GetValue(db);

            Assert.That(resultData, Is.EquivalentTo(expectedData), "The Database differs from expected");
        }
        
        [Test]
        public void ThrowExceptionWhenMoreElementsAdded()
        {
            int elementsCount = 16;

            var db = new Database();            

            for (int num = 0; num < elementsCount; num++)
            {                
                db.Add(num);
            }            

            Assert.That(() => db.Add(1), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveElement()
        {   
            var db = new Database(new int[] { 1 });

            db.Remove();

            Type databaseType = typeof(Database);

            FieldInfo[] dbFields = databaseType
                                   .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo wantedField = dbFields
                                    .First(f => f.FieldType == typeof(int[]));

            int[] resultData = (int[])wantedField.GetValue(db);

            Assert.That(resultData[0] == 0);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { -999999999, 999999999 })]
        public void FetchElements(int[] sampleData)
        {
            var db = new Database(sampleData);

            var resultData = db.Fetch();

            Assert.That(resultData, Is.EqualTo(sampleData));
        }
    }
}
