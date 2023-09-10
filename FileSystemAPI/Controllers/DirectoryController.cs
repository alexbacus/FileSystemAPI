using FileSystem.Models.Enums;
using FileSystemAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Directory = FileSystemAPI.Models.Directory;

namespace FileSystemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        private IUserSessionManager userSessionManager;
        private IUserManager userManager;
        private IDirectoryManager directoryManager;

        public DirectoryController(IUserSessionManager userSessionManager, IUserManager userManager, IDirectoryManager directoryManager)
        {
            this.userSessionManager = userSessionManager;
            this.userManager = userManager;
            this.directoryManager = directoryManager;
        }

        [HttpGet("{path}")]
        public ActionResult<Models.Data.DirectoryModel> ReadDirectory(string path, int userId)
        {
            //var currentSession = userSessionManager.GetActiveSession();
            //var permissions = this.userManager.ReadPermissionsForPath(path, currentSession.CurrentUser.Id);

            //if (permissions.Contains(Permission.Read))
            //{
            if (userId == 0 || userId == null)
            {
                return this.Unauthorized($"Must be logged in to perform operation.");
            }
            return this.Ok(directoryManager.ReadDirectory(path));
            //}
            //else
            //{
            //    return this.Unauthorized($"Current user does not have read permissions for {path}");
            //}
        }

        [HttpPost("{parentPath}")]
        public ActionResult<Directory> CreateDirectory(string path, string name, string parentPath, int userId)
        {
            //var currentSession = userSessionManager.GetActiveSession();
            //var userPermissions = this.userManager.ReadPermissionsForPath(parentPath, currentSession.CurrentUser.Id);

            //if (userPermissions.Contains(Permission.Create))
            //{
            //var parent = directoryManager.ReadDirectory(parentPath);
            if (userId == 0 || userId == null)
            {
                return this.Unauthorized($"Must be logged in to perform operation.");
            }
            return this.Ok(directoryManager.CreateDirectory(name, path, parentPath, userId));
            //}
            //else
            //{
            //    return this.Unauthorized($"Current user does not have create permissions for {parentPath}");
            //}
        }

        [HttpPut("{directoryPath}")]
        public ActionResult UpdateDirectory(string directoryPath, string name, int userId)
        {
            //var currentSession = userSessionManager.GetActiveSession();
            //var userPermissions = this.userManager.ReadPermissionsForPath(directoryPath, currentSession.CurrentUser.Id);

            //if (userPermissions.Contains(Permission.Write))
            //{
            //    directoryManager.UpdateDirectoryPermissions(permissions, directoryPath);
            if (userId == 0 || userId == null)
            {
                return this.Unauthorized($"Must be logged in to perform operation.");
            }
            directoryManager.UpdateDirectory(directoryPath, name);
            return this.NoContent();
            //}
            //else
            //{
            //    return this.Unauthorized($"Current user does not have write permissions for {directoryPath}");
            //}
        }

        [HttpDelete("{directoryPath}")]
        public ActionResult DeleteDirectory(string directoryPath, int userId)
        {
            if (userId == 0 || userId == null)
            {
                return this.Unauthorized($"Must be logged in to perform operation.");
            }
            directoryManager.DeleteDirectory(directoryPath);
            return this.NoContent();
        }
    }
}
