using LeetCode.Dailies.MovieRentalSystem;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class MovieRentingSystemTests
{
    private static int[][] E(params (int shop, int movie, int price)[] triples)
        => triples.Select(t => new[] { t.shop, t.movie, t.price }).ToArray();

    [Fact]
    public void Basic_EndToEnd_Scenario()
    {
        // shops: 0..2
        // inventory: (shop, movie, price)
        var entries = E(
            (0, 1, 5),  // movie 1 @ shop 0, price 5
            (0, 2, 6),
            (0, 3, 7),
            (1, 1, 4),  // movie 1 @ shop 1, price 4  (cheapest for movie 1)
            (1, 2, 7),
            (2, 1, 5)   // movie 1 @ shop 2, price 5
        );

        var sys = new MovieRentingSystem(3, entries);

        // Search movie 1 -> shops by (price, shop): (1@4), (0@5), (2@5)
        Assert.Equal(new List<int> { 1, 0, 2 }, sys.Search(1).ToList());

        // Rent (0,1) and (1,2)
        sys.Rent(0, 1);
        sys.Rent(1, 2);

        // After renting (0,1), available for movie 1: (1@4), (2@5)
        Assert.Equal(new List<int> { 1, 2 }, sys.Search(1).ToList());

        // Report should list rented pairs by (price, shop, movie):
        //   (0,1) price 5
        //   (1,2) price 7
        var report1 = sys.Report().Select(p => p.ToArray()).ToArray();
        Assert.Equal(new[] { new[] { 0, 1 }, new[] { 1, 2 } }, report1);

        // Drop (0,1) -> becomes available again
        sys.Drop(0, 1);

        // Search movie 1 again -> (1@4), (0@5), (2@5)
        Assert.Equal(new List<int> { 1, 0, 2 }, sys.Search(1).ToList());

        // Report now only has (1,2)
        var report2 = sys.Report().Select(p => p.ToArray()).ToArray();
        Assert.Equal(new[] { new[] { 1, 2 } }, report2);
    }

    [Fact]
    public void Search_TieBreaking_ByShopId_WhenPriceEqual()
    {
        var entries = E(
            (5, 10, 3),
            (2, 10, 3),
            (7, 10, 3),
            (1, 10, 3)
        );
        var sys = new MovieRentingSystem(8, entries);

        // All same price => sort by shop ascending
        Assert.Equal(new List<int> { 1, 2, 5, 7 }, sys.Search(10).ToList());
    }

    [Fact]
    public void Report_Sorting_PriceThenShopThenMovie()
    {
        var entries = E(
            (0, 1, 5),
            (0, 2, 5), // same price, same shop, different movie (sorted by movie)
            (1, 1, 4), // cheaper
            (2, 3, 5),
            (2, 2, 5), // same price, same shop, lower movie id than (2,3)
            (3, 9, 6)
        );
        var sys = new MovieRentingSystem(5, entries);

        sys.Rent(0, 1); // price 5
        sys.Rent(0, 2); // price 5
        sys.Rent(1, 1); // price 4
        sys.Rent(2, 2); // price 5
        sys.Rent(2, 3); // price 5
        sys.Rent(3, 9); // price 6

        // Sorted by (price, shop, movie). Top 5 only.
        var rep = sys.Report().Select(p => (shop: p[0], movie: p[1])).ToList();

        // Expected order:
        // (1,1) @4
        // (0,1) @5
        // (0,2) @5
        // (2,2) @5
        // (2,3) @5
        // (3,9) @6  -> truncated away (limit 5)
        Assert.Equal(5, rep.Count);
        Assert.Equal((1, 1), rep[0]);
        Assert.Equal((0, 1), rep[1]);
        Assert.Equal((0, 2), rep[2]);
        Assert.Equal((2, 2), rep[3]);
        Assert.Equal((2, 3), rep[4]);
    }

    [Fact]
    public void Search_ReturnsAtMostFive_AndReflectsRentsAndDrops()
    {
        // Many shops carry movie 7 with varying prices
        var entries = E(
            (0, 7, 10),
            (1, 7, 8),
            (2, 7, 9),
            (3, 7, 8),
            (4, 7, 7),
            (5, 7, 8),
            (6, 7, 6), // cheapest
            (7, 7, 12)
        );
        var sys = new MovieRentingSystem(10, entries);

        // Initial search -> 5 cheapest shops: price asc then shop
        // prices sorted: (6@6), (4@7), (1@8), (3@8), (5@8), (2@9), (0@10), (7@12)
        Assert.Equal(new List<int> { 6, 4, 1, 3, 5 }, sys.Search(7).ToList());

        // Rent two of the cheapest
        sys.Rent(6, 7); // price 6
        sys.Rent(4, 7); // price 7

        // Now top 5 should start with the next cheapest: (1@8), (3@8), (5@8), (2@9), (0@10)
        Assert.Equal(new List<int> { 1, 3, 5, 2, 0 }, sys.Search(7).ToList());

        // Drop one back
        sys.Drop(4, 7);

        // (4@7) reappears and is cheaper than the 8s -> should be first now (after (6@6) still rented)
        Assert.Equal(new List<int> { 4, 1, 3, 5, 2 }, sys.Search(7).ToList());
    }

    [Fact]
    public void Report_ReturnsAtMostFive_AndReflectsState()
    {
        var entries = E(
            (0, 1, 2),
            (1, 1, 1),
            (2, 2, 1),
            (3, 3, 1),
            (4, 4, 1),
            (5, 5, 1),
            (6, 6, 1)
        );
        var sys = new MovieRentingSystem(10, entries);

        // Rent 6 items; report should only return 5
        sys.Rent(1, 1); // price 1
        sys.Rent(2, 2); // 1
        sys.Rent(3, 3); // 1
        sys.Rent(4, 4); // 1
        sys.Rent(5, 5); // 1
        sys.Rent(6, 6); // 1

        var rep1 = sys.Report().Select(p => (shop: p[0], movie: p[1])).ToList();
        Assert.Equal(5, rep1.Count);

        // With same price, sort by shop then movie; expect shops 1..5
        Assert.Equal(new[] { (1, 1), (2, 2), (3, 3), (4, 4), (5, 5) }, rep1);

        // Drop (2,2) and (3,3); rent (0,1) (price 2) — appears after all price 1 in report
        sys.Drop(2, 2);
        sys.Drop(3, 3);
        sys.Rent(0, 1); // price 2

        var rep2 = sys.Report().Select(p => (shop: p[0], movie: p[1])).ToList();
        // Should include (1,1), (4,4), (5,5), (6,6), then (0,1)
        Assert.Equal(new[] { (1, 1), (4, 4), (5, 5), (6, 6), (0, 1) }, rep2);
    }

    [Fact]
    public void RentingRemovesFromSearch_DroppingRestores()
    {
        var entries = E((0, 9, 10), (1, 9, 9));
        var sys = new MovieRentingSystem(2, entries);

        // Cheapest first
        Assert.Equal(new List<int> { 1, 0 }, sys.Search(9).ToList());

        // Rent cheapest -> only shop 0 remains
        sys.Rent(1, 9);
        Assert.Equal(new List<int> { 0 }, sys.Search(9).ToList());

        // Drop back -> original order
        sys.Drop(1, 9);
        Assert.Equal(new List<int> { 1, 0 }, sys.Search(9).ToList());
    }
}
