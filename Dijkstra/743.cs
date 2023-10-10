// 743. Network Delay Time
// https://leetcode.com/problems/network-delay-time

public class Solution
{
    public int NetworkDelayTime(int[][] times, int n, int k) {
        Dictionary<int, List<(int node, int dist)>> adj = new();
        PriorityQueue<(int node, int dist), int> heap = new();

        int[] minDist = new int[n + 1];
        Array.Fill(minDist, -1);
        minDist[0] = 0;

        for (var i = 1; i <= n; i++) {
            adj[i] = new List<(int node, int dist)>();
        }

        foreach (var edge in times) {
            adj[edge[0]].Add((edge[1], edge[2]));
        }

        heap.Enqueue((k, 0), 0);

        while (heap.Count > 0) {
            var curr = heap.Dequeue(); 
            if (minDist[curr.node] != -1) continue;
            minDist[curr.node] = curr.dist;
            foreach (var neigh in adj[curr.node]) {
                if (minDist[neigh.node] == -1 )
                    heap.Enqueue((neigh.node, curr.dist + neigh.dist), curr.dist + neigh.dist);
            }
        }

        return minDist.Min() == -1 ? -1 : minDist.Max();
    }
}


