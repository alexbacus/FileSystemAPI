using FileSystem.Models.Enums;

namespace FileSystemAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public Dictionary<string, Permission> Permissions { get; set; }
        public List<Group> Groups { get; set; }

        public User CreateUser(int id, string name, Role role, Dictionary<string, Permission> permissions, List<Group> groups)
        {
            return new User
            {
                Id = id,
                Name = name,
                Role = role,
                Permissions = permissions,
                Groups = groups
            };
        }
    }
}
