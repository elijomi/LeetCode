using LeetCode.Dailies.VowelsGameInString;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class VowelsGameInStringTests
{
    private readonly Solution _sut = new();

    [Theory]
    [InlineData("leetcoder", true)]         // LeetCode sample
    [InlineData("bbcd", false)]             // LeetCode sample (no vowels)
    public void VowelsGameInString_ReturnsExpected(string s, bool expected)
    {
        var actual = _sut.DoesAliceWin(s);

        Assert.Equal(expected, actual);
    }
}
