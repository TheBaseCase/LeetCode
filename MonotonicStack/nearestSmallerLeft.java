// Nearest smaller element
// https://practice.geeksforgeeks.org/problems/smallest-number-on-left3403/1

class Solution {

  static List<Integer> leftSmaller(int n, int a[]) {
    Stack<Integer> stack = new Stack<>();
    List<Integer> res = new ArrayList<>();

    for (int i = 0; i < a.length; i++) {
      while (!stack.isEmpty() && stack.peek() >= a[i]) {
        stack.pop();
      }
      res.add(stack.isEmpty() ? -1 : stack.peek());
      stack.push(a[i]);
    }
    
    return res;
  }
}
