
using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>

{
    private List<int> numbers;

    public Lake(params int[] nums)
    {
        numbers = new List<int>(nums);
    }

    public IEnumerator<int> GetEnumerator()
    {
        List<int> oddPossitions = new List<int>();
        List<int> evenPossitions = new List<int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (i % 2 != 0)
            {
                oddPossitions.Add(numbers[i]);
            }
            else
            {
                evenPossitions.Add(numbers[i]);
            }
        }

        foreach (int number in evenPossitions)
        {
            yield return number;
        }

        oddPossitions.Reverse();

        foreach (int number in oddPossitions)
        {
            yield return number;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }    
}
