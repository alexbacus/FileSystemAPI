using FileSystem.Models.Enums;
using FileSystemAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using File = FileSystemAPI.Models.File;
using Directory = FileSystemAPI.Models.Directory;

namespace FileSystemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IUserSessionManager userSessionManager;
        private IUserManager userManager;
        private IFileManager fileManager;
        private IDirectoryManager directoryManager;

        public FileController(IUserSessionManager userSessionManager, IUserManager userManager, IFileManager fileManager, IDirectoryManager directoryManager)
        {
            this.userSessionManager = userSessionManager;
            this.userManager = userManager;
            this.fileManager = fileManager;
            this.directoryManager = directoryManager;
        }

        [HttpGet("{path}/content")]
        public ActionResult<string> ReadFile(string path)
        {
            var currentSession = userSessionManager.GetActiveSession();
            var permissions = this.userManager.ReadPermissionsForPath(path, currentSession.CurrentUser.Id);

            if (permissions.Contains(Permission.Read))
            {
                return this.Ok(fileManager.ReadFile(path));
            }
            else
            {
                return this.Unauthorized($"Current user does not have read permissions for {path}");
            }
        }

        [HttpGet("{path}")]
        public ActionResult<Models.Data.FileModel> GetFile(string path)
        {
            //var currentSession = userSessionManager.GetActiveSession();
            //var permissions = this.userManager.ReadPermissionsForPath(path, currentSession.CurrentUser.Id);

            //if (permissions.Contains(Permission.Read))
            //{
            return this.Ok(fileManager.GetFile(path));
            //}
            //else
            //{
            //    return this.Unauthorized($"Current user does not have read permissions for {path}");
            //}
        }

        [HttpPost()]
        public ActionResult<File> CreateFile(string name, string path, string parentPath, string extension)
        {
            //var currentSession = userSessionManager.GetActiveSession();
            //var userPermissions = this.userManager.ReadPermissionsForPath(parentPath, currentSession.CurrentUser.Id);

            //if (userPermissions.Contains(Permission.Create))
            //{
                //var parent = directoryManager.ReadDirectory(parentPath);
                //var parent = new Directory { };
                return this.Ok(fileManager.CreateFile(name, path, parentPath, extension));
            //}
            //else
            //{
            //    return this.Unauthorized($"Current user does not have create permissions for {parentPath}");
            //}

        }

        [HttpGet("Directory/{path}")]
        public ActionResult<List<File>> GetFilesInDirectory(string directoryPath)
        {
            var currentSession = userSessionManager.GetActiveSession();
            var userPermissions = this.userManager.ReadPermissionsForPath(directoryPath, currentSession.CurrentUser.Id);

            if (userPermissions.Contains(Permission.Read))
            {
                return this.Ok(fileManager.GetFilesForPath(directoryPath));
            }
            else
            {
                return this.Unauthorized($"Current user does not have create permissions for {directoryPath}");
            }
        }

        [HttpPut("{filePath}")]
        public ActionResult UpdateFile(string filePath, string name, string content, string extension)
        {
            fileManager.UpdateFile(filePath, name, content, extension);
            return this.NoContent();
        }

        [HttpDelete("{filePath}")]
        public ActionResult DeleteFile(string filePath)
        {
            fileManager.DeleteFile(filePath);
            return this.NoContent();
        }
    }
}
