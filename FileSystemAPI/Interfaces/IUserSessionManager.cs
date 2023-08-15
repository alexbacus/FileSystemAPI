using FileSystemAPI.Models;

namespace FileSystemAPI.Interfaces
{
    public interface IUserSessionManager
    {
        public UserSession GetActiveSession();
    }
}
