
using System.Collections.Generic;

public class CountingList<T>
{
    public Dictionary<T, int> items;

    public void Add(T key)
    {
        if (items.ContainsKey(key))
            items[key]++;
        else
            items.Add(key, 1);
    }

    public int Count(T key)
    {
        if (items.ContainsKey(key))
            return items[key];
        else
            return 0;
    }
}