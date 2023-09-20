// LeetCode 1475. Final Prices With a Special Discount in a Shop
// https://leetcode.com/problems/final-prices-with-a-special-discount-in-a-shop/

public class Solution {
    public int[] FinalPrices(int[] prices){
        Stack<int> stack = new();
        var res = new int[prices.Length];

        for (var i = prices.Length - 1; i >= 0; i--) {
            while (stack.Count  > 0 && stack.Peek() > prices[i]) {
                stack.Pop();
            }
            res[i] = stack.Count == 0 ? prices[i] : prices[i] - stack.Peek();
            stack.Push(prices[i]);
        }

        return res;
    }
}
