// 875. Koko Eating Bananas
// https://leetcode.com/problems/koko-eating-bananas/

public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int lo = 1;
        int hi = piles.Max();
        int res = 0;

        while (lo <= hi) {
            int mid = lo + (hi - lo) / 2;
            if (canFinish(piles, mid, h)) {
                res = mid;
                hi = mid - 1;
            } else {
                lo = mid + 1;
            }
        }
        return res;
    }

    public bool canFinish(int[] piles, int k, int h) {
        int count = 0;
        foreach (var pile in piles) {
            count += pile / k;
            if (pile % k > 0) count++;
            if (count > h) return false;
        }
        return true;
    }
}
