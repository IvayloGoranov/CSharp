using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;
using System.Linq;

public class Scoreboard
{
    private const int ScoresToViewCount = 10;
    
    private Dictionary<string, User> users = new Dictionary<string, User>();
    private Dictionary<string, Game> games = new Dictionary<string, Game>();
    private OrderedDictionary<string, OrderedBag<GameScore>> scoresByGame = 
        new OrderedDictionary<string, OrderedBag<GameScore>>(new PrefixComparer());

    public string RegisterUser(string username, string password)
    {
        if (this.users.ContainsKey(username))
        {
            return "Duplicated user";
        }
        
        User newUser = new User(username, password);
        this.users.Add(username, newUser);

        return "User registered";
    }

    public string RegisterGame(string gameName, string password)
    {
        if (this.games.ContainsKey(gameName))
        {
            return "Duplicated game";
        }

        Game newGame = new Game(gameName, password);
        this.games.Add(gameName, newGame);
        
        this.scoresByGame.Add(gameName, new OrderedBag<GameScore>());

        return "Game registered";
    }

    public string AddScore(string username, string userPassword, string gameName, string gamePassword, int score)
    {
        if (!this.users.ContainsKey(username))
        {
            return "Cannot add score";
        }
        
        if (this.users[username].Password != userPassword)
        {
            return "Cannot add score";
        }

        if (!this.games.ContainsKey(gameName))
        {
            return "Cannot add score";
        }

        if (this.games[gameName].Password != gamePassword)
        {
            return "Cannot add score";
        }

        var user = this.users[username];
        GameScore newGameScore = new GameScore(user, score);
        this.scoresByGame[gameName].Add(newGameScore);

        return "Score added";
    }

    public string ShowScoreBoard(string gameName)
    {
        if (!this.games.ContainsKey(gameName))
        {
            return "Game not found";
        }

        var scores = this.scoresByGame[gameName];
        if (scores.Count == 0)
        {
            return "No score";
        }

        StringBuilder outputScore = new StringBuilder();
        int index = 1;
        foreach (var score in scores)
        {
            if (index > ScoresToViewCount)
            {
                break;
            }

            outputScore.AppendFormat("#{0} {1} {2}{3}",
                index, score.User.UserName, score.Score, Environment.NewLine);
            index++;
        }

        outputScore.Length -= Environment.NewLine.Length;
        //outputScore.Remove(outputScore.Length - 1, 1); //Remove the last newline.

        return outputScore.ToString();
    }

    public string DeleteGame(string gameName, string password)
    {
        if (!this.games.ContainsKey(gameName))
        {
            return "Cannot delete game";
        }

        if (this.games[gameName].Password != password)
        {
            return "Cannot delete game";
        }

        this.games.Remove(gameName);

        this.scoresByGame.Remove(gameName);

        return "Game deleted";
    }

    public string ListGamesByPrefix(string gameNamePrefix)
    {
        string upperBound = gameNamePrefix + char.MaxValue;
        var results = this.scoresByGame.Range(gameNamePrefix, true, upperBound, false).
            Take(10).Select(keyValuePair => keyValuePair.Key);

        if (!results.Any())
        {
            return "No matches";
        }

        StringBuilder output = new StringBuilder();
        foreach (var game in results)
        {
            output.AppendFormat("{0}, ", game);
        }

        output.Length -= 2;//Remove the last empty space and comma.

        return output.ToString();
    }
}
