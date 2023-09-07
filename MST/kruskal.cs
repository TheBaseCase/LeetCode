// kruskal (MST): Really Special Subtree
// https://www.hackerrank.com/challenges/kruskalmstrsub/problem
class Result {
    private static int[] parent;
    public static int kruskals(int gNodes, List<int> gFrom, List<int> gTo, List<int> gWeight) {
        PriorityQueue<(int a, int b, int wt), int> heap = new();
        parent = new int[gNodes + 1];

        for (var i = 1; i < parent.Length; i++) {
            parent[i] = i;
        }

        for (var i = 0; i < gFrom.Count; i++) {
            heap.Enqueue((gFrom[i], gTo[i], gWeight[i]), gWeight[i]);
        }

        int weight = 0;
        while (heap.Count > 0) {
            var tuple = heap.Dequeue();
            if (findParent(tuple.a) != findParent(tuple.b)) {
                union(tuple.a, tuple.b);
                weight += tuple.wt;
            }
        }
        return weight;
    }
    private static int findParent(int x) {
        if (parent[x] != x) {
            parent[x] = findParent(parent[x]);
        }
        return parent[x];
    }
    private static void union(int x, int y) {
        parent[findParent(x)] = parent[findParent(y)];
    }
}
