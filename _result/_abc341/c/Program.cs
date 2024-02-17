using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
        (var h, var w, var n) = (io.ReadInt(), io.ReadInt(), io.ReadInt());
        var instructions = io.ReadString();
        var grid = new string[h];
        for (int i = 0; i < h; i++)
        {
            grid[i] = io.ReadString();
        }
        var possiblePositions = 0;
        for (int i = 1; i < h - 1; i++) {
            for (int j = 1; j < w - 1; j++) {
                if (grid[i][j] == '.') {
                    if (IsValidStartingPosition(i, j, instructions, grid)) {
                        possiblePositions++;
                    }
                }
            }
        }

        io.WriteLine(possiblePositions);
    }
    
    static bool IsValidStartingPosition(int startX, int startY, string instructions, string[] grid) {
        foreach (char move in instructions) {
            switch (move) {
                case 'L':
                    startY--;
                    break;
                case 'R':
                    startY++;
                    break;
                case 'U':
                    startX--;
                    break;
                case 'D':
                    startX++;
                    break;
            }
            if (startX < 0 || startY < 0 || startX >= grid.Length || startY >= grid[0].Length || grid[startX][startY] == '#') {
                return false;
            }
        }
        return true;
    }
}
