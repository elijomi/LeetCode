using LeetCode.Top100Liked.LetterCombinationsOfAPhoneNumber;
using Xunit;

namespace LeetCode.Tests.Top100Liked;

public class LetterCombinationsTests
{
    [Theory]
    [MemberData(nameof(Data))]
    public void LetterCombinations_MatchesExpectedSet(string digits, IList<string> expected)
    {
        var solver = new Solution();
        var actual = solver.LetterCombinations(digits);
        Assert.True(SetEquals(actual, expected));
    }

    public static IEnumerable<object[]> Data()
    {
        yield return new object[] { "23", new List<string> { "ad","ae","af","bd","be","bf","cd","ce","cf" } };
        yield return new object[] { "", new List<string>() };
        yield return new object[] { "2", new List<string> { "a","b","c" } };
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

