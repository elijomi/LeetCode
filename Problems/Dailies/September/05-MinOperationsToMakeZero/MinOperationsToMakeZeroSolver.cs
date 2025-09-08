using System.Numerics;

namespace LeetCodeProblems.Dailies.MinOperationsToMakeZero;

/// <summary>
/// You are given two integers num1 and num2. In one operation, you can choose integer i in the 
/// range [0, 60] and subtract 2^i + num2 from num1. Return the integer denoting the minimum 
/// number of operations needed to make num1 equal to 0. If it is impossible to make num1 equal 
/// to 0, return -1.
/// 
/// Constraints:
/// 1 <= num1 <= 10^9
/// -109 <= num2 <= 10^9
/// </summary>
public class Solution
{
    public int MakeTheIntegerZero(int num1, int num2)
    {
        if (num1 == 0) return 0;
        if (num2 > 0 && num1 < num2 + 1) return -1; // impossible since every operation reduces num1 by at least (1 + num2)

        for (var k = 1; k <= 60; k++)
        {
            long t = num1 - k * (long)num2;
            if (k > t) return -1;   
            if (k < BitOperations.PopCount((ulong)t)) continue;

            return k;
        }

        return -1;
    }
}