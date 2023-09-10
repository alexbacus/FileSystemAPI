using FileSystem.Models.Enums;
using FileSystemAPI.Models;
using Directory = FileSystemAPI.Models.Directory;

namespace FileSystemAPI.Interfaces
{
    public interface IDirectoryManager
    {
        Directory CreateDirectory(string name, string path, string parentPath, int authorId);

        Models.Data.DirectoryModel ReadDirectory(string path);

        void UpdateDirectory(string path, string name);

        void DeleteDirectory(string path);

        void UpdateDirectoryPermissions(List<Permission> permissions, string directoryPath);
    }
}
