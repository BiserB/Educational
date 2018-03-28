
using System;
using System.Collections;
using System.Collections.Generic;

public class MyLinkedList<T> : IEnumerable<T>
{    
    public class Node
    {
        public Node(T data)
        {
            Data = data;
            Next = null;
        }

        public Node Next;
        public T Data;
    }

    public Node Head { get; private set; }
    public int Count { get; private set; }

    // Insert data at the end 

    public void Add(T element)
    {
        Node newNode = new Node(element);
        if (this.Head == null)
        {
            this.Head = newNode;
            Count++;
        }
        else
        {
            Node lastNode = GetLastNode();
            lastNode.Next = newNode;
            Count++;
        }
    }

    private Node GetLastNode()
    {
        Node lastNode = this.Head;

        while (lastNode.Next != null)
        {
            lastNode = lastNode.Next;
        }
        return lastNode;
    }

    // Remove the first occurrence of the item starting at the beginning

    public void Remove(T element)
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Invalid operation");
        }

        Node previousHead = null;
        Node currentHead = this.Head;
        

        while (currentHead != null)
        {
            Node nextHead = currentHead.Next;

            if (currentHead.Data.Equals(element))
            {
                if (previousHead != null)
                {
                    previousHead.Next = nextHead;
                }
                else
                {
                    this.Head = nextHead;                    
                }
                Count--;
                break;
            }

            previousHead = currentHead;
            currentHead = nextHead;
        }
        
        
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = this.Head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
