using LeetCode.Top100Liked.NQueens;
using Xunit;

namespace LeetCode.Tests.Top100Liked;

public class NQueensTests
{
    [Theory]
    [MemberData(nameof(Data))]
    public void SolveNQueens_MatchesExpectedSet(int n, IList<IList<string>> expected)
    {
        var solver = new Solution();
        var actual = solver.SolveNQueens(n);
        Assert.True(BoardsEqual(actual, expected));
    }

    public static IEnumerable<object[]> Data()
    {
        yield return new object[]
        {
            1,
            new List<IList<string>>
            {
                new List<string> { "Q" }
            }
        };
        yield return new object[]
        {
            4,
            new List<IList<string>>
            {
                new List<string> { ".Q..","...Q","Q...","..Q." },
                new List<string> { "..Q.","Q...","...Q",".Q.." }
            }
        };
        yield return new object[] { 2, new List<IList<string>>() };
        yield return new object[] { 3, new List<IList<string>>() };
    }

    private static bool BoardsEqual(IList<IList<string>> a, IList<IList<string>> b)
    {
        if (a.Count != b.Count) return false;
        static string Key(IList<string> board) => string.Join("|", board);
        var setA = new HashSet<string>(a.Select(Key));
        var setB = new HashSet<string>(b.Select(Key));
        return setA.SetEquals(setB);
    }
}

