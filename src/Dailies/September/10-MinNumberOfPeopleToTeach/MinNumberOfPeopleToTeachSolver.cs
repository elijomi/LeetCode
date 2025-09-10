namespace LeetCode.Dailies.MinNumberOfPeopleToTeach;

/// <summary>
/// On a social network consisting of m users and some friendships between users, two users can communicate with each other if they know a common language.
/// You are given an integer n, an array languages, and an array friendships where:
///  - There are n languages numbered 1 through n,
///  - languages[i] is the set of languages the i​​​​​​th​​​​ user knows, and
///  - friendships[i] = [u​​​​​​i​​​, v​​​​​​i] denotes a friendship between the users u​​​​​​​​​​​i​​​​​ and vi.
/// You can choose one language and teach it to some users so that all friends can communicate with each other. Return the minimum number of users you need to teach.
/// 
/// Note that friendships are not transitive, meaning if x is a friend of y and y is a friend of z, this doesn't guarantee that x is a friend of z.
/// 
/// Constraints:
/// 2 <= n <= 500
/// languages.length == m
/// 1 <= m <= 500
/// 1 <= languages[i].length <= n
/// 1 <= languages[i][j] <= n
/// 1 <= u​​​​​​i < v​​​​​​i <= languages.length
/// 1 <= friendships.length <= 500
/// All tuples (u​​​​​i, v​​​​​​i) are unique
/// languages[i] contains only unique values
/// 
/// https://leetcode.com/problems/minimum-number-of-people-to-teach
/// </summary>
public class MinNumberOfPeopleToTeachSolution
{
    public int MinimumTeachings(int n, int[][] languages, int[][] friendships)
    {
        // knows[u, l] => does user u know language l?
        var knows = new bool[languages.Length + 1, n + 1];
        for (int u = 1; u <= languages.Length; u++)
        {
            foreach (var l in languages[u - 1])
                knows[u, l] = true;
        }

        // users part of at least one friendship that currently can't communicate
        var problemUsers = new HashSet<int>();
        foreach (var f in friendships)
        {
            int u = f[0];
            int v = f[1];
            bool canCommunicate = false;

            foreach (var l in languages[u - 1])
            {
                if (knows[v, l])
                {
                    canCommunicate = true;
                    break;
                }
            }

            if (!canCommunicate)
            {
                problemUsers.Add(u);
                problemUsers.Add(v);
            }
        }

        if (problemUsers.Count == 0) return 0;  // all can communicate

        // check teacing "cost" for each lang, value min
        int answer = int.MaxValue;
        for (int l = 1; l <= n; l++)
        {
            int teach = 0;
            foreach (var u in problemUsers)
            {
                if (!knows[u, l]) teach++;
            }

            if (teach < answer) answer = teach;
        }

        return answer;
    }
}