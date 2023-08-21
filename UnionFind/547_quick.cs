// 547. Number of Provinces
// https://leetcode.com/problems/number-of-provinces
public class Solution {
    int[] parent;
    public int FindCircleNum(int[][] isConnected)
    {
        parent = new int[isConnected.Length];
        for (var i = 0; i < isConnected.Length; i++) {
            parent[i] = i;
        }

        for (var i = 0; i < isConnected.Length; i++) {
            for (var j = 0; j < isConnected[0].Length; j++) {
                if (isConnected[i][j] == 1) {
                    union(i, j);
                }
            }
        }

        int count = 0;
        for (var i = 0; i < parent.Length; i++) {
            if (findParent(i) == i) count++;
        }
        return count;
    }

    private int findParent(int x) {
        if (parent[x] != x) {
            parent[x] = findParent(parent[x]);
        }
        return parent[x];
    }
    private void union(int x, int y) {
        parent[findParent(x)] = parent[findParent(y)];
    }
}
