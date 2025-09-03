namespace LeetCodeProblems.Dailies.WaysToPlacePeople;

/// <summary>
/// Runner class for the Number of Ways to Place People I problem as specified by
/// Leetcode Daily Sep 2nd 2025 (https://leetcode.com/problems/find-the-number-of-ways-to-place-people-i)
/// 
/// Performance improvements made on Sep 3rd 2025 as per Leetcode Daily Sep 3rd 2025 
/// (https://leetcode.com/problems/find-the-number-of-ways-to-place-people-ii)  
/// </summary>
public static class WaysToPlacePeopleRunner
{
    public static void Run()
    {
        var solver = new WaysToPlacePeopleSolver();

        // Test cases
        var tests = new (int[][] points, int expected)[]
        {
            (new int[][] { [1,1],[2,2],[3,3] }, 0),
            (new int[][] { [6,2],[4,4],[2,6] }, 2),
            (new int[][] { [3,1],[1,3],[1,1] }, 2),
            (new int[][] { [1,5],[2,0],[5,5] }, 2),
            (new int[][] { [3,2],[3,6] }, 1),
        };

        int i = 1;
        foreach (var (points, expected) in tests)
        {
            var actual = solver.NumberOfPairs(points);
            Console.WriteLine($"Test {i}: expected={expected}, actual={actual} - {(actual == expected ? "PASS" : "FAIL")}");
            i++;
        }
    }
}
