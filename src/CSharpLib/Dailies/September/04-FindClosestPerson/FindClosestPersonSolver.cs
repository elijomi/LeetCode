namespace LeetCode.Dailies.FindClosestPerson;

public class FindClosestPersonSolver
{
    /// <summary>
    /// You are given three integers x, y, and z, representing the positions of three people on a number line:
    /// x is the position of Person 1.
    /// y is the position of Person 2.
    /// z is the position of Person 3, who does not move.
    /// 
    /// Both Person 1 and Person 2 move toward Person 3 at the same speed.
    /// 
    /// Determine which person reaches Person 3 first:
    /// Return 1 if Person 1 arrives first.
    /// Return 2 if Person 2 arrives first.
    /// Return 0 if both arrive at the same time.
    /// 
    /// Constraints:
    /// 1 <= x, y, z <= 100
    /// 
    /// https://leetcode.com/problems/find-closest-person
    /// </summary>
    /// <param name="x">Position of person 1</param>
    /// <param name="y">Position of Person 2</param>
    /// <param name="z">Position of person 3</param>
    /// <returns>The person ID closest to person 3, or 0 if they are equally close</returns>
    public int FindClosest(int x, int y, int z)
    {
        int dist1 = Math.Abs(z - x);
        int dist2 = Math.Abs(z - y);
        if (dist1 < dist2) return 1;
        if (dist2 < dist1) return 2;
        return 0;
    }
}
