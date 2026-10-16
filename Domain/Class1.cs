
namespace Domain;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Group(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}
