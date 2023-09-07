// Prim's (MST) : Special Subtree
// https://www.hackerrank.com/challenges/primsmstsub/problem

class Result {    
    static Dictionary<int, List<(int node, int wt)>> adj = new();
    static PriorityQueue<(int node, int wt), int> heap = new();
    static HashSet<int> visited = new();

    public static int prims(int n, List<List<int>> edges, int start) {

        foreach (var edge in edges) {
            if (!adj.ContainsKey(edge[0])) {
                adj[edge[0]] = new List<(int node, int wt)>();
            }
            if (!adj.ContainsKey(edge[1])) {
                adj[edge[1]] = new List<(int node, int wt)>();
            }
            adj[edge[0]].Add((edge[1], edge[2]));
            adj[edge[1]].Add((edge[0], edge[2]));
        }

        heap.Enqueue((start, 0), 0);

        var totalWeight = 0;
        while (heap.Count > 0) {
            var tuple = heap.Dequeue();
            if (visited.Contains(tuple.node)) continue;

            visited.Add(tuple.node);
            totalWeight += tuple.wt;
            
            foreach (var neigh in adj[tuple.node]) {
                if (visited.Contains(neigh.node)) continue;
                heap.Enqueue(neigh, neigh.wt);
            }
        }
        return totalWeight;
    }
}
