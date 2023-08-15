using FileSystem.Models.Enums;
using FileSystemAPI.Interfaces;
using FileSystemAPI.Models;
using Directory = FileSystemAPI.Models.Directory;

namespace FileSystemAPI.Managers
{
    public class DirectoryManager : IDirectoryManager
    {
        public Directory CreateDirectory(string name, int id, User user, FsEntry parent, List<Permission> permissions, string path)
        {
            return new Directory
            {
                Name = name,
                Id = id,
                User = user,
                Parent = parent,
                Permissions = permissions,
                Path = path
            };
        }

        public Directory ReadDirectory(string path)
        {
            // check current user's permissions for path before executing
            return new Directory();
        }

        public void UpdateDirectory(string name, Directory directory)
        {
            // check current user's permissions for path before executing
            // update directory
        }

        public void DeleteDirectory(string name)
        {
            // check current user's permissions for path before executing
            // delete directory
        }

        public void UpdateDirectoryPermissions(List<Permission> permissions, string directoryPath)
        {
            // update/set directory permissions
        }
    }
}
