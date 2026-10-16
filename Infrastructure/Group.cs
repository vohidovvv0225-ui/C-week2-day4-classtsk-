
using Domain;

namespace Infrastructure;

public class GroupRepository : IGroupRepository
{
    private readonly List<Group> _groups = new();

    public void CreateGroup(Group group)
    {
        if (_groups.Exists(g => g.Id == group.Id))
        {
            Console.WriteLine("Group with this ID already exists!");
            return;
        }

        _groups.Add(group);
        Console.WriteLine("Group created successfully!");
    }

    public Group? GetGroups(int id)
    {
        return _groups.Find(g => g.Id == id);
    }

    public bool UpdateGroup(int id, string name, string description)
    {
        Group? group = GetGroups(id);

        if (group == null)
            return false;

        group.Name = name;
        group.Description = description;

        return true;
    }

    public bool DeleteGroup(int id)
    {
        Group? group = GetGroups(id);

        if (group == null)
            return false;

        _groups.Remove(group);
        return true;
    }
}
