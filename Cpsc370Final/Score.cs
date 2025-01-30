namespace Cpsc370Final;

public class Score
{
    private int _score;

    public Score()
    {
        _score = 0;
    }

    public void AddPoints(int points)
    {
        _score += points;
    }

    public void Reset()
    {
        _score = 0;
    }

    public int GetScore()
    {
        return _score;
    }

    public string PrintScore()
    {
        return "Score: " + _score;
    }
}

public class UserInterface
{
    private Score _score;

    public UserInterface(Score score)
    {
        _score = score;
    }

    public void ShowScore()
    {
        Console.SetCursorPosition(0, 0); // Keeps the score fixed at the top
        Console.WriteLine($"Score: {_score.GetScore()}");
    }
}