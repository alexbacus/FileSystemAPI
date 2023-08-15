using FileSystem.Models.Enums;
using FileSystemAPI.Models;
using Directory = FileSystemAPI.Models.Directory;

namespace FileSystemAPI.Interfaces
{
    public interface IDirectoryManager
    {
        Directory CreateDirectory(string name, int id, User user, FsEntry parent, List<Permission> permissions, string path);

        Directory ReadDirectory(string path);

        void UpdateDirectory(string name, Directory directory);

        void DeleteDirectory(string name);

        void UpdateDirectoryPermissions(List<Permission> permissions, string directoryPath);
    }
}
