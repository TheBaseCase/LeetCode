// 1584. Min Cost to Connect All Points
// https://leetcode.com/problems/min-cost-to-connect-all-points/

public class Solution {
    HashSet<int[]> visited = new();
    PriorityQueue<(int[] point, int wt), int> heap = new();

    public int MinCostConnectPoints(int[][] points) {
        heap.Enqueue((points[0], 0), 0);

        int total = 0;
        while (heap.Count > 0 && visited.Count < points.Length) {
            var tuple = heap.Dequeue();
            if (visited.Contains(tuple.point)) continue;

            total += tuple.wt;
            visited.Add(tuple.point);

            foreach (var point in points) {
                if (visited.Contains(point)) continue;
                var distance = getDistance(point, tuple.point);
                heap.Enqueue((point, distance), distance);
            }
        }
        return total;
    }
    private int getDistance(int[] a, int[] b) {
        return Math.Abs(a[0] - b[0]) + Math.Abs(a[1] - b[1]);
    }
}
