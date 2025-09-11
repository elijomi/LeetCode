using LeetCode.Top100Liked.WordSearch;
using Xunit;

namespace LeetCode.Tests.Top100Liked;

public class WordSearchTests
{
    private readonly Solution _sut = new Solution();

    [Fact]
    public void WordSearch_LeetCodeSample1()
    {
        char[][] inputBoard = [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']];
        string inputWord = "ABCCED";
        bool expected = true;

        bool actual = _sut.Exist(inputBoard, inputWord);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WordSearch_SingleCell_Match()
    {
        char[][] inputBoard = [['A']];
        string inputWord = "A";
        bool expected = true;

        bool actual = _sut.Exist(inputBoard, inputWord);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WordSearch_SingleCell_NoMatch()
    {
        char[][] inputBoard = [['A']];
        string inputWord = "B";
        bool expected = false;

        bool actual = _sut.Exist(inputBoard, inputWord);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WordSearch_WordLongerThanCells_False()
    {
        char[][] inputBoard = [['A', 'B'], ['C', 'D']];
        string inputWord = "ABCDE"; // 5 letters, but only 4 cells
        bool expected = false;

        bool actual = _sut.Exist(inputBoard, inputWord);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WordSearch_DiagonalNotAllowed_False()
    {
        char[][] inputBoard = [['A', 'B'], ['C', 'D']];
        string inputWord = "AD"; // would require diagonal move
        bool expected = false;

        bool actual = _sut.Exist(inputBoard, inputWord);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WordSearch_MultipleTurns_PathExists()
    {
        char[][] inputBoard = [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']];
        string inputWord = "ABFDE"; // A->B->F->D->E
        bool expected = true;

        bool actual = _sut.Exist(inputBoard, inputWord);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WordSearch_RequiresBacktracking_PathExists()
    {
        char[][] inputBoard = [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']];
        string inputWord = "ABFSA"; // must not get stuck after F
        bool expected = true;

        bool actual = _sut.Exist(inputBoard, inputWord);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WordSearch_CaseSensitive()
    {
        char[][] inputBoard = [['a', 'B', 'c', 'D']];
        string inputWord1 = "aBcD"; // exact case
        string inputWord2 = "ABCD"; // different case

        bool expected1 = true;
        bool expected2 = false;

        bool actual1 = _sut.Exist(inputBoard, inputWord1);
        bool actual2 = _sut.Exist(inputBoard, inputWord2);

        Assert.Equal(expected1, actual1);
        Assert.Equal(expected2, actual2);
    }

    [Fact]
    public void WordSearch_DoesNotMutateBoard()
    {
        char[][] original = [['A', 'B', 'C'], ['D', 'E', 'F']];
        char[][] expectedBoard = [['A', 'B', 'C'], ['D', 'E', 'F']];
        string inputWord = "ABE"; // exists: A->B->E

        bool _ = _sut.Exist(original, inputWord);

        for (int r = 0; r < expectedBoard.Length; r++)
        {
            for (int c = 0; c < expectedBoard[0].Length; c++)
            {
                Assert.Equal(expectedBoard[r][c], original[r][c]);
            }
        }
    }

    [Fact]
    public void WordSearch_LeetCodeSample2()
    {
        char[][] inputBoard = [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']];
        string inputWord = "SEE";
        bool expected = true;

        bool actual = _sut.Exist(inputBoard, inputWord);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WordSearch_LeetCodeSample3()
    {
        char[][] inputBoard = [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']];
        string inputWord = "ABCB";
        bool expected = false;

        bool actual = _sut.Exist(inputBoard, inputWord);

        Assert.Equal(expected, actual);
    }
}
