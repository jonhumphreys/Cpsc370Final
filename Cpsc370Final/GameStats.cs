namespace Cpsc370Final;

public class GameStats
{
    // define UI elements such as timer and score
    private static int TimeLeftInSeconds = 0;
    private static int TotalPoints = 0;

    public static void Print(int timeLeftInSeconds, int totalPoints)
    {
        TimeLeftInSeconds = timeLeftInSeconds;
        TotalPoints = totalPoints;
        Console.WriteLine(GetGameStatsString());
    }

    public static String GetGameStatsString()
    {
        return "========== " + CreateTimeString() + "s ======= " + CreatePointsString() + "p ==========";
    }

    private static String CreateTimeString()
    {
        if (TimeLeftInSeconds < 10)
        {
            return "0" + TimeLeftInSeconds;
        }
        
        return "" + TimeLeftInSeconds;
    }

    private static String CreatePointsString()
    {
        if (TotalPoints < 10)
        {
            return "00" + TotalPoints;
        }
        if (TotalPoints < 100)
        {
            return "0" + TotalPoints;
        }
        return "" + TotalPoints;
    }
}