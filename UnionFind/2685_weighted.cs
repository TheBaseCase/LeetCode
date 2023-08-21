// 2685. Count the Number of Complete Components
// https://leetcode.com/problems/count-the-number-of-complete-components

public class Solution {
    Dictionary<int, List<int>> adj = new();
    int[] parent;
    int[] rank;
    public int CountCompleteComponents(int n, int[][] edges) {
        parent = new int[n];
        rank = new int[n];
        Dictionary<int, List<int>> groups = new();
        
        for (var i = 0; i < n; i++) {
            parent[i] = i;
            adj[i] = new List<int>();
        }

        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
            union(edge[0], edge[1]);
        }

        int comp = 0;

        for (var i = 0; i < parent.Length; i++) {
            var parent = findParent(i);
            if (!groups.ContainsKey(parent)) {
                groups[parent] = new List<int>();
            }
            groups[parent].Add(i);
        }

        foreach (var group in groups) {
            if (isComplete(group.Value)) comp++;
        }
        return comp;
    }

    private bool isComplete(List<int> vertices) {
        foreach (var v in vertices) {
            if (adj[v].Count != vertices.Count - 1) return false;
        }
        return true;
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