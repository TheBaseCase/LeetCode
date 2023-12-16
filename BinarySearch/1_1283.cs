// 1283. Find the Smallest Divisor Given a Threshold
// https://leetcode.com/problems/find-the-smallest-divisor-given-a-threshold

public class Solution {
    public int SmallestDivisor(int[] nums, int threshold) {
        int lo = 1;
        int hi = nums.Max();
        int res = -1;

        while (lo <= hi) {
            int mid = lo + (hi - lo) / 2;
            if (isLessThanThreshold(nums, mid, threshold)) {
                res = mid;
                hi = mid - 1;
            } else {
                lo = mid + 1;
            }
        }
        return res;
    }

    private bool isLessThanThreshold(int[] nums, int divisor, int threshold) {
        int sum = 0;
        foreach (var num in nums) {
            sum += (int)Math.Ceiling(1.0 * num / divisor);
        }
        return sum <= threshold;
    }
}
