using FileSystem.Models.Enums;
using FileSystemAPI.Interfaces;
using FileSystemAPI.Models;
using File = FileSystemAPI.Models.File;
using Directory = FileSystemAPI.Models.Directory;
using System.Web;

namespace FileSystemAPI.Managers
{
    public class FileManager : IFileManager
    {
        private readonly FileSystemContext context;
        private readonly IDirectoryManager directoryManager;
        public FileManager(FileSystemContext context, IDirectoryManager directoryManager)
        {
            this.context = context;
            this.directoryManager = directoryManager;
        }

        public File CreateFile(string name, string path, string parentPath, string extension)
        {
            var parent = directoryManager.ReadDirectory(parentPath);
            if (parent == null)
                throw new Exception($"Parent directory not found: {parentPath}");

            path = HttpUtility.UrlDecode(path);
            var file = new Models.Data.FileModel
            {
                Name = name,
                Extension = extension,
                Path = path,
                ParentId = parent.Id
            };
            this.context.Add(file);
            this.context.SaveChanges();
            return new File { Name = name, Path = path };
        }

        public Models.Data.FileModel GetFile(string path)
        {
            // check current user's permissions for path before executing
            path = HttpUtility.UrlDecode(path);
            var directory = context.Files.Where(p => p.Path == path).FirstOrDefault();
            return directory ?? (directory = new Models.Data.FileModel { Name = "Not Found" });
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
