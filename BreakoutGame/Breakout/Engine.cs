namespace Breakout
{
    using System;
    using System.Threading;
    using Contracts;
    using Enums;
    using Models;
    using Models.Patterns;

    public class Engine
    {
        private const int PlaygroundWidth = 85;
        private const int PlaygroundHeight = 35;
        private const int PaddleWidth = 7;
        private const char BallSymbol = '*';

        private static int paddlePositionX = 18; //Paddle x-coordinate starting position; y-coordinate is always PlaygroundHeight - 2
                                                 //(i.e. bottom of the screen).

        private static int ballPositionX = paddlePositionX + 3; //Ball x-coordinate starting position.
        private static int ballPositionY = PlaygroundHeight - 2; //Ball y-coordinate starting position.
        private static int previousBallPositionX = ballPositionX;
        private static int previousBallPositionY = ballPositionY;

        private static int gameSpeed = 100;

        private static Directions ballDirection = Directions.Up;

        private static IWall wallOfBricks;
        private static IFillingPattern fillingPattern;

        public Engine(Score score)
        {
            this.Score = score;
        }
        
        public Score Score { get; private set; }

        public void Run()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            Console.CursorVisible = false;
            
            Console.WindowWidth = PlaygroundWidth;
            Console.WindowHeight = PlaygroundHeight;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            while (true)
            {
                this.MainMenu();
            }
        } 

        private void GameStart()
        {
            // fillingPattern = new BasicPattern();
            fillingPattern = new ZigZagPattern();
            wallOfBricks = new Wall(4, PlaygroundWidth, fillingPattern);

            DrawPaddle();
            wallOfBricks.DrawWall();
            DrawBall();
            Console.Write("\b \b");

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    ChangePaddlePosition(pressedKey);
                }

                DrawPaddle();
                this.ChangeBallPosition();
                DrawBall();
                wallOfBricks.UpdateWall(previousBallPositionX, previousBallPositionY);
                Thread.Sleep(gameSpeed);
            }
        }

        private void MainMenu()
        {
            int curChoiceOption = 1;
            
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.SetCursorPosition(22, 5);
                Console.WriteLine("______                _               _   ");
                Console.SetCursorPosition(22, 6);
                Console.WriteLine("| ___ \\              | |             | |  ");
                Console.SetCursorPosition(22, 7);
                Console.WriteLine("| |_/ /_ __ ___  __ _| | _____  _   _| |_ ");
                Console.SetCursorPosition(22, 8);
                Console.WriteLine("| ___ \\ '__/ _ \\/ _` | |/ / _ \\| | | | __|");
                Console.SetCursorPosition(22, 9);
                Console.WriteLine("| |_/ / | |  __/ (_| |   < (_) | |_| | |_ ");
                Console.SetCursorPosition(22, 10);
                Console.WriteLine("\\____/|_|  \\___|\\__,_|_|\\_\\___/ \\__,_|\\__|");
                Console.SetCursorPosition(22, 11);

                // all it does is coloring the current highlighted answer and printing the answers
                if (curChoiceOption == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    new Thread(() => Console.Beep(150, 22)).Start();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.SetCursorPosition(35, 14);
                Console.WriteLine("Start new game ");

                if (curChoiceOption == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    new Thread(() => Console.Beep(150, 22)).Start();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.SetCursorPosition(35, 15);
                Console.WriteLine("Options ");

                if (curChoiceOption == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    new Thread(() => Console.Beep(150, 22)).Start();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.SetCursorPosition(35, 16);
                Console.WriteLine("Highscores ");

                if (curChoiceOption == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    new Thread(() => Console.Beep(150, 22)).Start();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.SetCursorPosition(35, 17);
                Console.WriteLine("Exit");

                // end of the long coloring
                var cki = Console.ReadKey(); // getting a button press
                // highlighting another desired option if an arrow is pressed
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    if (curChoiceOption + 1 <= 4)
                    {
                        curChoiceOption += 1;
                    }
                    else
                    {
                        curChoiceOption = 1;
                    }
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    if (curChoiceOption - 1 >= 1)
                    {
                        curChoiceOption -= 1;
                    }
                    else
                    {
                        curChoiceOption = 4;
                    }
                }
                else if (cki.Key == ConsoleKey.Enter) // breaking and leaving option validation in the outer loop
                {
                    break;
                }

                // clearing screen
                Console.Clear();
            }

            Console.Clear();

            if (curChoiceOption == 1)
            {
                //Fixed out of range exeption when choose to continue to play (not to exit from the game)
                paddlePositionX = 18;
                ballPositionY = PlaygroundHeight - 2;
                ballPositionX = paddlePositionX + 3;
                ballDirection = Directions.Up;
                Console.ForegroundColor = ConsoleColor.Cyan;
                this.GameStart();
            }
            else if (curChoiceOption == 2)
            {
                this.Options();
            }
            else if (curChoiceOption == 3)
            {
                this.HighScoresMenue();
            }
            else if (curChoiceOption == 4)
            {
                Environment.Exit(0);
            }
        }

        private void Options()
        {
            int curChoiceOption = 1;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.SetCursorPosition(22, 5);
                Console.WriteLine(" _____       _   _                 ");
                Console.SetCursorPosition(22, 6);
                Console.WriteLine("|  _  |     | | (_)                ");
                Console.SetCursorPosition(22, 7);
                Console.WriteLine("| | | |_ __ | |_ _  ___  _ __  ___ ");
                Console.SetCursorPosition(22, 8);
                Console.WriteLine("| | | | '_ \\| __| |/ _ \\| '_ \\/ __|");
                Console.SetCursorPosition(22, 9);
                Console.WriteLine("\\ \\_/ / |_) | |_| | (_) | | | \\__ \\");
                Console.SetCursorPosition(22, 10);
                Console.WriteLine(" \\___/| .__/ \\__|_|\\___/|_| |_|___/");
                Console.SetCursorPosition(22, 11);
                Console.WriteLine("      | |                          ");
                Console.SetCursorPosition(22, 12);
                Console.WriteLine("      |_|                          ");
                Console.SetCursorPosition(22, 13);

                // all it does is coloring the current highlighted answer and printing the answers
                Console.SetCursorPosition(35, 13);
                Console.WriteLine("Game speed: ");
                if (curChoiceOption == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Beep(150, 22);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.SetCursorPosition(35, 14);
                Console.WriteLine("x0.5");

                if (curChoiceOption == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Beep(150, 22);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.SetCursorPosition(35, 15);
                Console.WriteLine("x1");

                if (curChoiceOption == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Beep(150, 22);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.SetCursorPosition(35, 16);
                Console.WriteLine("x2");

                if (curChoiceOption == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Beep(150, 22);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.SetCursorPosition(35, 17);
                Console.WriteLine("Back");

                // end of the long coloring
                var cki = Console.ReadKey(); // getting a button press
                // highlighting another desired option if an arrow is pressed
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    if (curChoiceOption + 1 <= 4)
                    {
                        curChoiceOption += 1;
                    }
                    else
                    {
                        curChoiceOption = 1;
                    }
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    if (curChoiceOption - 1 >= 1)
                    {
                        curChoiceOption -= 1;
                    }
                    else
                    {
                        curChoiceOption = 4;
                    }
                }
                else if (cki.Key == ConsoleKey.Enter) // breaking and leaving option validation in the outer loop
                {
                    break;
                }

                // clearing screen
                Console.Clear();
            }

            Console.Clear();

            if (curChoiceOption == 1)
            {
                gameSpeed = 200;
            }
            else if (curChoiceOption == 2)
            {
                gameSpeed = 100;
            }
            else if (curChoiceOption == 3)
            {
                gameSpeed = 50;
            }

            Console.Clear();
            this.MainMenu();
        }

        private void HighScoresMenue()
        { 
            int curChoiceOption = 1;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.SetCursorPosition(13, 5);
                Console.WriteLine(" _    _ _       _");
                Console.SetCursorPosition(13, 6);
                Console.WriteLine("| |  | (_)     | |                           _");
                Console.SetCursorPosition(13, 7);
                Console.WriteLine("| |__| |_  ___ | | __        ___   ___  ___ | | __ ___   ___");
                Console.SetCursorPosition(13, 8);
                Console.WriteLine("|  __  | |/ _ \\| |/_ \\      / __| / _| / _ \\| |/__/ _ \\ / __|");
                Console.SetCursorPosition(13, 9);
                Console.WriteLine("| |  | | | (_| | |  | |     \\__ \\| (_ | (_) | |  |  __ /\\__ \\");
                Console.SetCursorPosition(13, 10);
                Console.WriteLine("|_|  |_|_|\\__  |_|  |_|     |___/ \\__| \\___/|_|   \\___| |___/");
                Console.SetCursorPosition(13, 11);
                Console.WriteLine("             | |");
                Console.SetCursorPosition(13, 12);
                Console.WriteLine("            _| |");
                Console.SetCursorPosition(13, 13);
                Console.WriteLine("           \\___/");

                this.Score.PrintBestScores();

                if (curChoiceOption == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Beep(150, 22);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.SetCursorPosition(40, 23);
                Console.WriteLine("Back");

                if (curChoiceOption == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Beep(150, 22);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.SetCursorPosition(40, 24);
                Console.WriteLine("Exit");

                var cki = Console.ReadKey();

                if (cki.Key == ConsoleKey.DownArrow)
                {
                    if (curChoiceOption + 1 <= 2)
                    {
                        curChoiceOption += 1;
                    }
                    else
                    {
                        curChoiceOption = 1;
                    }
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    if (curChoiceOption - 1 >= 1)
                    {
                        curChoiceOption -= 1;
                    }
                    else
                    {
                        curChoiceOption = 2;
                    }
                }
                else if (cki.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }

            Console.Clear();

            if (curChoiceOption == 1)
            {
                Console.Clear();
                this.MainMenu();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void ChangeBallPosition()
        {
            switch (ballDirection)
            {
                case Directions.Up: // Up
                    previousBallPositionX = ballPositionX;
                    previousBallPositionY = ballPositionY;
                    ballPositionY--;
                    break;
                case Directions.UpAndLeft: // Up left
                    previousBallPositionX = ballPositionX;
                    previousBallPositionY = ballPositionY;
                    ballPositionX--;
                    ballPositionY--;
                    break;
                case Directions.UpAndRight: // Up right
                    previousBallPositionX = ballPositionX;
                    previousBallPositionY = ballPositionY;
                    ballPositionX++;
                    ballPositionY--;
                    break;
                case Directions.Down: // Down
                    previousBallPositionX = ballPositionX;
                    previousBallPositionY = ballPositionY;
                    ballPositionY++;
                    break;
                case Directions.DownAndRight: // Down right
                    previousBallPositionX = ballPositionX;
                    previousBallPositionY = ballPositionY;
                    ballPositionX++;
                    ballPositionY++;
                    break;
                case Directions.DownAndLeft: // Down left
                    previousBallPositionX = ballPositionX;
                    previousBallPositionY = ballPositionY;
                    ballPositionX--;
                    ballPositionY++;
                    break;
            }

            if (ballPositionY == PlaygroundHeight - 2) // When the ball hits the floor or the paddle.
            {
                if ((ballPositionX >= paddlePositionX + 2) &&
                    (ballPositionX <= paddlePositionX + 4)) // The middle 3 "_" symbols.
                {
                    new Thread(() => Console.Beep(180, 50)).Start();

                    ballDirection = Directions.Up; // Bouncing up.
                }
                else if ((ballPositionX >= paddlePositionX) &&
                    (ballPositionX <= paddlePositionX + 1)) // The left 2 "_" symbols.
                {
                    new Thread(() => Console.Beep(180, 50)).Start();

                    ballDirection = Directions.UpAndLeft; // Bouncing up and to the left.
                }
                else if ((ballPositionX >= paddlePositionX + 5) &&
                    (ballPositionX <= paddlePositionX + 6)) // The right 2 "_" symbols.
                {
                    new Thread(() => Console.Beep(180, 50)).Start();

                    ballDirection = Directions.UpAndRight; // Bouncing up and to the right.
                }
                else
                {
                    this.Score.SaveScore();
                    this.MainMenu();
                    //Environment.Exit(0); // Terminates the main thread, without any exception thrown, i.e. exits the program.
                }
            }

            if (ballPositionY == 0) // When the ball hits the ceiling.
            {
                if (ballDirection == Directions.Up)
                {
                    new Thread(() => Console.Beep(200, 250)).Start();

                    ballDirection = Directions.Down; // From upward direction the ball bounces off downward.
                }
                else if (ballDirection == Directions.UpAndRight)
                {
                    new Thread(() => Console.Beep(200, 250)).Start();

                    ballDirection = Directions.DownAndRight; // From upward right direction the ball bounces off downward right.
                }
                else if (ballDirection == Directions.UpAndLeft)
                {
                    new Thread(() => Console.Beep(200, 250)).Start();

                    ballDirection = Directions.DownAndLeft; // From upward left direction the ball bounces off downward left.
                }
            }

            if (ballPositionX == 0) // When the ball hits the left wall.
            {
                if (ballDirection == Directions.UpAndLeft)
                {
                    new Thread(() => Console.Beep(200, 50)).Start();

                    ballDirection = Directions.UpAndRight; // From upward left direction the ball bounces off upward right.
                }
                else if (ballDirection == Directions.DownAndLeft)
                {
                    new Thread(() => Console.Beep(200, 250)).Start();

                    ballDirection = Directions.DownAndRight; // From downward left direction the ball bounces off downward right.
                }
            }

            if (ballPositionX == PlaygroundWidth - 1) // When the ball hits the right wall.
            {
                if (ballDirection == Directions.UpAndRight)
                {
                    new Thread(() => Console.Beep(200, 250)).Start();

                    ballDirection = Directions.UpAndLeft; // From upward right direction the ball bounces off upward left.
                }
                else if (ballDirection == Directions.DownAndRight)
                {
                    new Thread(() => Console.Beep(200, 250)).Start();

                    ballDirection = Directions.DownAndLeft; // From downward right direction the ball bounces off downward left.
                }
            }

            // Detect collisions with the wall
            if (ballPositionY <= wallOfBricks.Height)
            {
                for (int i = 0; i < wallOfBricks.Height; i++)
                {
                    for (int j = 0; j < wallOfBricks.Width; j++)
                    {
                        if (ballPositionX == wallOfBricks.FilledWall[i, j].PositionX &&
                            ballPositionY - 1 == wallOfBricks.FilledWall[i, j].PositionY &&
                            wallOfBricks.FilledWall[i, j].getVisibility())
                        /* It has to be ballPositionY - 1 because j starts from 0,
                        but the top wall row starts from console row 1.
                        That's what's causing the collision problem*/
                        {
                            wallOfBricks.FilledWall[i, j].setInvisible();

                            new Thread(() => Console.Beep(450, 100)).Start();

                            BallDirectionAfterWallCollision();

                            this.Score.UpdateCurrentScore();
                        }
                    }
                }
            }
        }

        private static void BallDirectionAfterWallCollision()
        {
            if (ballDirection == Directions.Up)
            {
                // From upward direction the ball bounces off downward.
                ballDirection = Directions.Down;
            }
            else if (ballDirection == Directions.Down)
            {
                // From downward direction the ball bounces off upwards.
                ballDirection = Directions.Up;
            }
            else if (ballDirection == Directions.UpAndRight)
            {
                // From upward right direction the ball bounces off downward right.
                ballDirection = Directions.DownAndRight;
            }
            else if (ballDirection == Directions.UpAndLeft)
            {
                // From upward left direction the ball bounces off downward left.
                ballDirection = Directions.DownAndLeft;
            }
            else if (ballDirection == Directions.DownAndLeft)
            {
                // From downward left direction the ball bounces off upward left.
                ballDirection = Directions.UpAndLeft;
            }
            else if (ballDirection == Directions.DownAndRight)
            {
                // From downward right direction the ball bounces off upward right.
                ballDirection = Directions.UpAndRight;
            }
        }

        private static void ChangePaddlePosition(ConsoleKeyInfo pressedKey)
        {
            if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                paddlePositionX = paddlePositionX - 2;
                if (paddlePositionX < 0)
                {
                    paddlePositionX = 0;
                }
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                paddlePositionX = paddlePositionX + 2;
                if (paddlePositionX > PlaygroundWidth - PaddleWidth)
                {
                    paddlePositionX = PlaygroundWidth - PaddleWidth;
                }
            }
        }

        private static void DrawPaddle()
        {
            Console.SetCursorPosition(0, PlaygroundHeight - 2);
            Console.Write(new string(' ', PlaygroundWidth));
            
            for (int i = 0; i < PaddleWidth; i++)
            {
                Console.SetCursorPosition(paddlePositionX + i, PlaygroundHeight - 2);
                Console.Write('_');
            }
        }

        private static void DrawBall()
        {
            Console.SetCursorPosition(previousBallPositionX, previousBallPositionY);
            Console.Write(' ');
            Console.SetCursorPosition(ballPositionX, ballPositionY);
            Console.Write(BallSymbol);
        }
    }
}
