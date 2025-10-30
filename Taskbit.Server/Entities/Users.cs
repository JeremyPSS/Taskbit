namespace Taskbit.Server.Entities
{
    public class Users
    {
        private int id_users;
        private string username;
        private string passwordHash;

        public Users() { }

        public Users(int id_users_, string username_, string passwordHash_)
        {
            id_users = id_users_;
            username = username_;
            passwordHash = passwordHash_;
        }

        public int Id_users { get => id_users; set => id_users = value; }
        public string Username { get => username; set => username = value; }
        public string PasswordHash { get => passwordHash; set => passwordHash = value; }

    }
}
