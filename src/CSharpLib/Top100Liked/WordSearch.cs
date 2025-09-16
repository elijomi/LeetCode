namespace LeetCode.Top100Liked.WordSearch;

/// <summary>
/// Given an m x n grid of characters board and a string word, return true if word exists in the grid.
/// The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are 
/// horizontally or vertically neighboring.The same letter cell may not be used more than once.
/// 
/// Constraints:
/// m == board.length
/// n = board[i].length
/// 1 <= m, n <= 6
/// 1 <= word.length <= 15
/// board and word consists of only lowercase and uppercase English letters.
/// 
/// https://leetcode.com/problems/word-search
/// </summary>
public class Solution
{
    public bool Exist(char[][] board, string word)
    {
        int m = board.Length;
        int n = board[0].Length;

        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (WordExists(board, word, 0, r, c))
                    return true;
            }
        }
        return false;
    }

    private static bool WordExists(char[][] board, string word, int wi, int ri, int ci)
    {
        if (wi == word.Length) return true;

        if (ri < 0 || ci < 0 || ri >= board.Length || ci >= board[0].Length) return false;
        if (board[ri][ci] != word[wi]) return false;

        char workingChar = board[ri][ci];
        board[ri][ci] = '.';    // block from reuse

        bool found = WordExists(board, word, wi + 1, ri - 1, ci)
        || WordExists(board, word, wi + 1, ri + 1, ci)
        || WordExists(board, word, wi + 1, ri, ci - 1)
        || WordExists(board, word, wi + 1, ri, ci + 1);

        board[ri][ci] = workingChar;    // reset

        return found;
    }
}
