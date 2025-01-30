namespace Cpsc370Final.Tests;

public class UnitTest1
{
    [Fact]
    public void ParseDefaultWordDictionaryJsonFile()
    {
        WordParser wordParser = new WordParser();
        Dictionary<string, List<string>> wordDictionary = wordParser.GetWordDictionary();
        Assert.NotNull(wordDictionary);
    }

    [Fact]
    public void ParseStoryFile()
    {
        StoryParser storyParser = new StoryParser("DefaultStory.txt");
        string[] storyArray = storyParser.ParseStoryFile();
        string[] expectedStoryArray = ["This", " ", "is", " ", "the", " ", "default", " ", "story", ",", " ", "everybody", "."];
        Assert.NotNull(storyArray);
        Assert.Equal(expectedStoryArray, storyArray);
    }

    [Fact]
    public void ParseDefaultStoryFileWhenGivenFileDoesNotExist()
    {
        StoryParser storyParser = new StoryParser("Fake.txt");
        string[] storyArray = storyParser.ParseStoryFile();
        string[] expectedStoryArray = ["This", " ", "is", " ", "the", " ", "default", " ", "story", ",", " ", "everybody", "."];
        Assert.NotNull(storyArray);
        Assert.Equal(expectedStoryArray, storyArray);
    }
}