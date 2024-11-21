// https://leetcode.com/problems/word-search/description/
public class Solution {
    public bool Exist(char[][] board, string word) {
     
        for (var i = 0; i < board.Length; i++) {
            for (var j = 0; j < board[0].Length; j++) {
                if (board[i][j] == word[0])
                    if (DFS(board, i, j, word, 0)) return true;
            }
        }
        return false;
    }

    private bool DFS(char[][] board, int i, int j, string word, int index) {
        if (index == word.Length) return true;

        if (!isValid(board, i, j, word[index])) return false;

        char temp = board[i][j];
        board[i][j] = '*';

        bool found =
               DFS(board, i + 1, j, word, index + 1) // Down
            || DFS(board, i - 1, j, word, index + 1) // Up
            || DFS(board, i, j + 1, word, index + 1) // Right
            || DFS(board, i, j - 1, word, index + 1); // Left

        board[i][j] = temp;
        return found;
    }

    private bool isValid(char[][] board, int i, int j, char target) {
        return i >= 0 && i < board.Length && j >= 0 && j < board[0].Length && board[i][j] == target;
    }
}
