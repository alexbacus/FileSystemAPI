using FileSystem.Models.Enums;
using FileSystemAPI.Interfaces;
using FileSystemAPI.Models;

namespace FileSystemAPI.Managers
{
    public class UserManager : IUserManager
    {
        public User ReadUser(string username)
        {
            // check current user's permissions before executing
            return new User();
        }

        public void UpdateUser(int id, User user)
        {
            // check current user's permissions before executing
            // update user
        }

        public void DeleteUser(int id)
        {
            // check current user's permissions before executing
            // delete user
        }

        public void AssignPermission(int userId, string path, Permission permission)
        {
            // check current user's permissions before executing
            // find user by Id
        }

        public Dictionary<string, Permission> ReadPermissions(int userId)
        {
            // check current user's permissions before executing
            // find user by Id
            return new Dictionary<string, Permission>();
        }

        public void RemovePermission(int userId, string path)
        {
            // check current user's permissions before executing
            // find user by Id
        }

        public List<Permission> ReadPermissionsForPath(string path, int userId)
        {
            // check current user's permissions before executing
            // find user by Id
            // get all associated permissions for path
            return new List<Permission>();
        }
    }
}
