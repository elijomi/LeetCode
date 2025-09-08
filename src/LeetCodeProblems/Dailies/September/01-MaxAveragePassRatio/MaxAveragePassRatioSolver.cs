namespace LeetCodeProblems.Dailies.MaxAveragePassRatio;

public class MaxAveragePassRatioSolver
{
    private static double PassRatio(int pass, int total) => (double)pass / total;
    private static double MarginalGain(int pass, int total, int add = 1) => PassRatio(pass + add, total + add) - PassRatio(pass, total);

    public double MaxAverageRatio(int[][] classes, int extraStudents)
    {
        if (classes == null || classes.Length == 0) return 0.0;

        var prioritizedClasses = new PriorityQueue<int, double>(classes.Length);
        for (int i = 0; i < classes.Length; i++)
        {
            prioritizedClasses.Enqueue(i, -MarginalGain(classes[i][0], classes[i][1]));  // Enqueue with negative priority to simulate max-heap
        }

        for (int i = 0; i < extraStudents; i++)
        {
            var classIndex = prioritizedClasses.Dequeue();
            var row = classes[classIndex];
            row[0]++;
            row[1]++;
            prioritizedClasses.Enqueue(classIndex, -MarginalGain(row[0], row[1]));
        }

        double sum = 0;
        foreach (var c in classes)
        {
            sum += PassRatio(c[0], c[1]);
        }

        return sum / classes.Length;
    }
}
