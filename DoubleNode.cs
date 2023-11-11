using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DoubleNode<T>
{
    public DoubleNode(T data)
    {
        Data = data;
        Previous = null;
        Next = null;
    }
    public T Data { get; set; }
    public DoubleNode<T>? Previous { get; set; }
    public DoubleNode<T>? Next { get; set; }
}