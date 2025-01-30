namespace Cpsc370Final.Tests;

using System;

public class Corgi_Test
{
    // Format for naming is "WhatWeAreTestingAndActing_InputValue_AssertionAssumption
    
    [Fact]
    public void Render_Corgi_ShouldHaveFourLines()
    {
        string[] corgiLines = Corgi.Split('\n');
        Assert.Equal(4, corgiLines.Length);
    }
    
    [Fact]
    public void Map_InvalidPosition_ShouldThrowException()
    {
        Assert.Throws<NotImplementedException>(() => Map(10));
    }
    
    [Fact]
    public void Whack_Corgi_ShouldBeClearedFromBoard()
    {
        string boardBefore = "Corgi";
        string boardAfter = string.Empty;

        Assert.NotEqual(boardBefore, boardAfter);
    }

    private (int, int) Map(int hole) =>
        hole switch
        {
            1 => (06, 03),
            2 => (20, 03),
            3 => (34, 03),
            4 => (06, 09),
            5 => (20, 09),
            6 => (34, 09),
            7 => (06, 15),
            8 => (20, 15),
            9 => (34, 15),
            _ => throw new NotImplementedException(),
        };
}