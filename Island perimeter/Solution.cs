public class Solution
{
    public int IslandPerimeter(int[,] grid)
    {
        if (grid == null || grid.GetLength(0) == 0) { return 0; }

        var r = 0;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] == 0) { continue; }

                if (i == 0 || i > 0 && grid[i - 1, j] == 0) { r++; }
                if (i == grid.GetLength(0) - 1 || i < grid.GetLength(0) - 1 && grid[i + 1, j] == 0) { r++; }
                if (j == 0 || j > 0 && grid[i, j - 1] == 0) { r++; }
                if (j == grid.GetLength(1) - 1 || j < grid.GetLength(1) - 1 && grid[i, j + 1] == 0) { r++; }
            }
        }

        return r;
    }
}