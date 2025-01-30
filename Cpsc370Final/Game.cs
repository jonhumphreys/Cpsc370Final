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
}