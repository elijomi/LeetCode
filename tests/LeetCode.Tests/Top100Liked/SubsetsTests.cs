using LeetCode.Top100Liked.Subsets;
using Xunit;

namespace LeetCode.Tests.Top100Liked;

public class SubsetsTests
{
    [Fact]
    public void Subsets_ReturnsAllUniqueSubsets()
    {
        var solver = new Solution();
        var nums = new[] { 1, 2, 3 };
        var result = solver.Subsets(nums);

        // 2^n subsets
        Assert.Equal(8, result.Count);

        // Uniqueness
        var keys = new HashSet<string>(result.Select(r => string.Join(",", r.OrderBy(x => x))));
        Assert.Equal(result.Count, keys.Count);

        // Contains some known subsets
        Assert.Contains(result, r => r.SequenceEqual(Array.Empty<int>()));
        Assert.Contains(result, r => r.SequenceEqual(new[] { 1 }));
        Assert.Contains(result, r => r.OrderBy(x => x).SequenceEqual(new[] { 1, 2 }));
        Assert.Contains(result, r => r.OrderBy(x => x).SequenceEqual(new[] { 1, 2, 3 }));
    }
}

