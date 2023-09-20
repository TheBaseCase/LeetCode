// 739. Daily Temperatures
// https://leetcode.com/problems/daily-temperatures

public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {

        int[] res = new int[temperatures.Length];
        Stack<(int temp, int day)> stack = new();

        for (int i = temperatures.Length - 1; i >= 0; i--) {
            while (stack.Count > 0 && stack.Peek().temp <= temperatures[i]) {
                stack.Pop();
            }
            res[i] = stack.Count == 0 ? 0 : stack.Peek().day - i;
            stack.Push((temperatures[i], i));
        }
        return res;
    }
}
