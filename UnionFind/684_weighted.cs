// 684. Redundant Connection
// https://leetcode.com/problems/redundant-connection
public class Solution {
    int[] parent;
    int[] rank;
    public int[] FindRedundantConnection(int[][] edges) {
        parent = new int[edges.Length + 1];
        rank = new int[edges.Length + 1];
        var res = new List<int[]>();

        for (var i = 1; i < parent.Length; i++) {
            parent[i] = i;
        }

        foreach (var edge in edges) {
            if (findParent(edge[0]) != findParent(edge[1])) {
                union(edge[0], edge[1]);
            }
            else {
                res.Add(edge);
            }
        }
        return res[res.Count - 1];
    }
    private int findParent(int x) {
        if (parent[x] != x) {
            parent[x] = findParent(parent[x]);
        }
        return parent[x];
    }
    private void union(int x, int y) {
        var xParent = findParent(x);
        var yParent = findParent(y);
        if (rank[xParent] <= rank[yParent]) {
            parent[xParent] = yParent;
            if (rank[xParent] == rank[yParent]) {
                rank[yParent]++;
            }
        } else {
            parent[yParent] = xParent;
        }
    }
}
