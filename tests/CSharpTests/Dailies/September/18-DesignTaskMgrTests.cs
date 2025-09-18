using Xunit;

namespace LeetCode.Tests.Dailies.September;

public class TaskManager
{
    [Fact]
    public void LeetCodeSample()
    {
        IList<IList<int>> init = new List<IList<int>> {
            new List<int> { 1, 101, 10 },
            new List<int> { 2, 102, 20 },
            new List<int> { 3, 103, 15 },
        };

        var tm = new LeetCode.Dailies.DesignTaskMgr.TaskManager(init);
        tm.Add(4, 104, 5);
        tm.Edit(102, 8);

        int uid;
        uid = tm.ExecTop();
        Assert.Equal(3, uid);

        tm.Rmv(101);
        tm.Add(5, 105, 15);

        uid = tm.ExecTop();
        Assert.Equal(5, uid);
    }

    [Fact]
    public void LeetCodeSample2()
    {
        IList<IList<int>> init = new List<IList<int>> {
            new List<int> { 1, 101, 8 },
            new List<int> { 2, 102, 20 },
            new List<int> { 3, 103, 5 },
        };

        var tm = new LeetCode.Dailies.DesignTaskMgr.TaskManager(init);
        tm.Add(4, 104, 5);
        tm.Edit(102, 9);

        int uid;
        uid = tm.ExecTop();
        Assert.Equal(2, uid);

        tm.Rmv(101);
        tm.Add(50, 101, 8);

        uid = tm.ExecTop();
        Assert.Equal(50, uid);
    }

    [Fact]
    public void LeetCodeSample3()
    {
        IList<IList<int>> init = new List<IList<int>> {
            new List<int> { 4, 15, 33 },
        };

        var tm = new LeetCode.Dailies.DesignTaskMgr.TaskManager(init);
        int uid;
        uid = tm.ExecTop();
        Assert.Equal(4, uid);
    }

    [Fact]
    public void LeetCodeSample4()
    {
        IList<IList<int>> init = new List<IList<int>> {
            new List<int> { 10, 26, 25 },
        };

        var tm = new LeetCode.Dailies.DesignTaskMgr.TaskManager(init);

        tm.Rmv(26);

        int uid;
        uid = tm.ExecTop();
        Assert.Equal(-1, uid);
    }

    [Fact]
    public void LeetCodeSample5()
    {
        IList<IList<int>> init = new List<IList<int>> {
            new List<int> { 10, 26, 25 },
        };

        var tm = new LeetCode.Dailies.DesignTaskMgr.TaskManager(init);
        int uid;
        uid = tm.ExecTop();
        Assert.Equal(10, uid);

        uid = tm.ExecTop();
        Assert.Equal(-1, uid);
    }

    [Fact]
    public void LeetCodeSample6()
    {
        IList<IList<int>> init = new List<IList<int>> {
            new List<int> { 8, 27, 21 },
            new List<int> { 10, 17, 36 },
        };

        var tm = new LeetCode.Dailies.DesignTaskMgr.TaskManager(init);
        int uid;
        uid = tm.ExecTop();
        Assert.Equal(10, uid);

        uid = tm.ExecTop();
        Assert.Equal(8, uid);
    }

    [Fact]
    public void ExecTop_MultipleTasksShareMaxPriority()
    {
        IList<IList<int>> init = new List<IList<int>>
        {
            new List<int> { 1, 10, 5 },
            new List<int> { 2, 20, 5 },
        };

        var tm = new LeetCode.Dailies.DesignTaskMgr.TaskManager(init);

        int uid = tm.ExecTop();
        Assert.Equal(2, uid);

        uid = tm.ExecTop();
        Assert.Equal(1, uid);
    }

    [Fact]
    public void Edit_WhenOtherTasksKeepOldPriority()
    {
        IList<IList<int>> init = new List<IList<int>>
        {
            new List<int> { 1, 10, 7 },
            new List<int> { 2, 20, 7 },
        };

        var tm = new LeetCode.Dailies.DesignTaskMgr.TaskManager(init);

        tm.Edit(20, 3);

        int uid = tm.ExecTop();
        Assert.Equal(1, uid);
    }
}