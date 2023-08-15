using FileSystem.Models.Enums;
using FileSystemAPI.Models;

namespace FileSystemAPI.Interfaces
{
    public interface IUserManager
    {
        User ReadUser(string username);

        void UpdateUser(int id, User user);

        void DeleteUser(int id);

        void AssignPermission(int userId, string path, Permission permission);

        Dictionary<string, Permission> ReadPermissions(int userId);

        void RemovePermission(int userId, string path);

        List<Permission> ReadPermissionsForPath(string path, int userId);
    }
}
