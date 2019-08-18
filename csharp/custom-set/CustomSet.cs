using System;

public class CustomSet
{
    readonly int[] values;
    public CustomSet(params int[] values)
    {
        this.values = values;
    }

    public CustomSet Add(int value)
    {
        foreach (int i in this.values)
            if (i == value)
                return this;
        int[] newArray = new int[values.Length+1];
        values.CopyTo(newArray, 0);
        newArray[newArray.Length-1] = value;
        return new CustomSet(newArray);
    }

    public bool Empty()
    {
        return this.values.Length == 0;
    }

    public bool Contains(int value)
    {
        foreach (int i in this.values)
        {
            if (i == value)
                return true;
        }
        return false;
    }

    public bool Subset(CustomSet right)
    {
        // is this a subset of right
        if (this.values.Length == 0) return true;
        if (right.values.Length == 0 && this.values.Length != 0) return false;
        
        int i=0;
        int j=0;
        while (i < right.values.Length)
        {
            if (this.values[j] == right.values[i])
            {
                i++;
                j++;
            }
            else 
            {
                i++;
                if (j != 0)
                {
                    i -=j;
                    j=0;
                }
            }
        }
        return j == this.values.Length;
    }

    public bool Disjoint(CustomSet right)
    {
        if (this.values.Length == 0) return true;
        if (right.values.Length == 0 && this.values.Length != 0) return true;

        foreach (int i in right.values)
            foreach (int j in this.values)
                if (j == i)
                    return false;
        return true;
    }

    public CustomSet Intersection(CustomSet right)
    {
        System.Collections.Generic.List<int> comValues = new  System.Collections.Generic.List<int>();
        foreach (int i in right.values)
            foreach (int j in this.values)
                if (i == j)
                    comValues.Add(i);

        return new CustomSet(comValues.ToArray());
    }

    public CustomSet Difference(CustomSet right)
    {
        if (right.values.Length == 0)
            return new CustomSet(this.values);
        if (this.values.Length == 0)
            return new CustomSet();

        CustomSet tmpSet = this.Intersection(right);
        CustomSet retVal = new CustomSet();
        foreach (int i in this.values)
        {
            if (Array.IndexOf(tmpSet.values, i) == -1)
                retVal = retVal.Add(i);
        }
        return retVal;
    }

    public CustomSet Union(CustomSet right)
    {
        if (this.values.Length == 0 && right.values.Length == 0)
            return new CustomSet();
        else if (this.values.Length == 0)
            return right;
        else if (right.values.Length == 0)
            return this;
        CustomSet retVal = new CustomSet(this.values);
        foreach (int i in right.values)
            retVal = retVal.Add(i);
        return retVal;
    }

    public override bool Equals(object obj)
    {
        CustomSet tmpSet = (CustomSet) obj;
        if (tmpSet.values.Length != this.values.Length) return false;
        if (tmpSet.values.Length == 0 && this.values.Length == 0) return true;
        Array left = Array.CreateInstance(typeof(int), this.values.Length);
        for (int i=0; i < this.values.Length; i++)
            left.SetValue(this.values[i], i);
        Array.Sort(left);
        Array right = Array.CreateInstance(typeof(int), tmpSet.values.Length);
        for (int i=0; i < tmpSet.values.Length; i++)
            right.SetValue(tmpSet.values[i], i);
        Array.Sort(right);

        for (int i=0; i < this.values.Length; i++)
            if (!left.GetValue(i).Equals(right.GetValue(i)))
                return false;
        return true;
    }

    public override int GetHashCode()
    {
        return this.values.Length + this.values.GetHashCode();
    }
}