using FileSystem.Models.Enums;
using FileSystemAPI.Models;
using File = FileSystemAPI.Models.File;

namespace FileSystemAPI.Interfaces
{
    public interface IFileManager
    {
        File CreateFile(string name, string path, string parentPath, string extension, int authorId);

        Models.Data.FileModel GetFile(string path);

        string ReadFile(string path);

        void UpdateFile(string path, string name, string content, string extension);

        void WriteFile(string path, string content);

        void DeleteFile(string path);

        List<File> GetFilesForPath(string directoryPath);

        void UpdateFilePermissions(List<Permission> permissions, string filePath);
    }
}
