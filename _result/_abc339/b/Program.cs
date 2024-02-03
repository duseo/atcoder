using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var h = io.ReadInt();
        var w = io.ReadInt();
        var n = io.ReadInt();

        var res = PaintGrid(h, w, n);

        foreach (var x in res)
        {
           io.WriteLine(x); 
        }

    }
    
    public static string[] PaintGrid(int h, int w, int n)
    {
        char[,] grid = new char[h, w];
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                grid[i, j] = '.';
            }
        }

        int x = 0, y = 0; 
        int direction = 0; 

        for (int step = 0; step < n; step++)
        {
            if (grid[y, x] == '.')
            {
                grid[y, x] = '#';
                direction = (direction + 1) % 4;
            }
            else
            {
                grid[y, x] = '.';
                direction = (direction + 3) % 4;
            }

            switch (direction)
            {
                case 0: y = (y - 1 + h) % h; break; 
                case 1: x = (x + 1) % w; break; 
                case 2: y = (y + 1) % h; break;
                case 3: x = (x - 1 + w) % w; break;
            }
        }

        string[] result = new string[h];
        for (int i = 0; i < h; i++)
        {
            char[] row = new char[w];
            for (int j = 0; j < w; j++)
            {
                row[j] = grid[i, j];
            }
            result[i] = new string(row);
        }

        return result;
    }
}
