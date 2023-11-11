using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CustomStringDeque
{
    DoubleNode<string> Head;
    public CustomStringDeque(string data)
    {
        Head = new(data);
    }
    public List<int> Search(string data)
    {
        List<int> output = new();
        DoubleNode<string>? current = Head;
        if (Head.Data == data)
        {
            output.Add(0);
        }
        int index = 0;
        while (current.Next != null)
        {
            current = current.Next;
            index++;
            if (current.Data == data)
            {
                output.Add(index);
            }
        }
        current = Head;
        index = 0;
        while (current.Previous != null)
        {
            index--;
            current = current.Previous;
            if (current.Data == data)
            {
                output.Insert(0, index);
            }
        }
        return output;
    }
    public void AddBegin(string data)
    {
        DoubleNode<string> current = Head;
        while (current.Previous != null)
        {
            current = current.Previous;
        }
        current.Previous = new(data);
        current.Previous.Next = current;
    }
    public void AddEnd(string data)
    {
        DoubleNode<string> current = Head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = new(data);
        current.Next.Previous = current;
    }
    private void RemoveAt(int index)
    {
        if (index == 0 && Head.Previous == null && Head.Next == null)
        {
            throw new Exception("can't remove Head");
        }
        DoubleNode<string> current = Head;
        for (int i = 0; i < -index; i++)
        {
            if (current.Previous == null)
            {
                throw new Exception("left out of bounds");
            }
            current = current.Previous;
        }
        for (int i = 0; i < index; i++)
        {
            if (current.Next == null)
            {
                throw new Exception("left out of bounds");
            }
            current = current.Next;
        }
        if (current.Previous != null)
        {
            if (index == 0)
            {
                Head = current.Previous;
            }
            current.Previous.Next = current.Next;
            return;
        }
        if (current.Next != null)
        {
            if (index == 0)
            {
                Head = current.Next;
            }
            current.Next.Previous = current.Previous;
        }
    }
    public void Remove(string data)
    {
        int index = 0;
        DoubleNode<string> current = Head;
        while (current.Next != null)
        {
            current = current.Next;
            index++;
        }
        for (int i = index; i > 0; i--)
        {
            if (current.Data == data)
            {
                RemoveAt(i);
            }
            current = current.Previous;
        }
        index = 0;
        current = Head;
        while (current.Previous != null)
        {
            current = current.Previous;
            index++;
        }
        for (int i = index; i > 0; i--)
        {
            if (current.Data == data)
            {
                RemoveAt(-i);
            }
            current = current.Next;
        }
        if (Head.Data == data)
        {
            RemoveAt(0);
        }
    }
    public void RemoveBegin()
    {
        DoubleNode<string> current = Head;
        int index = 0;
        while (current.Previous != null)
        {
            current = current.Previous;
            index--;
        }
        RemoveAt(index);
    }
    public void RemoveEnd()
    {
        DoubleNode<string> current = Head;
        int index = 0;
        while (current.Next != null)
        {
            current = current.Next;
            index++;
        }
        RemoveAt(index);
    }
    public void Print()
    {
        DoubleNode<string> current = Head;
        int index = 0;
        while (current.Previous != null)
        {
            current = current.Previous;
            index--;
        }
        Console.Write("[ ");
        while (current.Next != null)
        {
            if (index == 0)
            {
                Console.Write($"<{current.Data}> ");
            }
            else
            {
                Console.Write($"{current.Data} ");
            }
            current = current.Next;
            index++;
        }
        if (index == 0)
        {
            Console.WriteLine($"<{current.Data}> ]");
        }
        else
        {
            Console.WriteLine($"{current.Data} ]");
        }
    }
}