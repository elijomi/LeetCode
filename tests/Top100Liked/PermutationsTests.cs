using LeetCode.Top100Liked.Permutations;
using Xunit;

namespace LeetCode.Tests.Top100Liked;

public class PermutationsTests
{
    [Theory]
    [MemberData(nameof(Data))]
    public void Permute_MatchesExpectedSet(int[] nums, IList<IList<int>> expected)
    {
        var solver = new Solution();
        var actual = solver.Permute((int[])nums.Clone());
        Assert.True(SetOfListsEqual(actual, expected));
    }

    public static IEnumerable<object[]> Data()
    {
        yield return new object[]
        {
            new int[] {1,2,3},
            new List<IList<int>>
            {
                new List<int> {1,2,3},
                new List<int> {1,3,2},
                new List<int> {2,1,3},
                new List<int> {2,3,1},
                new List<int> {3,1,2},
                new List<int> {3,2,1}
            }
        };
        yield return new object[]
        {
            new int[] {0,1},
            new List<IList<int>>
            {
                new List<int> {0,1},
                new List<int> {1,0}
            }
        };
        yield return new object[]
        {
            new int[] {1},
            new List<IList<int>>
            {
                new List<int> {1}
            }
        };

        // Mixed negatives and zero (3 elements): all 6 permutations
        yield return new object[]
        {
            new int[] {-1,0,2},
            new List<IList<int>>
            {
                new List<int> {-1,0,2},
                new List<int> {-1,2,0},
                new List<int> {0,-1,2},
                new List<int> {0,2,-1},
                new List<int> {2,-1,0},
                new List<int> {2,0,-1}
            }
        };

        // Unordered input (3 elements): all 6 permutations of {1,2,3}
        yield return new object[]
        {
            new int[] {3,1,2},
            new List<IList<int>>
            {
                new List<int> {1,2,3},
                new List<int> {1,3,2},
                new List<int> {2,1,3},
                new List<int> {2,3,1},
                new List<int> {3,1,2},
                new List<int> {3,2,1}
            }
        };

        // 4 elements: 24 permutations explicitly listed
        yield return new object[]
        {
            new int[] {1,2,3,4},
            new List<IList<int>>
            {
                new List<int>{1,2,3,4}, new List<int>{1,2,4,3}, new List<int>{1,3,2,4}, new List<int>{1,3,4,2}, new List<int>{1,4,2,3}, new List<int>{1,4,3,2},
                new List<int>{2,1,3,4}, new List<int>{2,1,4,3}, new List<int>{2,3,1,4}, new List<int>{2,3,4,1}, new List<int>{2,4,1,3}, new List<int>{2,4,3,1},
                new List<int>{3,1,2,4}, new List<int>{3,1,4,2}, new List<int>{3,2,1,4}, new List<int>{3,2,4,1}, new List<int>{3,4,1,2}, new List<int>{3,4,2,1},
                new List<int>{4,1,2,3}, new List<int>{4,1,3,2}, new List<int>{4,2,1,3}, new List<int>{4,2,3,1}, new List<int>{4,3,1,2}, new List<int>{4,3,2,1}
            }
        };
    }

    private static bool SetOfListsEqual(IList<IList<int>> a, IList<IList<int>> b)
    {
        if (a.Count != b.Count) return false;
        static string Key(IList<int> lst) => string.Join(",", lst);
        var setA = new HashSet<string>(a.Select(Key));
        var setB = new HashSet<string>(b.Select(Key));
        return setA.SetEquals(setB);
    }

    [Fact]
    public void Permute_EmptyInput_ReturnsSingleEmptyPermutation()
    {
        var solver = new Solution();
        var actual = solver.Permute(Array.Empty<int>());
        Assert.Single(actual);
        Assert.True(actual[0].SequenceEqual(Array.Empty<int>()));
    }

    [Fact]
    public void Permute_DoesNotMutateInput()
    {
        var solver = new Solution();
        var nums = new[] { 4, 5, 6 };
        var copy = (int[])nums.Clone();
        var _ = solver.Permute(nums);
        Assert.True(nums.SequenceEqual(copy));
    }
}
