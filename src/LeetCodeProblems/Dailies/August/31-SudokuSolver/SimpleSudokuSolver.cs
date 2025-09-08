namespace LeetCodeProblems.Dailies.Sudoku;

/// <summary>
/// Simple implementation of the Sudoku Solver using backtracking
/// </summary>
public class SimpleSudokuSolver : ISudokuSolver
{
    public void SolveSudoku(char[][] board)
    {
        Backtrack(board);
    }

    private bool IsValid(char[][] board, int row, int col, char c)
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[i][col] == c) return false;
            if (board[row][i] == c) return false;
            if (board[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3] == c) return false;
        }
        return true;
    }

    private bool FindNextEmpty(char[][] board, out int row, out int col)
    {
        for (row = 0; row < 9; row++)
        {
            for (col = 0; col < 9; col++)
            {
                if (board[row][col] == '.') return true;
            }
        }
        row = -1;
        col = -1;
        return false;
    }

    private bool Backtrack(char[][] board)
    {
        if (!FindNextEmpty(board, out int row, out int col))
        {
            return true; // Solved
        }

        for (char c = '1'; c <= '9'; c++)
        {
            if (IsValid(board, row, col, c))
            {
                board[row][col] = c;

                if (Backtrack(board))
                {
                    return true;
                }

                board[row][col] = '.';
            }
        }
        return false;
    }
}