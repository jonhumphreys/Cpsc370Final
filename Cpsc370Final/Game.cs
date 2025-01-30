using System.Timers;
using Timer = System.Timers.Timer;

namespace Cpsc370Final;

public class Game
{
    // handles user input, passes off certain elements (and printing) to other classes, handles game logic
    private static Game? instance;
    private static ConsoleKeyboardInput consoleKeyboardInput;
    private DateTime startTime;
    // private static int millisecondsPerTick = 500;
    // private static Timer myTimer = new Timer(millisecondsPerTick);
    // private static int elapsedTicks = 0;
    // private static int maxTicks = 60;
    private TimeSpan playTime;
    private Score score;
    private Grid grid;
    public static Game GetInstance()
    {
        if (instance == null)
        {
            instance = new Game();
        }

        return instance;
    }

    Game()
    {
        playTime = TimeSpan.FromSeconds(60);
        consoleKeyboardInput = ConsoleKeyboardInput.getInstance();
        score = new Score();
        grid = new Grid();
        // Attach IncrementTick method
        // myTimer.Elapsed += Tick;
        // Enable the Timer
        // myTimer.Enabled = true;

        // Console.WriteLine("Press any key to stop the timer...");
        // Console.ReadLine();
    }

    // private static void Tick(Object source, ElapsedEventArgs e)
    // {
    //     elapsedTicks++;
    //     int TEMPORARY_POINTS_VALUE = 0; // replace when points system implemented
    //     int timeLeftInSeconds = (maxTicks - elapsedTicks) / (1000 / millisecondsPerTick);
    //     Console.Clear();
    //     GameStats.Print(timeLeftInSeconds, TEMPORARY_POINTS_VALUE); 
    // }
    
    
    
    public void Play()
    {
        Corgi corgi = new Corgi();
        DateTime startTime = DateTime.Now;
        int corgiLocation = Random.Shared.Next(1, 10);
        score.Reset();   
        Console.Clear();
        Console.WriteLine("Whack A Corgi (Corgi Edition)");
        Console.WriteLine("");
        Console.WriteLine(grid.DisplayGrid());
        Console.CursorVisible = false;
        while (DateTime.Now - startTime < playTime)
        {
            var (scoreLeft, scoreTop) = (0, 1);
            Console.SetCursorPosition(scoreLeft, scoreTop);
            Render(score.PrintScore());
            var (left, top) = Map(corgiLocation);
            Console.SetCursorPosition(left, top);
            Render(corgi.GetCorgiCharacters());
            int selection;
            GetInput:
            ConsoleKey userInput = ConsoleKey.None;
            userInput = consoleKeyboardInput.GetKeyboardInput().Key;
            switch (userInput)
            {
                case ConsoleKey.D1 or ConsoleKey.NumPad1: selection = 1; break;
                case ConsoleKey.D2 or ConsoleKey.NumPad2: selection = 2; break;
                case ConsoleKey.D3 or ConsoleKey.NumPad3: selection = 3; break;
                case ConsoleKey.D4 or ConsoleKey.NumPad4: selection = 4; break;
                case ConsoleKey.D5 or ConsoleKey.NumPad5: selection = 5; break;
                case ConsoleKey.D6 or ConsoleKey.NumPad6: selection = 6; break;
                case ConsoleKey.D7 or ConsoleKey.NumPad7: selection = 7; break;
                case ConsoleKey.D8 or ConsoleKey.NumPad8: selection = 8; break;
                case ConsoleKey.D9 or ConsoleKey.NumPad9: selection = 9; break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    Console.WriteLine("Whack A Corgi was closed...");
                    Environment.Exit(0);
                    return;
                default: goto GetInput;
            }
            if (corgiLocation == selection)
            {
                score.AddPoints(1);
                Console.SetCursorPosition(left, top);
                Render(corgi.GetEmpty());
                int newCorgiLocation = Random.Shared.Next(1, 9);
                corgiLocation = newCorgiLocation >= corgiLocation ? newCorgiLocation + 1 : newCorgiLocation;
            } else
            {
                break;
            }
        }
        EndGame();
    }

    private void EndGame()
    {
        Console.CursorVisible = true;
        Console.Clear();
        Console.WriteLine("Game Over. Score: " + score.GetScore());
        Console.WriteLine("Hopefully those Java noobs will learn their lesson and start using C#.");
        Console.WriteLine();
        Console.WriteLine("Press [Enter] To Continue...");
        Console.ReadLine();
    }

    private void Render(string @string)
    {
        int x = Console.CursorLeft;
        int y = Console.CursorTop;
        foreach (char c in @string)
        {
            if (c is '\n')
            {
                Console.SetCursorPosition(x, ++y);
            }
            else
            {
                Console.Write(c);
            }
        }
    }
    
    public (int Left, int Top) Map(int hole) =>
        hole switch
        {
            7 => (06, 15),
            8 => (20, 15),
            9 => (34, 15),
            4 => (06, 09),
            5 => (20, 09),
            6 => (34, 09),
            1 => (06, 03),
            2 => (20, 03),
            3 => (34, 03),
            _ => throw new NotImplementedException(),
        };

    public TimeSpan GetPlayTime()
    {
        return playTime;
    }
}