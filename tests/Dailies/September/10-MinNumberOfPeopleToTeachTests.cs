using LeetCode.Dailies.MinNumberOfPeopleToTeach;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class MinNumberOfPeopleToTeachTests
{
    private readonly MinNumberOfPeopleToTeachSolution _sut = new();

    [Fact]
    public void MinimumTeachings_LeetCodeSample1()
    {
        int n = 2;
        int[][] languages =
        {
            new[] { 1 },
            new[] { 2 },
            new[] { 1, 2 }
        };
        int[][] friendships =
        {
            new[] { 1, 2 },
            new[] { 1, 3 },
            new[] { 2, 3 }
        };

        int result = _sut.MinimumTeachings(n, languages, friendships);


        Assert.Equal(1, result);
    }

    [Fact]
    public void MinimumTeachings_LeetCodeSample2()
    {
        int n = 3;
        int[][] languages =
        {
            new[] { 2 },
            new[] { 1, 3 },
            new[] { 1, 2 },
            new[] { 3 }
        };
        int[][] friendships =
        {
            new[] { 1, 4 },
            new[] { 1, 2 },
            new[] { 3, 4 },
            new[] { 2, 3 }
        };

        int result = _sut.MinimumTeachings(n, languages, friendships);

        Assert.Equal(2, result);
    }

    [Fact]
    public void Returns0_WhenAllFriendshipsAlreadyCommunicate()
    {
        // n = 3 languages; everyone shares language 2 across friendships
        int n = 3;
        int[][] languages =
        {
                new[] { 1, 2 }, // user 1
                new[] { 2 },    // user 2
                new[] { 2, 3 }, // user 3
            };
        int[][] friendships =
        {
                new[] { 1, 2 },
                new[] { 2, 3 },
            };

        var result = _sut.MinimumTeachings(n, languages, friendships);

        Assert.Equal(0, result);
    }

    [Fact]
    public void Returns1_WhenOneTeachingFixesSingleBrokenFriendship()
    {
        // user1 knows 1; user2 knows 2; one pair only -> teach one user one language
        int n = 2;
        int[][] languages =
        {
                new[] { 1 }, // user 1
                new[] { 2 }, // user 2
            };
        int[][] friendships =
        {
                new[] { 1, 2 }
            };

        var result = _sut.MinimumTeachings(n, languages, friendships);

        Assert.Equal(1, result);
    }

    [Fact]
    public void Returns2_WhenTwoTeachingsAreNeededAcrossBrokenPairs()
    {
        // users: [1],[2],[1],[2]
        // friendships form a square; best is teach lang 1 to {2,4} or lang 2 to {1,3} => 2
        int n = 2;
        int[][] languages =
        {
                new[] { 1 }, // 1
                new[] { 2 }, // 2
                new[] { 1 }, // 3
                new[] { 2 }, // 4
            };
        int[][] friendships =
        {
                new[] { 1, 2 },
                new[] { 1, 4 },
                new[] { 2, 3 },
                new[] { 3, 4 }
            };

        var result = _sut.MinimumTeachings(n, languages, friendships);

        Assert.Equal(2, result);
    }

    [Fact]
    public void Returns0_WhenThereAreNoFriendships()
    {
        int n = 5;
        int[][] languages =
        {
                new[] { 1, 2 },
                new[] { 2, 3 },
                new[] { 3, 4 }
            };
        int[][] friendships = Array.Empty<int[]>();

        var result = _sut.MinimumTeachings(n, languages, friendships);

        Assert.Equal(0, result);
    }

    [Fact]
    public void HandlesMultipleBrokenPairs_ComputesBestLanguageByCountingProblemUsers()
    {
        // users:
        // 1: [1]
        // 2: [2]
        // 3: [3]
        // 4: [1,2]
        // 5: [2,3]
        // friendships: (1,2) broken, (2,3) broken, (3,4) broken, (4,5) OK
        // problem users = {1,2,3,4}
        // teach lang1 -> teach {2,3} => 2
        // teach lang2 -> teach {1,3} => 2
        // teach lang3 -> teach {1,2,4} => 3
        int n = 3;
        int[][] languages =
        {
                new[] { 1 },
                new[] { 2 },
                new[] { 3 },
                new[] { 1, 2 },
                new[] { 2, 3 }
            };
        int[][] friendships =
        {
                new[] { 1, 2 },
                new[] { 2, 3 },
                new[] { 3, 4 },
                new[] { 4, 5 }
            };

        var result = _sut.MinimumTeachings(n, languages, friendships);

        Assert.Equal(2, result);
    }

    [Fact]
    public void PrefersLanguageMostKnownAmongProblemUsers()
    {
        // Construct a case where one language is already prevalent among problem users,
        // so the method should pick that (yielding fewer to teach).
        // users:
        // 1: [1,2]
        // 2: [2]
        // 3: [3]
        // 4: [2]
        // friendships: (1,3) broken, (3,4) broken
        // problem users = {1,3,3,4} = {1,3,4}
        // teach lang2 -> users not knowing 2 among {1,3,4} are {3} => 1
        // teach lang1 -> not knowing 1 are {3,4} => 2
        // teach lang3 -> not knowing 3 are {1,4} => 2
        int n = 3;
        int[][] languages =
        {
                new[] { 1, 2 }, // 1
                new[] { 2 },    // 2
                new[] { 3 },    // 3
                new[] { 2 }     // 4
            };
        int[][] friendships =
        {
                new[] { 1, 3 },
                new[] { 3, 4 }
            };

        var result = _sut.MinimumTeachings(n, languages, friendships);

        Assert.Equal(1, result);
    }
}