namespace LeetCodeProblems.Dailies.Sudoku;

/// <summary>
/// Runner class for the Sudoku Solver problem as specified by
/// Leetcode Daily Aug 31st 2025 (https://leetcode.com/problems/sudoku-solver)
/// </summary>
public static class SudokuRunner
{
    public static void Run()
    {
        var inputBoard = new char[9][] {
            ['5','3','.','.','7','.','.','.','.'],
            ['6','.','.','1','9','5','.','.','.'],
            ['.','9','8','.','.','.','.','6','.'],
            ['8','.','.','.','6','.','.','.','3'],
            ['4','.','.','8','.','3','.','.','1'],
            ['7','.','.','.','2','.','.','.','6'],
            ['.','6','.','.','.','.','2','8','.'],
            ['.','.','.','4','1','9','.','.','5'],
            ['.','.','.','.','8','.','.','7','9']
        };

        var expectedOutputBoard = new char[9][] {
            ['5','3','4','6','7','8','9','1','2'],
            ['6','7','2','1','9','5','3','4','8'],
            ['1','9','8','3','4','2','5','6','7'],
            ['8','5','9','7','6','1','4','2','3'],
            ['4','2','6','8','5','3','7','9','1'],
            ['7','1','3','9','2','4','8','5','6'],
            ['9','6','1','5','3','7','2','8','4'],
            ['2','8','7','4','1','9','6','3','5'],
            ['3','4','5','2','8','6','1','7','9']
        };

        var simpleSolver = new SimpleSudokuSolver();
        simpleSolver.SolveSudoku(inputBoard);

        var fasterSolver = new SimpleSudokuSolver();
        fasterSolver.SolveSudoku(inputBoard);

        // Validate the result
        var isSimpleSolverValid = AreBoardsEqual(inputBoard, expectedOutputBoard);
        var isFasterSolverValid = AreBoardsEqual(inputBoard, expectedOutputBoard);
        Console.WriteLine($"Simple result is valid: {isSimpleSolverValid}");
        Console.WriteLine($"Faster result is valid: {isFasterSolverValid}");
    }

    private static bool AreBoardsEqual(char[][] board1, char[][] board2)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board1[i][j] != board2[i][j])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
