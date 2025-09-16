using LeetCode.Dailies.MostFrequentVowelAndConsonant;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class MostFrequentVowelAndConsonantTests
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData("successes", 6)]         // LeetCode sample
    [InlineData("aeiaeia", 3)]           // LeetCode sample (no consonants)
    [InlineData("rhythms", 2)]
    [InlineData("a", 1)]
    [InlineData("b", 1)]
    [InlineData("aabb", 4)]
    public void ReturnsExpected(string s, int expected)
    {
        var actual = _sut.MaxFreqSum(s);

        Assert.Equal(expected, actual);
    }
}
