namespace LeetCode.Dailies.FoodRatingSystem;

public class FoodRatings
{
    private readonly Dictionary<string, (int rating, string cuisine)> foodInfo;
    private readonly Dictionary<string, SortedSet<(int rating, string name)>> byCuisine;
    private static readonly IComparer<(int rating, string name)> EntryComparer = new RatingNameComparer();

    public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
    {
        int n = foods.Length;
        foodInfo = new Dictionary<string, (int, string)>(n, StringComparer.Ordinal);
        byCuisine = new Dictionary<string, SortedSet<(int, string)>>(StringComparer.Ordinal);

        for (int i = 0; i < n; i++)
        {
            string f = foods[i];
            string c = cuisines[i];
            int r = ratings[i];

            foodInfo[f] = (r, c);

            if (!byCuisine.TryGetValue(c, out var set))
            {
                set = new SortedSet<(int rating, string name)>(EntryComparer);
                byCuisine[c] = set;
            }

            set.Add((r, f));
        }
    }

    public void ChangeRating(string food, int newRating)
    {
        var (oldRating, cuisine) = foodInfo[food];
        if (oldRating == newRating) return; // no-op

        var set = byCuisine[cuisine];

        set.Remove((oldRating, food));
        set.Add((newRating, food));

        foodInfo[food] = (newRating, cuisine);
    }

    public string HighestRated(string cuisine)
    {
        var set = byCuisine[cuisine];
        var best = set.Min;
        return best.name;
    }

    private sealed class RatingNameComparer : IComparer<(int rating, string name)>
    {
        public int Compare((int rating, string name) x, (int rating, string name) y)
        {
            int byRating = y.rating.CompareTo(x.rating);
            if (byRating != 0) return byRating;

            int byName = string.CompareOrdinal(x.name, y.name);
            if (byName != 0) return byName;

            return 0;
        }
    }
}