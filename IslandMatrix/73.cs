// 73. Fllod Fill
// https://leetcode.com/problems/flood-fill/
public class Solution
{
    int nr;
    int nc;

    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        nr = image.Length;
        nc = image[0].Length;

        if (image[sr][sc] != color)
        {
            fill(image, sr, sc, image[sr][sc], color);
        }
        return image;
    }

    private void fill(int[][] image, int r, int c, int oldColor, int color)
    {
        if (isValidCell(image, r, c) && image[r][c] == oldColor)
        {
            image[r][c] = color;
            fill(image, r + 1, c, oldColor, color);
            fill(image, r - 1, c, oldColor, color);
            fill(image, r, c + 1, oldColor, color);
            fill(image, r, c - 1, oldColor, color);
        }
    }

    private bool isValidCell(int[][] image, int r, int c)
    {
        return r >= 0 && r < nr && c >= 0 && c < nc;
    }
}
