namespace Cpsc370Final;

public interface IKeyboardInput
{
    string PrintKeyboardInput(ConsoleKey userKeyInput);
    ConsoleKeyInfo GetKeyboardInput();
}