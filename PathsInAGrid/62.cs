// 62. Unique Paths
// https://leetcode.com/problems/unique-paths/

public class Solution {
    public int UniquePaths(int m, int n) {
        int[,] dp = new int[m, n];

        for (var i = 0; i < m; i++) {
            dp[i, 0] = 1;
        }

        for (var i = 0; i < n; i++) {
            dp[0, i] = 1;
        }

        for (var i = 1; i < m; i++) {
            for (var j = 1; j < n; j++) {
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }

        return dp[m - 1, n - 1];
    }
}