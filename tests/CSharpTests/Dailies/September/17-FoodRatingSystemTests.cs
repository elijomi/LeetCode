using LeetCode.Dailies.FoodRatingSystem;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class FoodRatingSystemTests
{
    [Fact]
    public void LeetCodeSample()
    {
        var foods = new[] { "kimchi", "miso", "sushi", "moussaka", "ramen", "bulgogi" };
        var cuisines = new[] { "korean", "japanese", "japanese", "greek", "japanese", "korean" };
        var ratings = new[] { 9, 12, 8, 15, 14, 7 };

        var fr = new FoodRatings(foods, cuisines, ratings);

        Assert.Equal("kimchi", fr.HighestRated("korean"));
        Assert.Equal("ramen", fr.HighestRated("japanese"));

        fr.ChangeRating("sushi", 16);
        Assert.Equal("sushi", fr.HighestRated("japanese"));

        fr.ChangeRating("ramen", 16);
        Assert.Equal("ramen", fr.HighestRated("japanese"));
    }
}
