using LeetCode.Dailies.SumOfTwoNoZeroInts;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class SumOfTwoNoZeroIntsTests
{
    [Theory]
    [InlineData(2)]
    [InlineData(11)]
    public void GetNoZeroIntegers_ReturnsValidPair(int n)
    {
        var solver = new SumOfTwoNoZeroIntsSolution();
        var pair = solver.GetNoZeroIntegers(n);

        Assert.Equal(2, pair.Length);
        Assert.Equal(n, pair[0] + pair[1]);
        Assert.False(HasZero(pair[0]));
        Assert.False(HasZero(pair[1]));
    }

    private static bool HasZero(int number)
    {
        if (number == 0) return true;
        int x = Math.Abs(number);
        while (x > 0)
        {
            if (x % 10 == 0) return true;
            x /= 10;
        }
        return false;
    }
}

