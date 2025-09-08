using LeetCode.Dailies.MinOperationsToMakeArrayZero;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class MinOperationsToMakeArrayZeroTests
{
    [Theory]
    [MemberData(nameof(FixedCases))]
    public void MinOperations_ReturnsExpected_ForFixedCases(int[][] queries, long expected)
    {
        var solver = new MinOperationsToMakeArrayZeroSolution();
        var actual = solver.MinOperations(queries);
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> FixedCases()
    {
        yield return new object[] { new[] { new[] { 1, 2 }, new[] { 2, 4 } }, 3L };
        yield return new object[] { new[] { new[] { 2, 6 } }, 4L };
        yield return new object[] { new[] { new[] { 3, 10 } }, 8L };
        yield return new object[] { new[] { new[] { 24, 25 } }, 3L };

        // Boundaries around powers of 4 (precomputed expected values)
        yield return new object[] { new[] { new[] { 1, 3 } }, 2L };   // ceil((1+1+1)/2)
        yield return new object[] { new[] { new[] { 1, 4 } }, 3L };   // ceil((1+1+1+2)/2)
        yield return new object[] { new[] { new[] { 15, 16 } }, 3L }; // ceil((2+3)/2)
        yield return new object[] { new[] { new[] { 17, 64 } }, 73L }; // 17..63 => 47*3, 64 => 4
        yield return new object[] { new[] { new[] { 63, 64 } }, 4L };  // ceil((3+4)/2)

        // Multiple queries aggregation
        yield return new object[]
        {
            new[] { new[] { 1, 3 }, new[] { 5, 16 }, new[] { 17, 22 } },
            24L // 2 + 13 + 9
        };
    }
}
