// 1011. Capacity To Ship Packages Within D Days
// https://leetcode.com/problems/capacity-to-ship-packages-within-d-days

public class Solution {
    public int ShipWithinDays(int[] weights, int days) {
        int lo = weights.Max();
        int hi = weights.Sum();
        int res = -1;

        while (lo <= hi) {
            int mid = lo + (hi - lo) / 2;
            if (canShipInDays(weights, mid, days)) {
                res = mid;
                hi = mid - 1;
            } else {
                lo = mid + 1;
            }
        }
        return res;
    }

    private bool canShipInDays(int[] weights, int capacity, int days) {
        int need_days = 1;
        int sum = 0;

        foreach (var weight in weights) {
            sum += weight;
            if (sum > capacity) {
                need_days++;
                sum = weight;
            }
            if (need_days > days) return false;
        }
        return true;
    }
}
