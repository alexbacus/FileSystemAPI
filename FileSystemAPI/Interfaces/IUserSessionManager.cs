using FileSystemAPI.Models;

namespace FileSystemAPI.Interfaces
{
    public interface IUserSessionManager
    {
        public UserSession GetActiveSession();
        public int Login(string username, string password);
    }
}
