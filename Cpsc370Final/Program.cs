namespace Cpsc370Final;
class Program
{
    private static string StoryFileName = "DefaultStory.txt";
    private static string DictionaryFileName = "DefaultWords.json";
    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Using default story and dictionary.");
        }
        else if (args.Length == 1)
        {
            Console.WriteLine("Using default dictionary.");
            StoryFileName = args[0];
        }
        else if (args.Length == 2)
        {
            StoryFileName = args[0];
            DictionaryFileName = args[1];
        }
        else
        {
            Console.WriteLine("Too many arguments. Using default story and dictionary.");
        }

        StoryParser storyParser = new StoryParser(StoryFileName);
        storyParser.ParseStoryFile();
        WordParser wordParser = new WordParser(DictionaryFileName);
        WordDictionary wordDictionary = wordParser.GetWordDictionary();
        
        // you can delete this if/when you like
        //ShowArguments(args);
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