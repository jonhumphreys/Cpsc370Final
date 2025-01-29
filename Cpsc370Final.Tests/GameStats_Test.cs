namespace Cpsc370Final.Tests;

public class GameStats_Test
{
    // Format for naming is "WhatWeAreTestingAndActing_InputValue_AssertionAssumption
    [Theory]
    [InlineData(0,0, "========== 00s ======= 000p ==========")]
    [InlineData(17,15, "========== 17s ======= 015p ==========")]
    [InlineData(23,107, "========== 23s ======= 107p ==========")]
    public void PrintingGameStats_TimeLeft_TotalPoints_CorrectPrint(int timeLeftInSeconds, int totalPoints, string expectedGameStats)
    {
        GameStats.Print(timeLeftInSeconds, totalPoints);
        String gameStats = GameStats.GetGameStatsString();
        
        Assert.Equal(expectedGameStats, gameStats);
    }
}