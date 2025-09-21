namespace LeetCode.Dailies.MovieRentalSystem;

sealed class PriceShopComparer : IComparer<(int price, int shop)>
{
    public int Compare((int price, int shop) a, (int price, int shop) b)
        => a.price != b.price ? a.price.CompareTo(b.price) : a.shop.CompareTo(b.shop);
}

sealed class RentedComparer : IComparer<(int price, int shop, int movie)>
{
    public int Compare((int price, int shop, int movie) a, (int price, int shop, int movie) b)
    {
        int c = a.price.CompareTo(b.price);
        if (c != 0) return c;
        c = a.shop.CompareTo(b.shop);
        if (c != 0) return c;
        return a.movie.CompareTo(b.movie);
    }
}

public class MovieRentingSystem
{
    private readonly Dictionary<(int shop, int movie), int> priceByPair = new();
    private readonly Dictionary<int, SortedSet<(int price, int shop)>> availableByMovie =
        new();
    private readonly SortedSet<(int price, int shop, int movie)> rented =
        new(new RentedComparer());
    private readonly PriceShopComparer availCmp = new();

    public MovieRentingSystem(int n, int[][] entries)
    {
        foreach (var e in entries)
        {
            int shop = e[0], movie = e[1], price = e[2];
            priceByPair[(shop, movie)] = price;
            if (!availableByMovie.TryGetValue(movie, out var set))
                availableByMovie[movie] = set = new SortedSet<(int, int)>(availCmp);
            set.Add((price, shop));
        }
    }

    public IList<int> Search(int movie)
    {
        if (!availableByMovie.TryGetValue(movie, out var set)) return new List<int>();
        var ans = new List<int>(5);
        foreach (var (_, shop) in set)
        {
            ans.Add(shop);
            if (ans.Count == 5) break;
        }
        return ans;
    }

    public void Rent(int shop, int movie)
    {
        int price = priceByPair[(shop, movie)];
        var set = availableByMovie[movie];
        set.Remove((price, shop));
        if (set.Count == 0) availableByMovie.Remove(movie); // optional cleanup
        rented.Add((price, shop, movie));
    }

    public void Drop(int shop, int movie)
    {
        int price = priceByPair[(shop, movie)];
        rented.Remove((price, shop, movie));
        if (!availableByMovie.TryGetValue(movie, out var set))
            availableByMovie[movie] = set = new SortedSet<(int, int)>(availCmp);
        set.Add((price, shop));
    }

    public IList<IList<int>> Report()
    {
        var ans = new List<IList<int>>(5);
        int i = 0;
        foreach (var (_, shop, movie) in rented)
        {
            ans.Add(new List<int> { shop, movie });
            if (++i == 5) break;
        }
        return ans;
    }
}
