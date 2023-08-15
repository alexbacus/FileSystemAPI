namespace FileSystemAPI.Models
{
    public class UserSession
    {
        public User CurrentUser { get; private set; }

        public void Login(User user)
        {
            CurrentUser = user;
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
