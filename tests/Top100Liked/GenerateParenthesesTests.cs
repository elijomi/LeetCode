using LeetCode.Top100Liked.GenerateParentheses;
using Xunit;

namespace LeetCode.Tests.Top100Liked;

public class GenerateParenthesesTests
{
    [Theory]
    [MemberData(nameof(Data))]
    public void GenerateParenthesis_MatchesExpectedSet(int n, IList<string> expected)
    {
        var solver = new Solution();
        var actual = solver.GenerateParenthesis(n);
        Assert.True(SetEquals(actual, expected));
    }

    public static IEnumerable<object[]> Data()
    {
        yield return new object[] { 3, new List<string> { "((()))","(()())","(())()","()(())","()()()" } };
        yield return new object[] { 1, new List<string> { "()" } };
        yield return new object[] { 2, new List<string> { "(())", "()()" } };
        yield return new object[] { 4, new List<string> { "(((())))","((()()))","((())())","((()))()","(()(()))","(()()())","(()())()","(())(())","(())()()","()((()))","()(()())","()(())()","()()(())","()()()()" } };
        yield return new object[] { 0, new List<string> { "" } };
    }

    private static bool SetEquals(IList<string>? a, IList<string>? b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        var setA = new HashSet<string>(a);
        var setB = new HashSet<string>(b);
        return setA.SetEquals(setB);
    }
}

