namespace LeetCode.Top100Liked.NQueens;

/// <summary>
/// The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens 
/// attack each other. Given an integer n, return all distinct solutions to the n-queens puzzle. You may 
/// return the answer in any order. Each solution contains a distinct board configuration of the n-queens' 
/// placement, where 'Q' and '.' both indicate a queen and an empty space, respectively.
/// 
/// Constraints:
/// 1 <= n <= 9
/// 
/// https://leetcode.com/problems/nqueens
/// </summary>
public class Solution
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        var res = new List<IList<string>>();
        var cols = new bool[n];              // columns used
        var diag1 = new bool[2 * n - 1];     // r - c + (n - 1)
        var diag2 = new bool[2 * n - 1];     // r + c
        var board = new char[n][];

        for (int r = 0; r < n; r++)
        {
            board[r] = new string('.', n).ToCharArray();
        }

        Place(0, n, board, cols, diag1, diag2, res);
        return res;
    }

    private static void Place(int r, int n, char[][] board, bool[] cols, bool[] diag1, bool[] diag2, IList<IList<string>> res)
    {
        if (r == n)
        {
            var snapshot = new List<string>(n);
            for (int i = 0; i < n; i++)
            {
                snapshot.Add(new string(board[i]));
            }

            res.Add(snapshot);
            return;
        }

        for (int c = 0; c < n; c++)
        {
            int d1 = r - c + n - 1;
            int d2 = r + c;
            if (cols[c] || diag1[d1] || diag2[d2]) continue;

            cols[c] = diag1[d1] = diag2[d2] = true;
            board[r][c] = 'Q';

            Place(r + 1, n, board, cols, diag1, diag2, res);

            board[r][c] = '.';
            cols[c] = diag1[d1] = diag2[d2] = false;
        }
    }
}
