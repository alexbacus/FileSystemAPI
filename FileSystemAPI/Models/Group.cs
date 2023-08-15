using FileSystem.Models.Enums;

namespace FileSystemAPI.Models
{
    public class Group
    {
        public int Id { get; set; }
        public List<User> Users { get; set; }
        public List<Permission> Permissions { get; set; }

        public Group CreateGroup(int id, List<User> users, List<Permission> permissions)
        {
            return new Group
            {
                Id = id,
                Users = users,
                Permissions = permissions
            };
        }

        public Group ReadGroup(int id)
        {
            // check current user's permissions before executing
            return new Group();
        }

        public void UpdateGroup(int id, Group group)
        {
            // check current user's permissions before executing
            // update group
        }

        public void DeleteGroup(int id)
        {
            // check current user's permissions before executing
            // delete group
        }
    }
}
