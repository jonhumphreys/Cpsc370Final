namespace Cpsc370Final;

public class KeyboardInput
{
    private static KeyboardInput? instance;

    public static KeyboardInput getInstance()
    {
        if (instance == null)
        {
            instance = new KeyboardInput();
        }
        return instance;
    }

    private KeyboardInput()
    {
    }

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
        // Read the next key as a character
        char inputChar = (char)Console.Read();

        // Map the input char to ConsoleKey
        ConsoleKey key = ConsoleKey.NoName; // Default key

        // Handle numeric keys (D1-D9)
        if (inputChar >= '1' && inputChar <= '9')
        {
            key = (ConsoleKey)Enum.Parse(typeof(ConsoleKey), "D" + inputChar);
        }
        // Handle the Enter key
        else if (inputChar == '\r') // Enter key is represented as \r (carriage return) in Console.Read()
        {
            key = ConsoleKey.Enter;
        }

        return new ConsoleKeyInfo(inputChar, key, false, false, false);
    }
    
}