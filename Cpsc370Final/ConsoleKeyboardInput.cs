namespace Cpsc370Final;

public class ConsoleKeyboardInput : IKeyboardInput
{
    private static ConsoleKeyboardInput? instance;

    public static ConsoleKeyboardInput getInstance()
    {
        if (instance == null)
        {
            instance = new ConsoleKeyboardInput();
        }
        return instance;
    }

    private ConsoleKeyboardInput()
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
        return Console.ReadKey(true);
    }
    
}