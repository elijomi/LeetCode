using LeetCode.Top100Liked.CombinationSum;
using Xunit;

namespace LeetCode.Tests.Top100Liked;

public class CombinationSumTests
{
    [Theory]
    [MemberData(nameof(Data))]
    public void CombinationSum_MatchesExpectedSet(int[] candidates, int target, IList<IList<int>> expected)
    {
        var solver = new Solution();
        var actual = solver.CombinationSum(candidates, target);
        Assert.True(CombinationSetsEqual(actual, expected));
    }

    public static IEnumerable<object[]> Data()
    {
        yield return new object[]
        {
            new int[] {2,3,6,7}, 7,
            new List<IList<int>> { new List<int> {7}, new List<int> {2,2,3} }
        };
        yield return new object[]
        {
            new int[] {2,3,5}, 8,
            new List<IList<int>> { new List<int> {2,2,2,2}, new List<int> {2,3,3}, new List<int> {3,5} }
        };
        yield return new object[]
        {
            new int[] {2}, 1,
            new List<IList<int>>()
        };
        yield return new object[]
        {
            new int[] {1}, 1,
            new List<IList<int>> { new List<int> {1} }
        };
        yield return new object[]
        {
            new int[] {1}, 2,
            new List<IList<int>> { new List<int> {1,1} }
        };
    }

    private static bool CombinationSetsEqual(IList<IList<int>> a, IList<IList<int>> b)
    {
        if (a.Count != b.Count) return false;
        static string Key(IList<int> list) => string.Join(",", list.OrderBy(n => n));
        var setA = new HashSet<string>(a.Select(Key));
        var setB = new HashSet<string>(b.Select(Key));
        return setA.SetEquals(setB);
    }
}

