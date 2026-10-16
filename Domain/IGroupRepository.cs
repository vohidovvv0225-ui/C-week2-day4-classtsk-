
namespace Domain;

public interface IGroupRepository
{
    void CreateGroup(Group group);
    Group? GetGroups(int id);
    bool UpdateGroup(int id, string name, string description);
    bool DeleteGroup(int id);
}
