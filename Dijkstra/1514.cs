// 1514. Path with Maximum Probability
// https://leetcode.com/problems/path-with-maximum-probability

public class Solution
{
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node) {
        Dictionary<int, List<(int node, double wt)>> adj = new();
        PriorityQueue<(int node, double wt), double> heap = new();
        var maxProb = new double[n];
        Array.Fill(maxProb, -1.0);

        for (var i = 0; i < n; i++) {
            adj[i] = new List<(int node, double wt)>();
        }

        for (var i = 0; i < edges.Length; i++) {
            adj[edges[i][0]].Add((edges[i][1], succProb[i]));
            adj[edges[i][1]].Add((edges[i][0], succProb[i]));
        }

        heap.Enqueue((start_node, 1), 0.0);

        while (heap.Count > 0) {
            var curr = heap.Dequeue();
            if (maxProb[curr.node] != -1.0) continue;
            maxProb[curr.node] = curr.wt;
            if (curr.node == end_node) return curr.wt;
           
            foreach (var neigh in adj[curr.node]) {
                if (maxProb[neigh.node] == -1.0) {
                    heap.Enqueue((neigh.node, curr.wt * neigh.wt), curr.wt * neigh.wt * -1);
                }
            }
        }

        return 0.0;
    }
}
