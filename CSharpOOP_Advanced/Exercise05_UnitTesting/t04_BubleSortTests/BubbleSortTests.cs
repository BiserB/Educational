using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace t04_BubbleSort
{
    public class BubbleSortTests
    {
        [Test]
        public void CorrectResultsFromSortMethod()
        {
            int[] unsorted = new int[] { 5, 1, 4, 2, 3 };
            int[] sorted = new int[] { 1, 2, 3, 4, 5 };

            Bubble.Sort(unsorted);

            Assert.That(unsorted, Is.EqualTo(sorted));
        }

        [Test]
        public void ThrowExceptionWhenSortNull()
        { 
            Assert.That(() => Bubble.Sort(null), Throws.ArgumentNullException);
        }
    }
}
