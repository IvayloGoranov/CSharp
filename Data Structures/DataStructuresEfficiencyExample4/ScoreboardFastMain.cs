using System;

public class ScoreboardFastMain
{
    public static void Main()
    {
        ScoreboardCommandExecutor commandExecutor = new ScoreboardCommandExecutor();
        
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }

            if (input != string.Empty)
            {
                string commandResult = commandExecutor.ProcessCommand(input);
                Console.WriteLine(commandResult);
            }
        }
    }
}
