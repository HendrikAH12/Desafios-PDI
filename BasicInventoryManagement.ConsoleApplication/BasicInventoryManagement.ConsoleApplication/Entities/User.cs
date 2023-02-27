namespace BasicInventoryManagement.ConsoleApplication.Entities
{
    public class User
    {
        public string Email { get; }
        public string Password { get; set; }
        public bool IsAdmin { get; }

        public User(string email, string password, bool isAdmin)
        {
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }

        public User(string email, string password) 
        {
            Email = email;
            Password = password;
            IsAdmin = false;
        }
    }
}
