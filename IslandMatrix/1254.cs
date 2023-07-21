// 1254. Number of Closed Islands
// https://leetcode.com/problems/number-of-closed-islands/

public class Solution1254
{
    int nr;
    int nc;

    public int ClosedIsland(int[][] grid)
    {
        nr = grid.Length;
        nc = grid[0].Length;

        int total = 0;

        for (var i = 0; i < nr; i++)
        {
            for (var j = 0; j < nc; j++)
            {
                if (isEdgeCell(grid, i, j) && grid[i][j] == 0)
                {
                    visitCell(grid, i, j);
                }
            }
        }

        for (var i = 0; i < nr; i++)
        {
            for (var j = 0; j < nc; j++)
            {
                if (grid[i][j] == 0)
                {
                    total++;
                    visitCell(grid, i, j);
                }
            }
        }
        return total;
    }

    private void visitCell(int[][] grid, int i, int j)
    {
        if (isValidCell(grid, i, j))
        {
            grid[i][j] = 1;
            visitCell(grid, i + 1, j);
            visitCell(grid, i - 1, j);
            visitCell(grid, i, j + 1);
            visitCell(grid, i, j - 1);
        }
    }

    private bool isEdgeCell(int[][] grid, int i, int j)
    {
        return i == 0 || i == nr - 1 || j == 0 || j == nc - 1;
    }

    private bool isValidCell(int[][] grid, int i, int j)
    {
        return i >= 0 && i < nr && j >= 0 && j < nc && grid[i][j] == 0;
    }
}
