using Library;

class AtCoder
{
    private static int[,] grid = new int[9,9];
    static bool IsSudoku(int xul, int yul, int xlr, int ylr)
    {
        var set = new HashSet<int>();
        for (int i = xul; i <= xlr; i++)
        {
            for (int j = yul; j <= ylr; j++)
            {
                var tmp = grid[i, j];
                if (set.Contains(tmp))
                {
                    return false;
                }

                set.Add(tmp);
            } 
        }

        return true;

    }
    
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                grid[i, j] = io.ReadInt();
            }
        }

        var res = true;
        var set = new HashSet<int>();
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                var tmp = grid[i, j];
                if (set.Contains(tmp))
                {
                    res = false;
                }

                set.Add(tmp);
            }
            set = new HashSet<int>();
        }
        
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                var tmp = grid[j, i];
                if (set.Contains(tmp))
                {
                    res = false;
                }
                set.Add(tmp);
            }
            set = new HashSet<int>();
        }

        res = res && IsSudoku(0, 0, 2, 2) && IsSudoku(0, 3, 2, 5) && IsSudoku(0, 6, 2, 8)
              && IsSudoku(3, 0, 5, 2) && IsSudoku(3, 3, 5, 5) && IsSudoku(3, 6, 5, 8)
              && IsSudoku(6, 0, 8, 2) && IsSudoku(6, 3, 8, 5) && IsSudoku(6, 6, 8, 8);
        
        io.WriteBool(res);

    }
}
