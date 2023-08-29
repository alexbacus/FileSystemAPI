using FileSystem.Models.Enums;
using FileSystemAPI.Interfaces;
using FileSystemAPI.Models;
using System.Web;
using Directory = FileSystemAPI.Models.Directory;

namespace FileSystemAPI.Managers
{
    public class DirectoryManager : IDirectoryManager
    {
        private readonly FileSystemContext context;
        public DirectoryManager(FileSystemContext context)
        {
            this.context = context;
        }

        public Directory CreateDirectory(string name, string path, string parentPath)
        {
            var parent = ReadDirectory(parentPath);
            if (parent == null)
                throw new Exception($"Parent directory not found: {parentPath}");

            path = HttpUtility.UrlDecode(path);
            var directory = new Models.Data.DirectoryModel
            {
                Name = name,
                Path = path,
                ParentId = parent.Id
            };
            this.context.Add(directory);
            this.context.SaveChanges();
            return new Directory { Name = name, Path = path};
        }

        public Models.Data.DirectoryModel ReadDirectory(string path)
        {
            path = HttpUtility.UrlDecode(path);
            var directory = context.Directories.Where(p => p.Path == path).FirstOrDefault();
            return directory ?? (directory = new Models.Data.DirectoryModel { Name = "Not Found"});
        }

        public void UpdateDirectory(string path, string name)
        {
            // check current user's permissions for path before executing
            // update directory
            var directory = context.Directories.Where(p => p.Path == path).FirstOrDefault();
            if (directory == null)
            {
                throw new Exception("Directory not found.");
            }
            directory.Name = name;
            context.SaveChanges();
        }

        public void DeleteDirectory(string path)
        {
            // check current user's permissions for path before executing
            // delete directory
            var directory = context.Directories.Where(p => p.Path == path).FirstOrDefault();
            if (directory == null)
            {
                throw new Exception("Directory not found.");
            }
            this.context.Remove(directory);
            this.context.SaveChanges();
        }

        public void UpdateDirectoryPermissions(List<Permission> permissions, string directoryPath)
        {
            // update/set directory permissions
        }
    }
}
