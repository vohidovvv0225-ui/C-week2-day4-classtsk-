
using Domain;
using Infrastructure;

IGroupRepository repository = new GroupRepository();

while (true)
{
    Console.WriteLine("\n===== GROUP MANAGEMENT =====");
    Console.WriteLine("1. Create Group");
    Console.WriteLine("2. Get Group");
    Console.WriteLine("3. Update Group");
    Console.WriteLine("4. Delete Group");
    Console.WriteLine("0. Exit");
    Console.Write("Choose: ");

    string? choice = Console.ReadLine();

    if (choice == "0")
        break;

    switch (choice)
    {
        case "1":
            Console.Write("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID!");
                break;
            }

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Description: ");
            string description = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty!");
                break;
            }

            repository.CreateGroup(
                new Group(id, name, description));
            break;

        case "2":
            Console.Write("Enter group Id: ");
            if (!int.TryParse(Console.ReadLine(), out int searchId))
            {
                Console.WriteLine("Invalid ID!");
                break;
            }

            Group? found = repository.GetGroups(searchId);

            if (found == null)
            {
                Console.WriteLine("Group not found!");
            }
            else
            {
                Console.WriteLine($"Id: {found.Id}");
                Console.WriteLine($"Name: {found.Name}");
                Console.WriteLine($"Description: {found.Description}");
            }
            break;

        case "3":
            Console.Write("Enter group Id: ");
            if (!int.TryParse(Console.ReadLine(), out int updateId))
            {
                Console.WriteLine("Invalid ID!");
                break;
            }

            Console.Write("New name: ");
            string newName = Console.ReadLine() ?? "";

            Console.Write("New description: ");
            string newDescription = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("Name cannot be empty!");
                break;
            }

            if (repository.UpdateGroup(
                updateId, newName, newDescription))
            {
                Console.WriteLine("Group updated successfully!");
            }
            else
            {
                Console.WriteLine("Group not found!");
            }
            break;

        case "4":
            Console.Write("Enter group Id: ");
            if (!int.TryParse(Console.ReadLine(), out int deleteId))
            {
                Console.WriteLine("Invalid ID!");
                break;
            }

            if (repository.DeleteGroup(deleteId))
            {
                Console.WriteLine("Group deleted successfully!");
            }
            else
            {
                Console.WriteLine("Group not found!");
            }
            break;

        default:
            Console.WriteLine("Invalid choice!");
            break;
    }
}
