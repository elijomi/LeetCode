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
    public void SolvesGivenPuzzle(ISudokuSolver solver)
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
}

