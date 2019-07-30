using System;

public class CircularBuffer<T>
{
    private T[] _buffer;
    private int _readStart = -1;
    private int _readEnd = -1;


    public CircularBuffer(int capacity)
    {
        _buffer = new T[capacity];
    }
    

    public T Read()
    {
        if (_readStart == -1 || _readEnd == -1)
            throw new InvalidOperationException(); // nothing to read
        T retVal = _buffer[_readStart];
        _readStart = IncWrap(_readStart);
        if (isBufferFull())
        {
            _readStart = -1;
            _readEnd = -1;
        }
        return retVal;
    }

    private int IncWrap(int index) => index == _buffer.Length-1 ? 0 : index + 1;
    private bool isBufferFull()
    {
        if (_readEnd == -1 || _readStart == -1)
            return false;
        if (_readEnd == _readStart)
            return false;
        int i = _readStart;
        int j = 1;
        while (i != _readEnd)
        {
            i = IncWrap(i);
            j++;
        }
        if (j == _buffer.Length)
        {
            return true;
        }
        else
            return false;

    }

    public void Write(T value)
    {
        if (_readStart == -1)
        {
            _readStart = 0;
            _readEnd = 0;
        }
        else
            _readEnd = IncWrap(_readEnd);
        if (isBufferFull())
            throw new InvalidOperationException(); // buffer full
        
        _buffer[_readEnd] = value;
    }

    public void Overwrite(T value)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public void Clear()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
