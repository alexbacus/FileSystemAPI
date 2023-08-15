using FileSystem.Models.Enums;
using FileSystemAPI.Models;
using File = FileSystemAPI.Models.File;

namespace FileSystemAPI.Interfaces
{
    public interface IFileManager
    {
        File CreateFile(string name, int id, User user, FsEntry parent, List<Permission> permissions, string extension, string path);

        File GetFile(string path);

        string ReadFile(string path);

        void UpdateFile(string path, File file);

        void WriteFile(string path, string content);

        void DeleteFile(string path);

        List<File> GetFilesForPath(string directoryPath);

        void UpdateFilePermissions(List<Permission> permissions, string filePath);
    }
}
