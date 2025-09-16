namespace LeetCode.Dailies.Sudoku;

/// <summary>
/// Faster implementation of the Sudoku Solver using 2d bool arrays and backtracking
/// </summary>
public class FasterSudokuSolver : ISudokuSolver
{
    private bool[,] rows, cols, boxes;
    private List<(int r, int c)> empties;

    private static int BoxIndex(int r, int c) => (r / 3) * 3 + (c / 3);

    public FasterSudokuSolver()
    {
        rows = new bool[9, 10];
        cols = new bool[9, 10];
        boxes = new bool[9, 10];
        empties = new List<(int r, int c)>();
    }

    public void SolveSudoku(char[][] board)
    {
        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 9; c++)
            {
                char ch = board[r][c];
                if (ch == '.')
                {
                    empties.Add((r, c));
                }
                else
                {
                    int d = ch - '0';
                    int b = BoxIndex(r, c);
                    if (rows[r, d] || cols[c, d] || boxes[b, d])
                    {
                        // Invalid input
                    }
                    rows[r, d] = cols[c, d] = boxes[b, d] = true;
                }
            }
        }

        Backtrack(0, board);
    }

    private bool Backtrack(int idx, char[][] board)
    {
        if (idx == empties.Count) return true;

        var (r, c) = empties[idx];
        int b = BoxIndex(r, c);

        for (int d = 1; d <= 9; d++)
        {
            if (!rows[r, d] && !cols[c, d] && !boxes[b, d])     // if d free
            {
                board[r][c] = (char)('0' + d);
                rows[r, d] = cols[c, d] = boxes[b, d] = true;   // claim d

                if (Backtrack(idx + 1, board)) return true;

                rows[r, d] = cols[c, d] = boxes[b, d] = false;  // unclaim d
                board[r][c] = '.';
            }
        }
        
        return false;
    }
}
