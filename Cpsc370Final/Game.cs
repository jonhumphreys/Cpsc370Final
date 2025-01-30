using System.Timers;
using Timer = System.Timers.Timer;

namespace Cpsc370Final;

public class Game
{
    // handles user input, passes off certain elements (and printing) to other classes, handles game logic
    private static Game? instance;

    private static int millisecondsPerTick = 500;
    private static Timer myTimer = new Timer(millisecondsPerTick);
    private static int elapsedTicks = 0;
    private static int maxTicks = 60;
    private int score;

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
        // Attach IncrementTick method
        myTimer.Elapsed += Tick;
        // Enable the Timer
        myTimer.Enabled = true;

        Console.WriteLine("Press any key to stop the timer...");
        Console.ReadLine();
    }

    private static void Tick(Object source, ElapsedEventArgs e)
    {
        elapsedTicks++;
        int TEMPORARY_POINTS_VALUE = 0; // replace when points system implemented
        int timeLeftInSeconds = (maxTicks - elapsedTicks) / (1000 / millisecondsPerTick);
        Console.Clear();
        GameStats.Print(timeLeftInSeconds, TEMPORARY_POINTS_VALUE); 
    }
    
    public void Play()
    {
        Console.Clear();
        Console.WriteLine("Whack A Corgi (Corgi Edition)");
        Console.WriteLine();
        Console.WriteLine(Board);
        DateTime start = DateTime.Now;
        int score = 0;
        int corgiLocation = Random.Shared.Next(1, 10);
        Console.CursorVisible = false;
        while (DateTime.Now - start < playTime)
        {
            var (left, top) = Map(corgiLocation);
            Console.SetCursorPosition(left, top);
            Render(CorgiCharacters);
            int selection;
            GetInput:
            switch (Console.ReadKey(true).Key)
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
                score++;
                Console.SetCursorPosition(left, top);
                Render(Empty);
                int newCorgiLocation = Random.Shared.Next(1, 9);
                corgiLocation = newCorgiLocation >= corgiLocation ? newCorgiLocation + 1 : newCorgiLocation;
            }
        }
        Console.CursorVisible = true;
        Console.Clear();
        Console.WriteLine("Whack A Corgi (Corgi Edition)");
        Console.WriteLine();
        Console.WriteLine(Board);
        Console.WriteLine();
        Console.WriteLine("Game Over. Score: " + score);
        Console.WriteLine("Hopefully those Java noobs will learn their lesson and start using C#.");
        Console.WriteLine();
        Console.WriteLine("Press [Enter] To Continue...");
        Console.ReadLine();
    }
}