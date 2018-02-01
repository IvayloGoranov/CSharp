
public class User
{
    public User(string username, string password)
    {
        this.UserName = username;
        this.Password = password;
    }
    
    public string UserName { get; private set; }

    public string Password { get; private set; }

    public override string ToString()
    {
        return this.UserName.ToString();
    }
}
