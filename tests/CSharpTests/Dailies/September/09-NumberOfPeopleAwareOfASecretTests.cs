using LeetCode.Dailies.NumberOfPeopleAwareOfASecret;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class NumberOfPeopleAwareOfASecretTests
{
    [Theory]
    [InlineData(6, 2, 4, 5)]    // provided by LeetCode
    [InlineData(4, 1, 3, 6)]    // provided by LeetCode
    [InlineData(2, 1, 2, 2)]    // minimal bounds
    [InlineData(5, 1, 2, 2)]    // tight window, constant sharers
    [InlineData(10, 5, 6, 1)]   // share only briefly before forgetting
    [InlineData(10, 2, 4, 14)]  // moderate growth
    [InlineData(7, 3, 4, 2)]    // delayed start, quick forget
    [InlineData(15, 1, 5, 11072)] // larger n, stronger growth
    [InlineData(7, 2, 7, 13)]   // long forget window
    [InlineData(1000, 1, 2, 2)] // performance/upper n bound sanity
    public void GetNoZeroIntegers_ReturnsValidNoZeroPair(int n, int delay, int forget, int expected)
    {
        var solver = new NumberOfPeopleAwareOfASecretSolution();
        var people = solver.PeopleAwareOfSecret(n, delay, forget);

        Assert.Equal(expected, people);
    }
}
