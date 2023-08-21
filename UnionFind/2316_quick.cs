// 2316. Count Unreachable Pairs of Nodes in an Undirected Graph
// https://leetcode.com/problems/count-unreachable-pairs-of-nodes-in-an-undirected-graph

public class Solution {
    int[] parent;
    public long CountPairs(int n, int[][] edges) {
        parent = new int[n];
      
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

    private void union(int x, int y) {
        parent[findParent(x)] = parent[findParent(y)];
    }
    private int findParent(int x) {
        if (parent[x] != x) {
            parent[x] = findParent(parent[x]);
        }
        return parent[x];
    }
}
