namespace LeetCode.Dailies.DesignTaskMgr;

public class TaskManager
{
    private readonly Dictionary<int, (int priority, int userId)> _taskById;
    private readonly PriorityQueue<(int taskId, int priority), (int negPriority, int negTaskId)> _queue;

    public TaskManager(IList<IList<int>> tasks)
    {
        _taskById = new Dictionary<int, (int priority, int userId)>(tasks.Count);
        _queue = new PriorityQueue<(int taskId, int priority), (int, int)>();

        foreach (var task in tasks)
        {
            int userId = task[0];
            int taskId = task[1];
            int priority = task[2];

            _taskById[taskId] = (priority, userId);
            _queue.Enqueue((taskId, priority), (-priority, -taskId));
        }
    }

    public void Add(int userId, int taskId, int priority)
    {
        _taskById[taskId] = (priority, userId);
        _queue.Enqueue((taskId, priority), (-priority, -taskId));
    }

    public void Edit(int taskId, int newPriority)
    {
        var (oldPriority, userId) = _taskById[taskId];
        if (oldPriority == newPriority) return;

        _taskById[taskId] = (newPriority, userId);
        _queue.Enqueue((taskId, newPriority), (-newPriority, -taskId));
    }

    public void Rmv(int taskId)
    {
        _taskById.Remove(taskId);
        // stale heap entries disappear when they bubble to the top
    }

    public int ExecTop()
    {
        while (_queue.Count > 0)
        {
            var (taskId, priority) = _queue.Dequeue();

            if (_taskById.TryGetValue(taskId, out var current) && current.priority == priority)
            {   
                _taskById.Remove(taskId);
                return current.userId;
            }
        }

        return -1;
    }
}
