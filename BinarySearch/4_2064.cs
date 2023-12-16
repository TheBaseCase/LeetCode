// 2064. Minimized Maximum of Products Distributed to Any Store
// https://leetcode.com/problems/minimized-maximum-of-products-distributed-to-any-store

public class Solution {
    public int MinimizedMaximum(int n, int[] quantities) {
        int lo = 1;
        int hi = quantities.Max();
        int res = -1;

        while (lo <= hi) {
            int mid = lo + (hi - lo) / 2;
            if (canWork(quantities, mid, n)) {
                res = mid;
                hi = mid - 1;
            } else {
                lo = mid + 1;
            }
        }
        return res;
    }

    private bool canWork(int[] quantities, int item, int total_stores) {
        int need_store = 0;
        foreach(var quantity in quantities) {
            need_store += (quantity - 1)/item + 1;     
            if (need_store > total_stores) return false;
        }

        return true;
    }
}
