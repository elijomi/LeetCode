using LeetCode.Dailies.ImplementRouter;
using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class RouterTests
{
    [Fact]
    public void AddPacket_NewPacket_ReturnsTrue()
    {
        var router = new Router(memoryLimit: 3);

        var ok = router.AddPacket(1, 10, 100);

        Assert.True(ok);
        Assert.Equal(new[] { 1, 10, 100 }, router.ForwardPacket());
    }

    [Fact]
    public void AddPacket_Duplicate_ReturnsFalse_AndDoesNotAlterState()
    {
        var router = new Router(3);
        Assert.True(router.AddPacket(1, 10, 100));

        var dup = router.AddPacket(1, 10, 100);

        Assert.False(dup);
        // Only the original packet should be present
        Assert.Equal(new[] { 1, 10, 100 }, router.ForwardPacket());
        Assert.Empty(router.ForwardPacket());
    }

    [Fact]
    public void ForwardPacket_EmptyQueue_ReturnsEmptyArray()
    {
        var router = new Router(2);

        var pkt = router.ForwardPacket();

        Assert.NotNull(pkt);
        Assert.Empty(pkt);
    }

    [Fact]
    public void ForwardPacket_FifoOrder()
    {
        var router = new Router(5);
        router.AddPacket(1, 7, 10);
        router.AddPacket(2, 7, 20);
        router.AddPacket(3, 8, 30);

        Assert.Equal(new[] { 1, 7, 10 }, router.ForwardPacket());
        Assert.Equal(new[] { 2, 7, 20 }, router.ForwardPacket());
        Assert.Equal(new[] { 3, 8, 30 }, router.ForwardPacket());
        Assert.Empty(router.ForwardPacket());
    }

    [Fact]
    public void AddPacket_WhenFull_EvictsOldest_ToMakeRoom()
    {
        var router = new Router(2);
        router.AddPacket(1, 5, 10); // oldest
        router.AddPacket(2, 5, 20);

        // Adding third should auto-evict (1,5,10)
        Assert.True(router.AddPacket(3, 6, 30));

        // Now the oldest should be (2,5,20)
        Assert.Equal(new[] { 2, 5, 20 }, router.ForwardPacket());
        Assert.Equal(new[] { 3, 6, 30 }, router.ForwardPacket());
        Assert.Empty(router.ForwardPacket());
    }

    [Fact]
    public void GetCount_InclusiveRange_OnlyCurrentPackets()
    {
        var router = new Router(5);
        router.AddPacket(1, 9, 100); // will be forwarded
        router.AddPacket(2, 9, 110); // will be forwarded
        router.AddPacket(3, 9, 120); // will be forwarded
        router.AddPacket(4, 9, 130); // stays

        // Forward one packet (the oldest: timestamp 100)
        Assert.Equal(new[] { 1, 9, 100 }, router.ForwardPacket());

        // Count for destination 9 in [105, 125] should include timestamps 110 and 120 only
        Assert.Equal(2, router.GetCount(9, 105, 125));

        // After forwarding (3,9,120), count changes
        Assert.Equal(new[] { 2, 9, 110 }, router.ForwardPacket());
        Assert.Equal(new[] { 3, 9, 120 }, router.ForwardPacket());
        Assert.Equal(0, router.GetCount(9, 105, 125)); 
    }

    [Fact]
    public void GetCount_MultipleDestinations_Independent()
    {
        var router = new Router(6);
        router.AddPacket(1, 100, 10);
        router.AddPacket(2, 200, 12);
        router.AddPacket(3, 100, 15);
        router.AddPacket(4, 200, 20);

        Assert.Equal(2, router.GetCount(100, 1, 20)); // timestamps 10, 15
        Assert.Equal(2, router.GetCount(200, 1, 20)); // timestamps 12, 20
        Assert.Equal(1, router.GetCount(100, 11, 15)); // only 15
        Assert.Equal(0, router.GetCount(200, 1, 11));  // none <= 11
    }

    [Fact]
    public void EvictionAlsoUpdatesCounts()
    {
        var router = new Router(2);
        router.AddPacket(1, 50, 100); // will be evicted
        router.AddPacket(2, 50, 200);

        // Cause eviction of the oldest (timestamp 100)
        router.AddPacket(3, 50, 300);

        // Only timestamps 200 and 300 remain for dest 50
        Assert.Equal(2, router.GetCount(50, 1, 1000));
        Assert.Equal(1, router.GetCount(50, 250, 350));
        Assert.Equal(0, router.GetCount(50, 1, 150)); // 100 was evicted
    }

    [Fact]
    public void DuplicateDoesNotEvictOrForwardAnything()
    {
        var router = new Router(2);
        router.AddPacket(10, 1, 5);   // oldest
        router.AddPacket(11, 1, 6);   // newest

        // Duplicate insert
        Assert.False(router.AddPacket(10, 1, 5));

        // State unchanged
        Assert.Equal(new[] { 10, 1, 5 }, router.ForwardPacket());
        Assert.Equal(new[] { 11, 1, 6 }, router.ForwardPacket());
        Assert.Empty(router.ForwardPacket());
    }

    [Fact]
    public void CountRangeBoundaries_AreInclusive()
    {
        var router = new Router(5);
        router.AddPacket(1, 3, 100);
        router.AddPacket(2, 3, 200);
        router.AddPacket(3, 3, 300);

        Assert.Equal(1, router.GetCount(3, 100, 100)); // includes 100
        Assert.Equal(1, router.GetCount(3, 300, 300)); // includes 300
        Assert.Equal(3, router.GetCount(3, 100, 300)); // includes all
        Assert.Equal(2, router.GetCount(3, 101, 300)); // excludes 100
        Assert.Equal(0, router.GetCount(3, 301, 400)); // none
    }
}

