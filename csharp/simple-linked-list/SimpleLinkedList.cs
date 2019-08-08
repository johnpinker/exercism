using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{

    private SimpleLinkedList<T> _next { get; set; } = null;
    public SimpleLinkedList(T value) => this.Value = value;


    public SimpleLinkedList(IEnumerable<T> values)
    {
        this.Value = values.ElementAt(0);
        SimpleLinkedList<T> curr = this;
        SimpleLinkedList<T> newItem;
        for (int i=1; i< values.Count(); i++)
        {
            newItem = new SimpleLinkedList<T>(values.ElementAt(i));
            curr._next = newItem;
            curr = newItem;
        }
    }

    public T Value { get; private set; }

    public SimpleLinkedList<T> Next { get => this._next; }

    public SimpleLinkedList<T> Add(T value)
    {
        SimpleLinkedList<T> tmpLL = new SimpleLinkedList<T>(value);
        this._next = tmpLL;
        return this;
    }

    public IEnumerator<T> GetEnumerator()
    {
        SimpleLinkedList<T> tmpLL = this;
        while (tmpLL != null)
        {
            yield return tmpLL.Value;
            tmpLL = tmpLL._next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


}