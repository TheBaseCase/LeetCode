public class Solution {
    int[] parent;
    int[] rank;
    // n: number of nodes
    // edges: array of edges, in the form [a, b], where 'a' and 'b' are nodes, there is an edge between 'a' and 'b'
    public void UnionFindWeighte(int n, int[][] edges) {
        parent = new int[n];
        rank = new int[n];

        for (var i = 1; i < parent.Length; i++) {
            parent[i] = i;
        }
        foreach (var edge in edges)
        {
            union(edge[0], edge[1]);
        }
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