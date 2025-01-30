using System.Text.RegularExpressions;

namespace Cpsc370Final;

public class StoryParser
{
    private string _fileName;

    //constructor given a file name
    public StoryParser(string fileName)
    {
        _fileName = OpenStoryFile(fileName);
    }
    
    public string[] ParseStoryFile()
    { 
        string storyText = File.ReadAllText(_fileName);
        string pattern = @"([ ,.!?])";

        string[] storyArray = Regex.Split(storyText, pattern).Where(s => s.Length > 0).ToArray();
        

        return storyArray;
    }

    private string OpenStoryFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            return "DefaultStory.txt";
        }
        
        return fileName;
    }
}