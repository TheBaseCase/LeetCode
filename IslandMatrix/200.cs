// 200. Number of Islands
// https://leetcode.com/problems/number-of-islands/
public class Solution
{
    int nr;
    int nc;

    public int NumIslands(char[][] grid)
    {
        nr = grid.Length;
        nc = grid[0].Length;

        int totalIsland = 0;

        for (int i = 0; i < nr; i++)
        {
            for (int j = 0; j < nc; j++)
            {
                if (grid[i][j] == '1')
                {
                    totalIsland++;
                    findIsland(grid, i, j);
                }
            }
        }
        return totalIsland;
    }

    public void findIsland(char[][] grid, int i, int j)
    {
        if (isValidCell(grid, i, j))
        {
            grid[i][j] = '0';
            findIsland(grid, i + 1, j);
            findIsland(grid, i - 1, j);
            findIsland(grid, i, j + 1);
            findIsland(grid, i, j - 1);
        }
    }

    private bool isValidCell(char[][] grid, int i, int j)
    {
        return i >= 0 && i < nr && j >= 0 && j < nc && grid[i][j] == '1';
    }
}
