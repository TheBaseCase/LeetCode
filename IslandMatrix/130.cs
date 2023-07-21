// 130. Surrounded Regions
// https://leetcode.com/problems/surrounded-regions
public class Solution130
{
    int nr;
    int nc;

    public void Solve(char[][] board)
    {
        nr = board.Length;
        nc = board[0].Length;

        for (var i = 0; i < nr; i++)
        {
            for (var j = 0; j < nc; j++)
            {
                if (isEdgeCell(board, i, j))
                    markCellAsY(board, i, j);
            }
        }

        for (var i = 0; i < nr; i++)
        {
            for (var j = 0; j < nc; j++)
            {
                if (board[i][j] == 'O')
                    board[i][j] = 'X';
                else if (board[i][j] == 'Y')
                    board[i][j] = 'O';
            }
        }
    }

    private void markCellAsY(char[][] board, int i, int j)
    {
        if (isValidCell(board, i, j))
        {
            board[i][j] = 'Y';
            markCellAsY(board, i - 1, j);
            markCellAsY(board, i + 1, j);
            markCellAsY(board, i, j - 1);
            markCellAsY(board, i, j + 1);
        }
    }

    private bool isEdgeCell(char[][] board, int i, int j)
    {
        return (i == 0 || i == nr - 1 || j == 0 || j == nc - 1) && board[i][j] == 'O';
    }

    private bool isValidCell(char[][] board, int i, int j)
    {
        return i >= 0 && i < nr && j >= 0 && j < nc && board[i][j] == 'O';
    }
}
