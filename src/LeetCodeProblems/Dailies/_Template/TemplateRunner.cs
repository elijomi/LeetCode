namespace LeetCodeProblems.Dailies.Template;

/// <summary>
/// Runner class for the <problem> problem as specified by
/// Leetcode Daily <mm> <dd> <yyyy> (<url>)
/// </summary>
public static class TemplateRunner
{
    public static void Run()
    {
        var solver = new TemplateSolver();

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
            var actual = solver.SomeProblemSolution(points);
            Console.WriteLine($"Test {i}: expected={expected}, actual={actual} - {(actual == expected ? "PASS" : "FAIL")}");
            i++;
        }
    }
}
