using FileSystemAPI.Interfaces;
using FileSystemAPI.Models;

namespace FileSystemAPI.Managers
{
    public class UserSessionManager : IUserSessionManager
    {
        private UserSession activeSession;
        private readonly FileSystemContext context;

        public UserSessionManager(FileSystemContext context)
        {
            this.context = context;
        }

        public UserSession GetActiveSession()
        {
            if (activeSession == null)
            {
                activeSession = new UserSession();
            }
            return activeSession;
        }

        public int Login(string username, string password)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (user == null)
            {
                return 0;
            }
            return user.Id;
        }
    }
}
