using Library;

class AtCoder
{
    private static readonly int[] dx = { 0, 0, 1, -1 };
    private static readonly int[] dy = { 1, -1, 0, 0 };

    public static int Solve(string[] grid)
    {
        int n = grid.Length;
        var visited = new HashSet<(int, int, int, int)>();
        var queue = new Queue<(int, int, int, int, int)>();
        int px1 = -1, py1 = -1, px2 = -1, py2 = -1;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 'P')
                {
                    if (px1 == -1)
                    {
                        px1 = i; py1 = j;
                    }
                    else
                    {
                        px2 = i; py2 = j;
                    }
                }
            }
        }

        queue.Enqueue((px1, py1, px2, py2, 0));
        visited.Add((px1, py1, px2, py2));

        while (queue.Count > 0)
        {
            var (x1, y1, x2, y2, moves) = queue.Dequeue();

            if (x1 == x2 && y1 == y2)
            {
                return moves;
            }

            for (int i = 0; i < 4; i++)
            {
                int nx1 = x1 + dx[i], ny1 = y1 + dy[i];
                int nx2 = x2 + dx[i], ny2 = y2 + dy[i];

                if (nx1 < 0 || nx1 >= n || ny1 < 0 || ny1 >= n || grid[nx1][ny1] == '#')
                {
                    nx1 = x1; ny1 = y1;
                }

                if (nx2 < 0 || nx2 >= n || ny2 < 0 || ny2 >= n || grid[nx2][ny2] == '#')
                {
                    nx2 = x2; ny2 = y2;
                }

                if (!visited.Contains((nx1, ny1, nx2, ny2)))
                {
                    queue.Enqueue((nx1, ny1, nx2, ny2, moves + 1));
                    visited.Add((nx1, ny1, nx2, ny2));
                }
            }
        }

        return -1;
    }


    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();

        var grid = new string[n];
        for (int i = 0; i < n; i++)
        {
            grid[i] = io.ReadString();
        }

        int result = Solve(grid);
        io.WriteLine(result);
    }
}
