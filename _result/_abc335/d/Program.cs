using System.Security;
using Library;
using Microsoft.VisualBasic.CompilerServices;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        var n = io.ReadInt();
        var grid = new string[n, n];
        var c = 0;
        var r = 0;
        var p = 1;

            Func<char, (int,int), (int, int)> GetNextPoint = delegate(char dir, (int, int) cp)
            {
                var nr = cp.Item1;
                var nc = cp.Item2;
                return dir switch
                {
                    'R' => (nr, nc+1),
                    'D' => (nr+1, nc),
                    'L' => (nr, nc-1),
                    'U' => (nr-1, nc),
                };
            };

            Func<int, int, bool> isWall = delegate(int row, int col)
            {
                return row < 0 || row > n - 1 || col < 0 || col > n - 1 || !string.IsNullOrEmpty(grid[row, col]);
            };
        
        var dir = 'R';
        while (c != n/2 || r != n/2)
        {
            if (isWall(r,c))
            {
                break;
            }
            grid[r, c] = p.ToString();
            p++;
            (var nr, var nc) = GetNextPoint(dir, (r, c));
            if (isWall(nr,nc))
            {
                dir = dir switch
                {
                    'R' => 'D',
                    'D' => 'L',
                    'L' => 'U',
                    'U' => 'R',
                    _ => 'D'
                };
                (nr, nc) = GetNextPoint(dir, (r, c));
            }

            r = nr;
            c = nc;
        }

        grid[n / 2, n / 2] = "T";

        io.Write2DArray(grid);
    }
}
