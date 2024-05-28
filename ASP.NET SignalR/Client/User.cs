
namespace Client
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public User(string name, string pass)
        { 
            Name = name;
            Password = pass;
        }
    }
}