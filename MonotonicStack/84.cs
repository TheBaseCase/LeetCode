// LeetCode 84. Largest Rectangle in Histogram
// https://leetcode.com/problems/largest-rectangle-in-histogram

public class Solution {
    int[] left;
    int[] right;

    public int LargestRectangleArea(int[] heights) {
        left = new int[heights.Length];
        right = new int[heights.Length];
        findSmallerLeft(heights);
        findSmallerRight(heights);

        int max = 0;
        for (var i = 0; i < heights.Length; i++) {
            max = Math.Max(max, heights[i] * (right[i] - left[i] - 1));
        }
        return max;
    }

    public void findSmallerLeft(int[] arr) {
        Stack<(int idx, int val)> stack = new();
        for (var i = 0; i < arr.Length; i++) {
            while (stack.Count > 0 && stack.Peek().val >= arr[i]) {
                stack.Pop();
            }
            left[i] = stack.Count == 0 ? -1 : stack.Peek().idx;
            stack.Push((i, arr[i]));
        }
    }
    public void findSmallerRight(int[] arr) {
        Stack<(int idx, int val)> stack = new();
        for (var i = arr.Length - 1; i >= 0; i--) {
            while (stack.Count > 0 && stack.Peek().val >= arr[i]) {
                stack.Pop();
            }
            right[i] = stack.Count == 0 ? arr.Length : stack.Peek().idx;
            stack.Push((i, arr[i]));
        }
    }
}
