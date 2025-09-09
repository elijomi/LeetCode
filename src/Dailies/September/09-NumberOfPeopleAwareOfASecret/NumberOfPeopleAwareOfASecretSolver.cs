namespace LeetCode.Dailies.NumberOfPeopleAwareOfASecret;

/// <summary>
/// On day 1, one person discovers a secret. You are given an integer delay, which means that each 
/// person will share the secret with a new person every day, starting from delay days after 
/// discovering the secret. You are also given an integer forget, which means that each person will 
/// forget the secret forget days after discovering it. A person cannot share the secret on the same 
/// day they forgot it, or on any day afterwards. Given an integer n, return the number of people 
/// who know the secret at the end of day n. 
/// 
/// Since the answer may be very large, return it modulo 10^9 + 7.
/// 
/// Constraints:
/// 2 <= n <= 1000
/// 1 <= delay < forget <= n
/// 
/// https://leetcode.com/problems/number-of-people-aware-of-a-secret
/// </summary>
public class NumberOfPeopleAwareOfASecretSolution
{
    public int PeopleAwareOfSecret(int n, int delay, int forget)
    {
        const int MOD = 1_000_000_007;
        int[] knowsPerDay = new int[n + 1];
        knowsPerDay[1] = 1;   // day 1, 1 person learns
        long knowsToday = 0;

        for (int i = 2; i <= n; i++)
        {
            if (i - delay >= 1) knowsToday += knowsPerDay[i - delay];
            if (i - forget >= 1) knowsToday -= knowsPerDay[i - forget];

            knowsToday %= MOD;
            if (knowsToday < 0) knowsToday += MOD;

            knowsPerDay[i] = (int)knowsToday;
        }

        long res = 0;
        int start = Math.Max(1, n - forget + 1);
        for (int i = start; i <= n; i++)
        {
            res += knowsPerDay[i];
            if (res >= MOD) res -= MOD;
        }

        return (int)(res % MOD);
    }
}
