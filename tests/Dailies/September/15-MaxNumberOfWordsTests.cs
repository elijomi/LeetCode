using LeetCode.Dailies.MaxNumberOfWords;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class MaxNumberOfWordsTests
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData("hello world", "ad", 1)]         // LeetCode sample
    [InlineData("leet code", "lt", 1)]           // LeetCode sample
    [InlineData("leet code", "e", 0)]           // LeetCode sample
    public void ReturnsExpected(string s, string broken, int expected)
    {
        var actual = _sut.CanBeTypedWords(s, broken);

        Assert.Equal(expected, actual);
    }
}
