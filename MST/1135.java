// 1135. Connecting Cities With Minimum Cost
// https://leetcode.com/problems/connecting-cities-with-minimum-cost/
// https://www.lintcode.com/problem/3672/

public class Solution {
    int[] parent;
    public int minimumCost(int n, int[][] connections) {
        PriorityQueue<int[]> heap = new PriorityQueue<>((a, b) -> a[2] - b[2]);
        HashSet<Integer> visited = new HashSet<>();
        parent = new int[n + 1];

        for (int i = 1; i < parent.length; i++) {
            parent[i] = i;
        }
        for (int[] connection : connections) {
            heap.offer(connection);
        }
        int total = 0;
        while (!heap.isEmpty()) {
            int[] tuple = heap.poll();
            if (findParent(tuple[0]) != findParent(tuple[1])) {
                union(tuple[0], tuple[1]);
                visited.add(tuple[0]);
                visited.add(tuple[1]);
                total += tuple[2];
            }
        }
        return visited.size() < n ? -1 : total;
    }

    private int findParent(int x) {
        if (parent[x] != x) {
            parent[x] = findParent(parent[x]);
        }
        return parent[x];
    }
    private void union(int x, int y) {
        parent[findParent(x)] = parent[findParent(y)];
    }
}