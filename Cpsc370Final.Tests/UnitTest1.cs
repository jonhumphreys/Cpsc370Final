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
    public void CheckGetFinalStory()
    {
        
    }
}