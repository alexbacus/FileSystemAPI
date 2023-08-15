using FileSystemAPI.Interfaces;
using FileSystemAPI.Models;

namespace FileSystemAPI.Managers
{
    public class UserSessionManager : IUserSessionManager
    {
        private UserSession activeSession;

        public UserSession GetActiveSession()
        {
            if (activeSession == null)
            {
                activeSession = new UserSession();
            }
            return activeSession;
        }
    }
}
