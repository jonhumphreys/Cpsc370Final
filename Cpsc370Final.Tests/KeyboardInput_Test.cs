namespace Cpsc370Final.Tests;

public class KeyboardInput_Test
{
    // Format for naming is "WhatWeAreTestingAndActing_InputValue_AssertionAssumption
    [Theory]
    [InlineData(ConsoleKey.D1, "D1 has been pressed")]
    [InlineData(ConsoleKey.D2, "D2 has been pressed")]
    [InlineData(ConsoleKey.D3, "D3 has been pressed")]
    [InlineData(ConsoleKey.D4, "D4 has been pressed")]
    [InlineData(ConsoleKey.D5, "D5 has been pressed")]
    [InlineData(ConsoleKey.D6, "D6 has been pressed")]
    [InlineData(ConsoleKey.D7, "D7 has been pressed")]
    [InlineData(ConsoleKey.D8, "D8 has been pressed")]
    [InlineData(ConsoleKey.D9, "D9 has been pressed")]
    [InlineData(ConsoleKey.Enter, "Enter has been pressed")]
    public void KeyboardInput_AllKeysUsedInGame_TriggersEachEvent(ConsoleKey userKeyInput, string expectedOutput)
    {
        Assert.Equal(KeyboardInput.getInstance().PrintKeyboardInput(userKeyInput), expectedOutput);
    }

    [Theory]
    [InlineData( "1", "D1 has been pressed")]
    [InlineData( "2", "D2 has been pressed")]
    [InlineData( "3", "D3 has been pressed")]
    [InlineData( "4", "D4 has been pressed")]
    [InlineData( "5", "D5 has been pressed")]
    [InlineData( "6", "D6 has been pressed")]
    [InlineData( "7", "D7 has been pressed")]
    [InlineData( "8", "D8 has been pressed")]
    [InlineData( "9", "D9 has been pressed")]
    [InlineData( "\r", "Enter has been pressed")]
    public void KeyboardInputFromUser_AllKeysUsedInGame_TriggersEachEvent(string userConsoleInput, string expectedOutput)
    {
        // Simulate pressing "Enter" by providing input through StringReader
        var input = new StringReader(userConsoleInput);  // Simulate the "Enter" key press
        Console.SetIn(input);  // Redirect Console input

        var keyboardInput = KeyboardInput.getInstance();
        ConsoleKeyInfo userInput = keyboardInput.GetKeyboardInput(); // This will read the redirected input

        Assert.Equal(expectedOutput, keyboardInput.PrintKeyboardInput(userInput.Key));
        
    }
}   