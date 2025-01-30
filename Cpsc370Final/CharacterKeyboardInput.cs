namespace Cpsc370Final;

public class CharacterKeyboardInput : IKeyboardInput
{
    public string PrintKeyboardInput(ConsoleKey userKeyInput)
    {
        if (userKeyInput == ConsoleKey.Enter)
        {
            return "Enter has been pressed";
        }
        else
        {
            return userKeyInput.ToString() + " has been pressed";
        }
    }
    
    public ConsoleKeyInfo GetKeyboardInput()
    {
        char inputChar = (char)Console.Read();
        ConsoleKey key = ConsoleKey.NoName; 
        if (inputChar >= '1' && inputChar <= '9')
        {
            key = (ConsoleKey)Enum.Parse(typeof(ConsoleKey), "D" + inputChar);
        }
        else if (inputChar == '\r')
        {
            key = ConsoleKey.Enter;
        }

        return new ConsoleKeyInfo(inputChar, key, false, false, false);
    }
}