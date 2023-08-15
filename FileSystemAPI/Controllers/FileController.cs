using FileSystem.Models.Enums;
using FileSystemAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using File = FileSystemAPI.Models.File;

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

        [HttpGet("{path}")]
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

        [HttpPost("{parentPath}")]
        public ActionResult<File> CreateFile(File file, string parentPath)
        {
            var currentSession = userSessionManager.GetActiveSession();
            var userPermissions = this.userManager.ReadPermissionsForPath(parentPath, currentSession.CurrentUser.Id);

            if (userPermissions.Contains(Permission.Create))
            {
                var parent = directoryManager.ReadDirectory(parentPath);
                return this.Ok(fileManager.CreateFile(file.Name, file.Id, currentSession.CurrentUser, parent, file.Permissions, file.Extension, file.Path));
            }
            else
            {
                return this.Unauthorized($"Current user does not have create permissions for {parentPath}");
            }

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
        public ActionResult UpdateFilePermissions(List<Permission> permissions, string filePath)
        {
            var currentSession = userSessionManager.GetActiveSession();
            var userPermissions = this.userManager.ReadPermissionsForPath(filePath, currentSession.CurrentUser.Id);

            if (userPermissions.Contains(Permission.Write))
            {
                fileManager.UpdateFilePermissions(permissions, filePath);
                return this.NoContent();
            }
            else
            {
                return this.Unauthorized($"Current user does not have write permissions for {filePath}");
            }
        }
    }
}
