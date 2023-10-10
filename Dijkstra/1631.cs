// 1631. Path With Minimum Effort
// https://leetcode.com/problems/path-with-minimum-effort


public class Solution
{
    int nr;
    int nc;
    public int MinimumEffortPath(int[][] heights) {
        nr = heights.Length;
        nc = heights[0].Length;
        var minEffort = new int[nr, nc];

        for (var i = 0; i < nr; i++) {
            for (var j = 0; j < nc; j++) {
                minEffort[i, j] = -1;
            }
        }

        PriorityQueue<(int i, int j, int wt), int> heap = new();
        heap.Enqueue((0, 0, 0), 0);

        while (heap.Count > 0) {
            var tuple = heap.Dequeue();

            if (minEffort[tuple.i, tuple.j] != -1) continue;
            
            minEffort[tuple.i, tuple.j] = tuple.wt;
            if (tuple.i == nr - 1 && tuple.j == nc - 1) return minEffort[tuple.i, tuple.j];

            var neighbors = getNeighbors(heights, tuple.i, tuple.j);

            foreach (var neighbor in neighbors) {
                if (minEffort[neighbor.i, neighbor.j] == -1) {
                    var wt = Math.Abs(heights[tuple.i][tuple.j] - heights[neighbor.i][neighbor.j]);
                    wt = Math.Max(wt, tuple.wt);
                    heap.Enqueue((neighbor.i, neighbor.j, wt), wt);
                }
            }
        }
        return -1;
    }

    private List<(int i, int j)> getNeighbors(int[][] graph, int i, int j) {
        var res = new List<(int i, int j)>();
        if (isValid(graph, i + 1, j)) res.Add((i + 1, j));
        if (isValid(graph, i - 1, j)) res.Add((i - 1, j));
        if (isValid(graph, i, j + 1)) res.Add((i, j + 1));
        if (isValid(graph, i, j - 1)) res.Add((i, j - 1));
        return res;
    }

    private bool isValid(int[][] graph, int i, int j) {
        return i >= 0 && i < nr && j >= 0 && j < nc;
    }
}
