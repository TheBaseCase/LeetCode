// 2316. Count Unreachable Pairs of Nodes in an Undirected Graph
// https://leetcode.com/problems/count-unreachable-pairs-of-nodes-in-an-undirected-graph

public class Solution {
    int[] parent;
    int[] rank;
    public long CountPairs(int n, int[][] edges) {
        parent = new int[n];
        rank = new int[n];
      
        for (var i = 0; i < n; i++) {
            parent[i] = i;
        }
        foreach (var edge in edges) {
            union(edge[0], edge[1]);
        }

        Dictionary <int,int> groups = new();
        for (int i = 0; i < n; i++) {
            int parent = findParent(i);
            groups[parent] = groups.GetValueOrDefault(parent, 0) + 1;
        }

        long res = 0;
        long remaining = n;
        foreach (var group in groups) {
            res += group.Value * (remaining - group.Value);
            remaining -= group.Value;
        }
        return res;
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
