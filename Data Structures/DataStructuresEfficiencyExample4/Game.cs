
public class Game
{
    public Game(string gameName, string password)
    {
        this.GameName = gameName;
        this.Password = password;
    }

    public string GameName { get; private set; }

    public string Password { get; private set; }

    public override string ToString()
    {
        return this.GameName;
    }
}
