using System.ComponentModel.DataAnnotations;
//using Dumpify;

namespace Library;

public class SegmentTree<T>
{
    private T[] _data;
    private readonly IMonoid<T> _monoid;
    private int _size;

    // Dumpify
    public T[] Data => _data;
    
    public SegmentTree(int n, IMonoid<T> monoid)
    {
        _monoid = monoid;
        _size = 1;
        while (_size < n)
        {
            _size *= 2;
        }

        _data = new T[_size * 2];

        for (int i = 0; i < _size * 2; i++)
        {
            _data[i] = _monoid.IdentityElement;
        }
    }

    /// <summary>
    /// Sets the value at position <paramref name="index"/> to <paramref name="value"/>
    /// </summary>
    public void Update(int index, T value)
    {
        // The segment tree has the following structure:
        // -----1-----
        // --2-----3--
        // -4-5---6-7-
        // ...which is why + Length - 1 is necessary (the values are updated in the lowest row)
        // In this example, size = 4 
        index = index + _size - 1;
        _data[index] = value;

        while (index >= 2)
        {
            index /= 2;
            _data[index] = _monoid.Operate(_data[index * 2], _data[index * 2 + 1]);
        }
    }

    public T Query(int rangeStart, int rangeEnd)
    {
        return Query(rangeStart, rangeEnd, 1, _size + 1, 1);
    }

    //Fehler
    private T Query(int l, int r, int a, int b, int u)
    {
        if (r <= a || b <= l)
        {
            return _monoid.IdentityElement;
        }

        if (l <= a && b <= r)
        {
            return _data[u];
        }

        int m = (a + b) / 2;
        var AnswerL = Query(l, r, a, m, u * 2);
        var AnswerR = Query(l, r, m, b, u * 2 + 1);
        return _monoid.Operate(AnswerL, AnswerR);
    }
    
    public void PrintTree()
    {
        var levels = new List<List<string>>();
        CollectLevels(1, 0, _size, 0, levels);

        for (int i = 0; i < levels.Count; i++)
        {
            //levels[i].Dump();
        }
    }

    private void CollectLevels(int index, int start, int end, int depth, List<List<string>> levels)
    {
        if (index >= _data.Length) return;

        while (levels.Count <= depth)
        {
            levels.Add(new List<string>());
        }

        int mid = (start + end) / 2;
        if (index * 2 < _data.Length) CollectLevels(index * 2, start, mid, depth + 1, levels);

        levels[depth].Add($"[{start}, {end}):{_data[index]}");

        if (index * 2 + 1 < _data.Length) CollectLevels(index * 2 + 1, mid, end, depth + 1, levels);
    }
    

}