// 300. Longest Increasing Subsequence
// https://leetcode.com/problems/longest-increasing-subsequence/

public class Solution {
    public int LengthOfLIS(int[] nums) {
        var dp = new int[nums.Length];
        Array.Fill(dp, 1);

        for (var i = 1; i < nums.Length; i++) {
            for (var j = 0; j < i; j++) {
                if (nums[j] < nums[i]) {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }
        return dp.Max();
    }
}