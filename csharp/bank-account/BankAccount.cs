using System;
using System.Threading;
public class BankAccount
{
    private static Semaphore _sem = new Semaphore(1, 1);
    private bool IsOpen { get; set;}
    public void Open()
    {
        IsOpen = true;
        Balance = decimal.Zero;
    }

    public void Close()
    {
        IsOpen = false;
    }
    Decimal _balance;
    public decimal Balance
    {
        get
        {
            if (!IsOpen) throw new InvalidOperationException();
            return _balance;
        } 
        private set
        {
            _balance = value;
        }
    }

    public void UpdateBalance(decimal change)
    {
        _sem.WaitOne();
        Balance += change;
        _sem.Release();
    }
}
