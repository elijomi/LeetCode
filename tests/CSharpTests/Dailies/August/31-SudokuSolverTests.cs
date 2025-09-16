using LeetCode.Dailies.Sudoku;
using Xunit;

namespace LeetCode.Tests.Dailies.August;

public class SudokuSolverTests
{
    public static IEnumerable<object[]> Solvers => new[]
    {
        new object[] { (ISudokuSolver)new SimpleSudokuSolver() },
        new object[] { (ISudokuSolver)new FasterSudokuSolver() }
    };

    [Theory]
    [MemberData(nameof(Solvers))]
    public void SolvesBoard_ProvidedByLeetCode(ISudokuSolver solver)
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

        var expected = new char[9][] {
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

        solver.SolveSudoku(inputBoard);
        Assert.True(BoardsEqual(inputBoard, expected));
    }

    [Theory]
    [MemberData(nameof(Solvers))]
    public void SolvesBoard_WithSingleEmptyCell(ISudokuSolver solver)
    {
        var solved = new char[9][] {
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

        // Make a single empty cell (choose a place where only one value fits)
        var input = CloneBoard(solved);
        input[0][2] = '.'; // was '4'

        solver.SolveSudoku(input);
        Assert.True(BoardsEqual(input, solved));
    }

    [Theory]
    [MemberData(nameof(Solvers))]
    public void AlreadySolved_BoardRemainsUnchanged(ISudokuSolver solver)
    {
        var solved = new char[9][] {
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

        var input = CloneBoard(solved);
        solver.SolveSudoku(input);
        Assert.True(BoardsEqual(input, solved));
    }

    [Theory]
    [MemberData(nameof(Solvers))]
    public void Idempotent_OnSolvedBoard(ISudokuSolver solver)
    {
        var solved = new char[9][] {
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

        var input = CloneBoard(solved);
        solver.SolveSudoku(input);
        solver.SolveSudoku(input);
        Assert.True(BoardsEqual(input, solved));
    }

    [Theory]
    [MemberData(nameof(Solvers))]
    public void SolvesAnotherPuzzle_Correctly(ISudokuSolver solver)
    {
        // Create a second puzzle by blanking a set of positions from the solved board
        var solved = new char[9][] {
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

        var input = CloneBoard(solved);
        // Blank a variety across rows, cols, and boxes
        (int r, int c)[] blanks = new[] { (0,0),(0,4),(1,3),(2,1),(3,6),(4,8),(5,5),(6,7),(7,2),(8,3) };
        foreach (var (r,c) in blanks) input[r][c] = '.';

        solver.SolveSudoku(input);
        Assert.True(BoardsEqual(input, solved));
    }

    private static bool BoardsEqual(char[][] a, char[][] b)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (a[i][j] != b[i][j]) return false;
            }
        }
        return true;
    }

    private static char[][] CloneBoard(char[][] board)
    {
        var copy = new char[9][];
        for (int i = 0; i < 9; i++)
        {
            copy[i] = new char[9];
            Array.Copy(board[i], copy[i], 9);
        }
        return copy;
    }

}
