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
    }

    private static bool SetOfListsEqual(IList<IList<int>> a, IList<IList<int>> b)
    {
        if (a.Count != b.Count) return false;
        static string Key(IList<int> lst) => string.Join(",", lst);
        var setA = new HashSet<string>(a.Select(Key));
        var setB = new HashSet<string>(b.Select(Key));
        return setA.SetEquals(setB);
    }
}

