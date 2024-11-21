// https://leetcode.com/problems/path-with-maximum-gold/
public class Solution {
    public int GetMaximumGold(int[][] grid) {
        int max = 0;

        for (var i = 0; i < grid.Length; i++) {
            for (var j = 0; j < grid[0].Length; j++) {
                if (grid[i][j] != 0) max = Math.Max(max, DFS(grid, i, j));
            }
        }
        return max;
    }

    private int DFS(int[][] grid, int i, int j) {
        if (!isValid(grid, i, j)) return 0;

        int temp = grid[i][j];
        grid[i][j] = 0;
        var max = 0;

        max = Math.Max(max, DFS(grid, i + 1, j)); // Down
        max = Math.Max(max, DFS(grid, i - 1, j)); // Up
        max = Math.Max(max, DFS(grid, i, j + 1)); // Right
        max = Math.Max(max, DFS(grid, i, j - 1)); // Left

        grid[i][j] = temp;

        return grid[i][j] + max;
    }

    private bool isValid(int[][] grid, int i, int j) {
        return i >= 0 && i < grid.Length && j >= 0 && j < grid[0].Length && grid[i][j] > 0;
    }
}
