
public class ScoreboardCommandExecutor
{
    private Scoreboard scoreboard = new Scoreboard();
    
    public string ProcessCommand(string command)
    {
        string[] commandArgs = command.Split(' ');
        string commandType = commandArgs[0];

        switch (commandType)
        {
            case "RegisterUser":
                string username = commandArgs[1];
                string password = commandArgs[2];
                
                return this.scoreboard.RegisterUser(username, password);
            case "RegisterGame":
                string gameName = commandArgs[1];
                password = commandArgs[2];
                
                return this.scoreboard.RegisterGame(gameName, password);
            case "AddScore":
                username = commandArgs[1];
                string userPassword = commandArgs[2];
                gameName = commandArgs[3];
                string gamePassword = commandArgs[4];
                int score = int.Parse(commandArgs[5]);
                
                return this.scoreboard.AddScore(username, userPassword, gameName, gamePassword, score);
            case "ShowScoreboard":
                gameName = commandArgs[1];
                
                return this.scoreboard.ShowScoreBoard(gameName);
            case "DeleteGame":
                gameName = commandArgs[1];
                password = commandArgs[2];

                return this.scoreboard.DeleteGame(gameName, password);
            case "ListGamesByPrefix":
                string gameNamePrefix = commandArgs[1];

                return this.scoreboard.ListGamesByPrefix(gameNamePrefix);
            default:
                return "Incorrect command";
        }
    }
}
