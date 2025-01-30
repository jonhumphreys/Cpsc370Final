namespace Cpsc370Final;

public class Corgi
{
    // define corgi characters (using 2d array)
  
    private static string CorgiCharacters { get; } =
        @" /__/" + '\n' +
        @"(o . o)" + '\n' +
        @"  woof " + '\n' +
        @"( U U )";

    private static string Empty { get; } =
        @"       " + '\n' +
        @"       " + '\n' +
        @"       " + '\n' +
        @"       ";
    
    public string GetCorgiCharacters() => CorgiCharacters;
    public string GetEmpty() => Empty;
    // handle corgi print

    public static string[] Split(char c)
    {
        return CorgiCharacters.Split(c);
        
    }
}