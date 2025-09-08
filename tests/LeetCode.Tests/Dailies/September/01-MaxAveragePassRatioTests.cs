using LeetCode.Dailies.MaxAveragePassRatio;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class MaxAveragePassRatioTests
{
    [Fact]
    public void LeetCode_Sample_Case_1()
    {
        var solver = new MaxAveragePassRatioSolver();
        int[][] classes = [ [1, 2], [3, 5], [2, 2] ];
        int extraStudents = 2;
        double expected = 0.78333333333333333;
        var actual = solver.MaxAverageRatio(classes, extraStudents);
        Assert.Equal(expected, actual, 12);
    }

    [Fact]
    public void LeetCode_Sample_Case_2()
    {
        var solver = new MaxAveragePassRatioSolver();
        int[][] classes = [[2, 4], [3, 9], [4, 5], [2, 10]];
        int extraStudents = 4;
        double expected = 0.53484848484848491;
        var actual = solver.MaxAverageRatio(classes, extraStudents);
        Assert.Equal(expected, actual, 12);
    }

    [Fact]
    public void Single_Class_One_Extra()
    {
        var solver = new MaxAveragePassRatioSolver();
        int[][] classes = [ [1, 3] ];
        int extraStudents = 1;
        double expected = 0.5; // [1,3] -> [2,4]
        var actual = solver.MaxAverageRatio(classes, extraStudents);
        Assert.Equal(expected, actual, 12);
    }

    [Fact]
    public void Single_Class_Two_Extra()
    {
        var solver = new MaxAveragePassRatioSolver();
        int[][] classes = [ [1, 3] ];
        int extraStudents = 2;
        double expected = 0.6; // [1,3] -> [3,5]
        var actual = solver.MaxAverageRatio(classes, extraStudents);
        Assert.Equal(expected, actual, 12);
    }

    [Fact]
    public void Two_Equal_Classes_One_Extra()
    {
        var solver = new MaxAveragePassRatioSolver();
        int[][] classes = [ [1, 2], [1, 2] ];
        int extraStudents = 1;
        double expected = 0.5833333333333333; // ([2/3] + [1/2]) / 2
        var actual = solver.MaxAverageRatio(classes, extraStudents);
        Assert.Equal(expected, actual, 12);
    }

    [Fact]
    public void Perfect_And_Weak_Class_One_Extra()
    {
        var solver = new MaxAveragePassRatioSolver();
        int[][] classes = [ [2, 2], [0, 1] ];
        int extraStudents = 1;
        double expected = 0.75; // [2,2]=1.0, [0,1]->[1,2]=0.5
        var actual = solver.MaxAverageRatio(classes, extraStudents);
        Assert.Equal(expected, actual, 12);
    }

    [Fact]
    public void Perfect_And_Weak_Class_Two_Extra()
    {
        var solver = new MaxAveragePassRatioSolver();
        int[][] classes = [ [2, 2], [0, 1] ];
        int extraStudents = 2;
        double expected = 0.8333333333333333; // [2,2]=1.0, [0,1]->[2,3]=0.6666666667
        var actual = solver.MaxAverageRatio(classes, extraStudents);
        Assert.Equal(expected, actual, 12);
    }

    [Fact]
    public void Zero_Passes_Two_Classes_Two_Extra()
    {
        var solver = new MaxAveragePassRatioSolver();
        int[][] classes = [ [0, 1], [0, 2] ];
        int extraStudents = 2;
        double expected = 0.4166666666666667; // [1,2]=0.5 and [1,3]=0.3333
        var actual = solver.MaxAverageRatio(classes, extraStudents);
        Assert.Equal(expected, actual, 12);
    }

    [Fact]
    public void Identical_Classes_Two_Extra()
    {
        var solver = new MaxAveragePassRatioSolver();
        int[][] classes = [ [2, 4], [2, 4] ];
        int extraStudents = 2;
        double expected = 0.6; // end at [3,5] and [3,5]
        var actual = solver.MaxAverageRatio(classes, extraStudents);
        Assert.Equal(expected, actual, 12);
    }
}
