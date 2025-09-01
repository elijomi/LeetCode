namespace LeetCodeDailies.MaxAveragePassRatio;

public static class MaxAveragePassRatioRunner
{
    public static void Run()
    {
        var solver = new MaxAveragePassRatioSolver();
        var result = solver.MaxAverageRatio(new int[][] { [1,2],[3,5],[2,2] }, 2);
        Console.WriteLine(result);
    }
}