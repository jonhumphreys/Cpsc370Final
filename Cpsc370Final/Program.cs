namespace Cpsc370Final;

class Program
{
    static void Main(string[] args)
    {
        ConsoleKeyboardInput consoleKeyboardInput = ConsoleKeyboardInput.getInstance();
        if (OperatingSystem.IsWindows())
        {
            Console.WindowWidth = Math.Max(Console.WindowWidth, 50);
            Console.WindowHeight = Math.Max(Console.WindowHeight, 22);
        }


        while (true)
        {
            Console.Clear();
            Console.WriteLine("Whack A Corgi (Corgi Edition)");
            Console.WriteLine();
            Console.WriteLine(
                $"You have 60 seconds to whack as many Corgis as you " +
                "can before the timer runs out. Use the number keys 1-9 to whack. Are you ready? ");
            Console.WriteLine();
            Console.WriteLine("Play [enter], or quit [escape]?");
            GetInput:
            switch (consoleKeyboardInput.GetKeyboardInput().Key)
            {
                case ConsoleKey.Enter:
                    Game game = Game.GetInstance();
                    game.Play();
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    Console.WriteLine("Whack A Corgi was closed...");
                    Environment.Exit(0);
                    break;
                default:
                    goto GetInput;
            }
        } 
    }

    // this is just an example of how to get the command
    // line arguments so you can use them
    private static void ShowArguments(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine("  Argument " + i +": " + args[i]);
        }
    }
    
}