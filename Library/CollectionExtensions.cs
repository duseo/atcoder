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
}