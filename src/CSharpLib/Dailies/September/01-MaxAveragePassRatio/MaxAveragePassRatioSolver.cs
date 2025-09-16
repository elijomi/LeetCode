namespace LeetCode.Dailies.MaxAveragePassRatio;

/// <summary>
/// There is a school that has classes of students and each class will be having a final exam. You are given a 2D integer array classes, 
/// where classes[i] = [passi, totali]. You know beforehand that in the ith class, there are totali total students, but only passi number 
/// of students will pass the exam. You are also given an integer extraStudents. There are another extraStudents brilliant students that
/// are guaranteed to pass the exam of any class they are assigned to. You want to assign each of the extraStudents students to a class 
/// in a way that maximizes the average pass ratio across all the classes. The pass ratio of a class is equal to the number of students 
/// of the class that will pass the exam divided by the total number of students of the class. The average pass ratio is the sum of pass 
/// ratios of all the classes divided by the number of the classes. Return the maximum possible average pass ratio after assigning the 
/// extraStudents students. Answers within 10^5 of the actual answer will be accepted.
/// 
/// Constraints:
/// 1 <= classes.length <= 10^5
/// classes[i].length == 2
/// 1 <= passi <= totali <= 10^5
/// 1 <= extraStudents <= 10^5
/// 
/// https://leetcode.com/problems/maximum-average-pass-ratio
/// </summary>
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
