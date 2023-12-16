// 1482. Minimum Number of Days to Make m Bouquets
// https://leetcode.com/problems/minimum-number-of-days-to-make-m-bouquets

public class Solution {
    public int MinDays(int[] bloomDay, int m, int k) {
        int lo = bloomDay.Min();
        int hi = bloomDay.Max();
        int res = -1;

        while (lo <= hi) {
            int mid = lo + (hi - lo) / 2;
            if (canGetBouquets(bloomDay, mid, m, k)) {
                res = mid;
                hi = mid - 1;
            } else {
                lo = mid + 1;
            }
        }
        return res;
    }

    private bool canGetBouquets(int[] flowers, int day, int num_bouquets, int adjacent_flowers) {
        int flowers_picked = 0;
        for (var i = 0; i < flowers.Length; i++) {
            if (flowers[i] <= day) {
                flowers_picked++;
            } else {
                flowers_picked = 0;
            }

            if (flowers_picked == adjacent_flowers) {
                flowers_picked = 0;
                num_bouquets--;
            }
            if (num_bouquets == 0) return true;
        }
        return false;
    }
}
