using LeetCode.Dailies.SumOfTwoNoZeroInts;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class SumOfTwoNoZeroIntsTests
{
    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(11)]
    [InlineData(19)]
    [InlineData(20)]
    [InlineData(101)]
    [InlineData(1000)]
    [InlineData(9999)]
    public void GetNoZeroIntegers_ReturnsValidNoZeroPair(int n)
    {
        var solver = new SumOfTwoNoZeroIntsSolution();
        var pair = solver.GetNoZeroIntegers(n);

        Assert.Equal(2, pair.Length);
        Assert.Equal(n, pair[0] + pair[1]);
        Assert.True(pair[0] > 0 && pair[1] > 0);
        Assert.False(HasZero(pair[0]));
        Assert.False(HasZero(pair[1]));
    }

    [Fact]
    public void Works_ForRange_2_To_300()
    {
        var solver = new SumOfTwoNoZeroIntsSolution();
        for (int n = 2; n <= 300; n++)
        {
            var pair = solver.GetNoZeroIntegers(n);
            Assert.Equal(n, pair[0] + pair[1]);
            Assert.False(HasZero(pair[0]));
            Assert.False(HasZero(pair[1]));
        }
    }

    [Theory]
    [InlineData(1)]
    [InlineData(0)]
    [InlineData(-5)]
    public void Throws_For_InvalidN(int n)
    {
        var solver = new SumOfTwoNoZeroIntsSolution();
        Assert.Throws<ArgumentException>(() => solver.GetNoZeroIntegers(n));
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
