using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MathtasticVoyage;
public class Queue<T>
{

    private Node<T> _front = null;
    private Node<T> _back;
    private uint _count;
    private bool _empty;


    public Queue() { }
    public Queue(T item)
    {
        Enqueue(item);
    }

    public bool IsEmpty
    {
        get
        {
            return _front == null;
        }
    }

    public uint Count
    {
        get
        {
            return _count;
        }
    }

    public void Enqueue(T item)
    {
        //CREATE NEW NODE & FILL ITS DATA
        Node<T> newNode = new(item);

        if (_front == null)
        {
            _front = newNode;
            _back = newNode;
        }
        else
        {
            _back.Next = newNode;
            _back = _back.Next;
        }//end if

        _count++;
    }

    public T Dequeue()
    {
        T dequeueFront = _front.Data;
        _front = _front.Next;

        _count--;

        return dequeueFront;
    }

    public T Peek()
    {
        T peekFront = _front.Data;
        return peekFront;
    }

    public T PeekRear()
    {
        T peekRear = _back.Data;
        return peekRear;
    }
}
