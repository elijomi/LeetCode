namespace LeetCode.Dailies.DesignTaskMgr;

public class TaskManager
{
    private readonly IDictionary<int, (int prio, int userId)> _taskById;
    private readonly SortedDictionary<int, SortedSet<int>> _taskIdByPriority;
    private SortedSet<int> _priorities;

    public TaskManager(IList<IList<int>> tasks)
    {
        _taskById = new Dictionary<int, (int prio, int userId)>();
        _taskIdByPriority = new SortedDictionary<int, SortedSet<int>>();
        _priorities = new SortedSet<int>();
        foreach (IList<int> task in tasks)
        {
            int taskId = task[1];
            int p = task[2];
            _taskById.Add(taskId, (p, task[0])); // task[0]:userID
            AddByPriority(taskId, p);
        }
    }

    public void Add(int userId, int taskId, int priority)
    {
        _taskById.Add(taskId, (priority, userId));
        AddByPriority(taskId, priority);

    }

    public void Edit(int taskId, int newPriority)
    {
        var t = _taskById[taskId];
        if (newPriority == t.prio) return;
        _taskById[taskId] = (newPriority, t.userId);
        RemoveByPriority(taskId, t.prio);
        AddByPriority(taskId, newPriority);
    }

    public void Rmv(int taskId)
    {
        var t = _taskById[taskId];
        _taskById.Remove(taskId);
        RemoveByPriority(taskId, t.prio);
    }

    public int ExecTop()
    {
        if (_taskIdByPriority.Count == 0) return -1; // no tasks left

        int maxPrio = _priorities.Max;
        int taskId = _taskIdByPriority[maxPrio].Max;
        int userId = _taskById[taskId].userId;
        RemoveByPriority(taskId, maxPrio);
        _taskById.Remove(taskId);
        return userId;
    }

    private void AddByPriority(int taskId, int priority)
    {
        if (_taskIdByPriority.TryGetValue(priority, out var ids)) ids.Add(taskId);
        else _taskIdByPriority.Add(priority, new SortedSet<int> { taskId });
        _priorities.Add(priority);
    }

    private void RemoveByPriority(int taskId, int priority)
    {
        _taskIdByPriority[priority].Remove(taskId);
        if (_taskIdByPriority[priority].Count == 0)
        {
            _taskIdByPriority.Remove(priority);
            _priorities.Remove(priority);
        } 
    }
}