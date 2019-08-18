using System;

public class Deque<T>
{
    private class Node<T> 
    {
        public Node<T> prevNode = null;
        public Node<T> nextNode = null;
        public T value;

        public Node(T val)
        {
            value = val;
        }
    }
    private Node<T> head = null;
    public void Push(T value)
    {
        if (head == null)
        {
            head = new Node<T>(value);
            head.nextNode = head;
            head.prevNode = head;
        }
        else
        {
            Node<T> tmpNode = new Node<T>(value);
            tmpNode.nextNode = head.nextNode;
            tmpNode.prevNode = head;
            head.nextNode = tmpNode;
            tmpNode.nextNode.prevNode = tmpNode;
            head = tmpNode;
        }
    }

    public T Pop()
    {
        Node<T> tmpNode = head;
        if (tmpNode.nextNode == tmpNode)
        {
            head = null;
            return tmpNode.value;
        }
        tmpNode.nextNode.prevNode = tmpNode.prevNode;
        tmpNode.prevNode.nextNode = tmpNode.nextNode;
        head = tmpNode.prevNode;
        
        return tmpNode.value;
    }

    public void Unshift(T value)
    {
        if (head == null)
        {
            head = new Node<T>(value);
            head.nextNode = head;
            head.prevNode = head;
        }
        else
        {
            Node<T> tmpNode = new Node<T>(value);
            tmpNode.nextNode = head.nextNode;
            head.nextNode.prevNode = tmpNode;
            head.nextNode = tmpNode;
            tmpNode.prevNode = head;
        }
    }

    public T Shift()
    {
        Node<T> tmpNode = head.nextNode;;
        if (tmpNode.nextNode == tmpNode)
        {
            head = null;
            return tmpNode.value;
        }
        tmpNode.prevNode.nextNode = tmpNode.nextNode;
        tmpNode.nextNode.prevNode = tmpNode.prevNode;
        
        return tmpNode.value;
    }
}