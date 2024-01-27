using System.Runtime.CompilerServices;

namespace Library;

public static class CollectionExtensions
{
    private class ArrayWrapper<T>
    {
#pragma warning disable CS0649
#pragma warning disable CS8618
        public T[] Array;
#pragma warning restore CS0649
#pragma warning restore CS8618
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<T> AsSpan<T>(this List<T> list)
    {
        return Unsafe.As<ArrayWrapper<T>>(list).Array.AsSpan(0, list.Count);
    }

    public static void Fill<T>(this T[,] matrix, T value)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i,j] = value;
            }
        }
    }
    
    public static void Fill<T>(this T[] array, T value)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            array[i] = value;
        }
    }

    public static string Join<T>(this List<T> list, char separator)
    {
        return string.Join(separator, list);
    }

    public static List<string> GroupByPattern(this string s, string pattern, string pattern2)
    {
        s = s.Replace(pattern, $"{pattern[0]} {pattern[1]}");
        s = s.Replace(pattern2, $"{pattern2[0]} {pattern2[1]}");
        return s.Split(' ').ToList();
    }

    public static int GetResult(this string s, int k)
    {
        var res = int.MaxValue;
        var l = s.Split('x');
        foreach (var element in l)
        {
            if (element.Length >=k)
            {
                res = Math.Min(res, element.GetMinCount(k));
            } 
        }

        return res;
    }

    public static int GetMinCount(this string s, int k)
    {
        var res = 0;
        var dp = new int[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'o')
            {
                for (int j = 0; j < k; j++)
                {
                    if (i+j < s.Length)
                    {
                        dp[i + j]++;
                    }
                } 
            }    
        }
        
        for (int i = 0; i < s.Length; i++)
        {
            res = Math.Max(res, dp[i]);
        }

        return k - res;
    }
}