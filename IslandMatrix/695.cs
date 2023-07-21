// 695. Max Area of Island
// https://leetcode.com/problems/max-area-of-island/
public class Solution
{
    int nr;
    int nc;

    public int MaxAreaOfIsland(int[][] grid)
    {
        nr = grid.Length;
        nc = grid[0].Length;

        int maxArea = 0;

        for (int i = 0; i < nr; i++)
        {
            for (int j = 0; j < nc; j++)
            {
                maxArea = Math.Max(maxArea, getArea(grid, i, j));
            }
        }

        return maxArea;
    }

    public int getArea(int[][] grid, int i, int j)
    {
        int area = 0;

        if (isValidCell(grid, i, j))
        {
            grid[i][j] = 0;
            area = 1;
            area += getArea(grid, i - 1, j);
            area += getArea(grid, i + 1, j);
            area += getArea(grid, i, j - 1);
            area += getArea(grid, i, j + 1);
        }
        return area;
    }

    private bool isValidCell(int[][] grid, int i, int j)
    {
        return i >= 0 && i < nr && j >= 0 && j < nc && grid[i][j] == 1;
    }
}
