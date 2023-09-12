// 673. Number of Longest Increasing Subsequence
// https://leetcode.com/problems/number-of-longest-increasing-subsequence

public class Solution {
    public int FindNumberOfLIS(int[] nums) {
        var dp = new int[nums.Length];
        Array.Fill(dp, 1);

        var counts = new int[nums.Length];
        Array.Fill(counts, 1);

        for (var i = 1; i < nums.Length; i++) {
            for (var j = 0; j < i; j++) {
                if (nums[j] < nums[i]) {
                    if (dp[j] + 1 == dp[i]) {
                        counts[i] += counts[j];
                    }
                    else if (dp[j] + 1 > dp[i]) {
                        dp[i] = dp[j] + 1;
                        counts[i] = counts[j];
                    }
                }
            }
        }

        int max = dp.Max();
        int res = 0;
        for (var i = 0; i < dp.Length; i++) {
            if (dp[i] == max) res += counts[i];
        }
        return res;
    }
}
