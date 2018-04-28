using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;
using t03_ListIterator;

namespace t03_ListIteratorTests
{
    public class ListIteratorTests
    {
        [Test]
        public void CreateListIterator()
        {
            string[] testData = new string[] { "aa", "bb", "cc" };

            ListIterator li = new ListIterator(testData);

            Type iteratorType = li.GetType();

            FieldInfo[] fields = iteratorType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo listField = fields.FirstOrDefault(f => f.Name == "list");

            var resultData = listField.GetValue(li);

            Assert.That(resultData, Is.EqualTo(testData));
        }

        [Test]
        public void ThrowExceptionWithNullArgument()
        { 
            Assert.That(() => new ListIterator(null), Throws.ArgumentNullException);
        }

        [Test]
        public void HasNextReturnsTrue()
        {
            string[] testData = new string[] { "aa", "bb", "cc" };            

            ListIterator li = new ListIterator(testData);            

            Assert.That(li.HasNext(), Is.True);
        }

        [Test]
        public void HasNextReturnsFalse()
        {           
            ListIterator li = new ListIterator();

            Assert.That(li.HasNext(), Is.False);
        }

        [Test]
        public void MoveIndexReturnsTrue()
        {
            string[] testData = new string[] { "aa", "bb", "cc" };

            ListIterator li = new ListIterator(testData);

            Assert.That(li.Move(), Is.True);
        }

        [Test]
        public void MoveIndexReturnsFalse()
        {
            string[] testData = new string[] { "aa", "bb", "cc" };

            ListIterator li = new ListIterator(testData);

            li.Move();
            li.Move();

            Assert.That(li.Move(), Is.False);
        }

        [Test]
        public void PrintReturnsElement()
        {
            string[] testData = new string[] { "aa", "bb", "cc" };
            string[] resultData = new string[testData.Length];

            ListIterator li = new ListIterator(testData);

            for (int i = 0; i < testData.Length; i++)
            {
                resultData[i] = li.Print();
                li.Move();
            }

            Assert.That(resultData, Is.EqualTo(testData));
        }

        [Test]
        public void PrintOnEmptyListThrowsException()
        {            
            ListIterator li = new ListIterator();            

            Assert.That(() => li.Print(), Throws
                                    .InvalidOperationException
                                    .With.Message.EqualTo("Invalid operation!"));
        }
    }
}