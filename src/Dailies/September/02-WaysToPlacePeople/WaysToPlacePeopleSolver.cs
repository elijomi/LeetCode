namespace LeetCode.Dailies.WaysToPlacePeople;

public class WaysToPlacePeopleSolver
{
    /// <summary>
    /// Find the number of points which make up the upper left corner of a rectangle defined by any other point 
    /// in the list which is not itself, such that no other points in the list are contained within the rectangle. 
    /// 
    /// Border points are considered to be contained within the rectangle. 
    /// Degenerate rectangles (same x or same y) are allowed
    /// 
    /// Constraints as of Sep 2nd 2025:
    /// 2 <= n <= 50
    /// points[i].length == 2
    /// 0 <= points[i][0], points[i][1] <= 50
    /// All points[i] are distinct.
    /// 
    /// Constraints as of Sep 3rd 2025:
    /// 2 <= n <= 1000
    /// points[i].length == 2
    /// -10^9 <= points[i][0], points[i][1] <= 10^9
    /// All points[i] are distinct.
    /// 
    /// https://leetcode.com/problems/find-the-number-of-ways-to-place-people-i)
    /// 
    /// Performance improvements made on Sep 3rd 2025 as per Leetcode Daily Sep 3rd 2025 
    // (https://leetcode.com/problems/find-the-number-of-ways-to-place-people-ii)  
    /// </summary>
    public int NumberOfPairs(int[][] points)
    {
        var count = 0;

        Array.Sort(points, (x, y) =>
        {
            int cmp = x[0].CompareTo(y[0]);   // primary: ascending by [0]
            if (cmp != 0) return cmp;
            return y[1].CompareTo(x[1]);      // tie-break: descending by [1]
        });

        for (int i = 0; i < points.Length; i++)
        {
            int topY = points[i][1];
            int maxYInRange = int.MinValue;

            for (int j = i + 1; j < points.Length; j++)
            {
                int yj = points[j][1];

                if (yj <= topY)     // must be lower in y to be lr corner
                {
                    if (maxYInRange < yj)
                    {
                        count++;    // no intervening point lies inside [yj, topY]
                        maxYInRange = yj;
                        
                        if (maxYInRange == topY) break; // no further points can qualify
                    }
                }
            }
        }

        return count;
    }
}
