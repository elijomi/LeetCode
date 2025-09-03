namespace LeetCodeProblems.Dailies.WaysToPlacePeople;

public class WaysToPlacePeopleSolver
{
    /// <summary>
    /// Check if point a is the upper left of a rectangle defined by points a and b, while making sure that
    /// point a is not the same as point b
    /// </summary>
    private static bool IsUpperLeft(int[] a, int[] b) => a[0] <= b[0] && a[1] >= b[1] &&
                                                        (a[0] != b[0] || a[1] != b[1]);

    /// <summary>
    /// Check if the rectangle defined by points a and b contains point c including edges, while making sure that
    /// point c is not the same as point a or point b
    /// </summary>
    /// <param name="a">The upper left point</param>
    /// <param name="b">The lower right point</param>
    /// <param name="c">The point to check if it is contained within the rectangle</param>
    private static bool ContainsPoint(int[] a, int[] b, int[] c) => a[0] <= c[0] && b[0] >= c[0] &&
                                                                a[1] >= c[1] && b[1] <= c[1] &&
                                                                (a[0] != c[0] || a[1] != c[1]) &&
                                                                (b[0] != c[0] || b[1] != c[1]);

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
    /// -109 <= points[i][0], points[i][1] <= 109
    /// All points[i] are distinct.
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
                    }                        
                }
            }
        }

        return count;
    }
}
