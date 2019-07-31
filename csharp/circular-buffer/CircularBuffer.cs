using System;

public class CircularBuffer<T>
{
    private T[] _buffer;
    private int _readStart;
    private int _readEnd;
    private int _numElements;

    public CircularBuffer(int capacity) => _buffer = new T[capacity];
   
    private int IncPtr(int index)  => ((index + 1) % _buffer.Length);
   
    private int DecPtr(int index) =>  ((index + _buffer.Length - 1) % _buffer.Length);
    
    public T Read()
    {
        if (isBufferEmpty())
        {
            throw new InvalidOperationException();
        }
        T tmpData = _buffer[_readStart];
        _readStart = IncPtr(_readStart);
        _numElements--;
        return tmpData;
    }

    public void Write(T value)
    {
        if (isBufferFull())
        {
            throw new InvalidOperationException();
        }
        _buffer[_readEnd] = value;
        _readEnd = IncPtr(_readEnd);
        _numElements++;
    }

    public void Overwrite(T value)
    {
        if (!isBufferFull())
            Write(value);
        else
        {
            _buffer[_readStart] = value;
            _readStart = IncPtr(_readStart);
            _readEnd = IncPtr(_readEnd);
        }
    }

    public void Clear()
    {
        if (!isBufferEmpty())
        {
            _readStart = IncPtr(_readStart);
            _numElements--;
        }
    }

    private bool isBufferEmpty() => _numElements == 0 ? true : false;

    private bool isBufferFull() => (_numElements == _buffer.Length) ? true : false;

}
