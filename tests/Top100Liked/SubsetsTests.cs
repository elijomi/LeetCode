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

    [Fact]
    public void Subsets_EmptyInput_ReturnsOnlyEmptySet()
    {
        var solver = new Solution();
        var nums = Array.Empty<int>();

        var result = solver.Subsets(nums);

        Assert.Single(result);
        Assert.Contains(result, r => r.SequenceEqual(Array.Empty<int>()));
    }

    [Fact]
    public void Subsets_SingleElement_AllSubsetsPresent()
    {
        var solver = new Solution();
        var nums = new[] { 5 };

        var result = solver.Subsets(nums);

        // Expected: [], [5]
        var expected = new List<IList<int>>
        {
            Array.Empty<int>(),
            new[] { 5 }
        };

        Assert.Equal(expected.Count, result.Count);
        foreach (var e in expected)
        {
            Assert.Contains(result, r => r.SequenceEqual(e));
        }
    }

    [Fact]
    public void Subsets_TwoElements_AllSubsetsPresent()
    {
        var solver = new Solution();
        var nums = new[] { 0, 1 };

        var result = solver.Subsets(nums);

        // Expected: [], [0], [1], [0,1]
        var expected = new List<IList<int>>
        {
            Array.Empty<int>(),
            new[] { 0 },
            new[] { 1 },
            new[] { 0, 1 }
        };

        Assert.Equal(expected.Count, result.Count);
        // Compare as sets of sorted subsets (order of subsets not guaranteed)
        var expectedKeys = new HashSet<string>(expected.Select(e => string.Join(",", e.OrderBy(x => x))));
        var resultKeys = new HashSet<string>(result.Select(r => string.Join(",", r.OrderBy(x => x))));
        Assert.Subset(expectedKeys, resultKeys);
        Assert.Subset(resultKeys, expectedKeys);
    }

    [Fact]
    public void Subsets_NegativeAndZero_AllSubsetsPresent()
    {
        var solver = new Solution();
        var nums = new[] { -1, 0, 2 };

        var result = solver.Subsets(nums);

        // 8 expected subsets enumerated explicitly
        var expected = new List<IList<int>>
        {
            Array.Empty<int>(),
            new[] { -1 },
            new[] { 0 },
            new[] { 2 },
            new[] { -1, 0 },
            new[] { -1, 2 },
            new[] { 0, 2 },
            new[] { -1, 0, 2 }
        };

        Assert.Equal(expected.Count, result.Count);
        var expectedKeys = new HashSet<string>(expected.Select(e => string.Join(",", e.OrderBy(x => x))));
        var resultKeys = new HashSet<string>(result.Select(r => string.Join(",", r.OrderBy(x => x))));
        Assert.Subset(expectedKeys, resultKeys);
        Assert.Subset(resultKeys, expectedKeys);
    }

    [Fact]
    public void Subsets_UnorderedInput_AllCombosPresentRegardlessOfOrder()
    {
        var solver = new Solution();
        var nums = new[] { 3, 1, 2 };

        var result = solver.Subsets(nums);

        // Expected all combinations of {1,2,3}
        var expected = new List<IList<int>>
        {
            Array.Empty<int>(),
            new[] { 1 },
            new[] { 2 },
            new[] { 3 },
            new[] { 1, 2 },
            new[] { 1, 3 },
            new[] { 2, 3 },
            new[] { 1, 2, 3 }
        };

        Assert.Equal(8, result.Count);
        var expectedKeys = new HashSet<string>(expected.Select(e => string.Join(",", e.OrderBy(x => x))));
        var resultKeys = new HashSet<string>(result.Select(r => string.Join(",", r.OrderBy(x => x))));
        Assert.Subset(expectedKeys, resultKeys);
        Assert.Subset(resultKeys, expectedKeys);
    }

    [Fact]
    public void Subsets_CountMatchesPowerSet()
    {
        var solver = new Solution();
        var nums = new[] { 1, 2, 3, 4, 5 };

        var result = solver.Subsets(nums);

        Assert.Equal(32, result.Count); // 2^5
        // Ensure uniqueness (basic)
        var keys = new HashSet<string>(result.Select(r => string.Join(",", r.OrderBy(x => x))));
        Assert.Equal(result.Count, keys.Count);
    }
}
