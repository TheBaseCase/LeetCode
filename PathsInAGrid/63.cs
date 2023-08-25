// 63. Unique Paths II
// https://leetcode.com/problems/unique-paths-ii/

public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        var nr = obstacleGrid.Length;
        var nc = obstacleGrid[0].Length;
        var dp = new int[nr, nc];

        if (obstacleGrid[0][0] == 1) return 0;
        
        dp[0, 0] = 1;

        for (var c = 1; c < nc; c++) {
            if (obstacleGrid[0][c] == 0)
                dp[0, c] = dp[0, c - 1];
        }

        for (var r = 1; r < nr; r++) {
            if (obstacleGrid[r][0] == 0)
                dp[r, 0] = dp[r - 1, 0];
        }

        for (var r = 1; r < nr; r++) {
            for (var c = 1; c < nc; c++) {
                if (obstacleGrid[r][c] == 0) {
                    dp[r, c] = dp[r - 1, c] + dp[r, c - 1];
                }
            }
        }
        return dp[nr - 1, nc - 1];
    }
}