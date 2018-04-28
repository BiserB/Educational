using System;
using System.Collections.Generic;
using System.Text;

namespace t04_BubbleSort
{
    public static class Bubble
    {        
        public static void Sort(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Argument cannot be null!");
            }

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int index = i;
                Func<bool> indexIsValid = () => index < arr.Length - 1;

                while (indexIsValid() && arr[index] > arr[index + 1])
                {
                    Swap(index, arr);
                    index++;
                }
            }
        }

        private static void Swap(int index, int[]arr)
        {
            int temp = arr[index];
            arr[index] = arr[index + 1];
            arr[index + 1] = temp;
        }
    }
}
