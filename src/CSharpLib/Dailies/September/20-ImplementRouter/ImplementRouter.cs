namespace LeetCode.Dailies.ImplementRouter;

using System;
using System.Collections.Generic;

public class Router
{
    private readonly int limit;
    private readonly Queue<Packet> q = new();
    private readonly HashSet<(int s, int d, int t)> seen = new();
    private readonly Dictionary<int, DestIndex> byDest = new();

    private readonly struct Packet
    {
        public readonly int S, D, T;
        public Packet(int s, int d, int t) { S = s; D = d; T = t; }
        public (int, int, int) Key => (S, D, T);
        public int[] ToArray() => new[] { S, D, T };
    }

    private sealed class DestIndex
    {
        public readonly List<int> Times = new();
        public int Head;

        public void Add(int t) => Times.Add(t);

        public void RemoveOldest()
        {
            if (Head < Times.Count) Head++; // alwys non-decreasing ts
        }

        public int CountInRange(int start, int end)
        {
            int n = Times.Count;
            int lo = Head, hi = n;
            if (lo >= hi) return 0;

            int left = LowerBound(Times, lo, hi, start);
            int right = UpperBound(Times, lo, hi, end);
            int cnt = right - left;
            return cnt < 0 ? 0 : cnt;
        }

        private static int LowerBound(List<int> a, int lo, int hi, int x)
        {
            while (lo < hi)
            {
                int mid = (lo + hi) >> 1;
                if (a[mid] < x) lo = mid + 1; else hi = mid;
            }
            return lo;
        }

        private static int UpperBound(List<int> a, int lo, int hi, int x)
        {
            while (lo < hi)
            {
                int mid = (lo + hi) >> 1;
                if (a[mid] <= x) lo = mid + 1; else hi = mid;
            }
            return lo;
        }
    }

    public Router(int memoryLimit)
    {
        limit = memoryLimit;
    }

    public bool AddPacket(int source, int destination, int timestamp)
    {
        var p = new Packet(source, destination, timestamp);
        if (!seen.Add(p.Key)) return false; // dup
        
        if (q.Count == limit) EvictOne(); // honor limit

        q.Enqueue(p);
        if (!byDest.TryGetValue(destination, out var idx))
            byDest[destination] = idx = new DestIndex();

        idx.Add(timestamp);
        return true;
    }

    public int[] ForwardPacket()
    {
        if (q.Count == 0) return Array.Empty<int>();
        var p = q.Dequeue();
        seen.Remove(p.Key);

        var idx = byDest[p.D]; // update per-destination index
        idx.RemoveOldest();
        if (idx.Head == idx.Times.Count)
            byDest.Remove(p.D);

        return p.ToArray();
    }

    public int GetCount(int destination, int startTime, int endTime)
    {
        return byDest.TryGetValue(destination, out var idx)
            ? idx.CountInRange(startTime, endTime)
            : 0;
    }

    private void EvictOne()
    {
        var old = q.Dequeue();
        seen.Remove(old.Key);

        var idx = byDest[old.D];
        idx.RemoveOldest();
        if (idx.Head == idx.Times.Count)
            byDest.Remove(old.D);
    }
}
