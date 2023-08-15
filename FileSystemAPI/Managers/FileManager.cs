using FileSystem.Models.Enums;
using FileSystemAPI.Interfaces;
using FileSystemAPI.Models;
using File = FileSystemAPI.Models.File;

namespace FileSystemAPI.Managers
{
    public class FileManager : IFileManager
    {
        public File CreateFile(string name, int id, User user, FsEntry parent, List<Permission> permissions, string extension, string path)
        {
            return new File
            {
                Name = name,
                Id = id,
                User = user,
                Parent = parent,
                Permissions = permissions,
                Extension = extension,
                Path = path
            };
        }

        public File GetFile(string path)
        {
            // check current user's permissions for path before executing
            return new File();
        }

        public string ReadFile(string path)
        {
            // check current user's permissions for path before executing
            return "file content";
        }

        public void UpdateFile(string path, File file)
        {
            // check current user's permissions for path before executing
            // update file
        }

        public void WriteFile(string path, string content)
        {
            // check current user's permissions for path before executing
            // write file
        }

        public void DeleteFile(string path)
        {
            // check current user's permissions for path before executing
            // delete file
        }

        public List<File> GetFilesForPath(string directoryPath)
        {
            return new List<File>();
        }

        public void UpdateFilePermissions(List<Permission> permissions, string filePath)
        {
            // update/set file permissions
        }
    }
}
