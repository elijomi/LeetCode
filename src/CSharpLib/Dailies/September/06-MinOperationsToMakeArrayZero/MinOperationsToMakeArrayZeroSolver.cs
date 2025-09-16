namespace LeetCode.Dailies.MinOperationsToMakeArrayZero;

/// <summary>
/// You are given a 2D array queries, where queries[i] is of the form [l, r]. Each queries[i] defines 
/// an array of integers nums consisting of elements ranging from l to r, both inclusive.
/// 
/// In one operation, you can:
/// Select two integers a and b from the array.
/// Replace them with floor(a / 4) and floor(b / 4).
/// 
/// Your task is to determine the minimum number of operations required to reduce all elements of the 
/// array to zero for each query. Return the sum of the results for all queries.
/// 
/// Constraints:
/// 1 <= queries.length <= 10^5
/// queries[i].length == 2
/// queries[i] == [l, r]
/// 1 <= l < r <= 10^9
/// 
/// https://leetcode.com/problems/minimum-operations-to-make-array-elements-zero
/// </summary>
public class MinOperationsToMakeArrayZeroSolution
{
    public long MinOperations(int[][] queries)
    {
        long maxR = 0;
        foreach (var q in queries)
            if (q[1] > maxR) maxR = q[1];

        // Build powers of 4 up to maxR
        long[] pow4 = new long[40];
        pow4[0] = 1;
        int powCount = 1;
        while (pow4[powCount - 1] <= maxR / 4)
        {
            pow4[powCount] = pow4[powCount - 1] << 2; // multiply by 4
            powCount++;
        }

        // Build prefix sum of whole base 4 blocks
        long[] prefixFull = new long[powCount];
        prefixFull[0] = 0;
        for (int j = 0; j < powCount - 1; j++)
        {
            long term = (1L + j) * 3L * pow4[j];
            prefixFull[j + 1] = prefixFull[j] + term;
        }

        long answer = 0;
        foreach (var q in queries)
        {
            long l = q[0], r = q[1];
            long totalSteps = SumHUpTo(r, pow4, prefixFull, powCount) -
                              SumHUpTo(l - 1, pow4, prefixFull, powCount);
            long ops = (totalSteps + 1) >> 1; // ceil(total/2)
            answer += ops;
        }
        return answer;
    }

    private static long SumHUpTo(long x, long[] pow4, long[] prefixFull, int powCount)
    {
        if (x <= 0) return 0;

        int k = FloorIndexPow4(x, pow4, powCount);
        long partialCount = x - pow4[k] + 1;
        long partialSum = (1L + k) * partialCount;

        return prefixFull[k] + partialSum;
    }

    private static int FloorIndexPow4(long x, long[] pow4, int powCount)
    {
        int lo = 0, hi = powCount - 1;
        while (lo < hi)
        {
            int mid = (lo + hi + 1) >> 1;
            if (pow4[mid] <= x) lo = mid; else hi = mid - 1;
        }
        return lo;
    }
}
