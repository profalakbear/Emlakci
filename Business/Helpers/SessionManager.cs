namespace Business.Helpers
{
    public static class SessionManager
    {
        public static string Email { get; private set; }
        public static int UserId { get; private set; }

        public static bool IsLoggedIn => !string.IsNullOrEmpty(Email);

        public static void Login(string email, int userId)
        {
            Email = email;
            UserId = userId;
        }

        public static void Logout()
        {
            Email = null;
            UserId = 0;
        }
    }
}
