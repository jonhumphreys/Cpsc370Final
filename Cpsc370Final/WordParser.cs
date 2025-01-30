namespace Cpsc370Final;

using System.Text.Json;

public class WordParser
{
    private WordDictionary _dictionary;
    private const string DefaultJsonFileName = "DefaultWords.json";

    public WordParser(string fileName = DefaultJsonFileName)
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"File {fileName} not found");
        }
        string json = File.ReadAllText(fileName);
        _dictionary = JsonSerializer.Deserialize<WordDictionary>(json);
    }

    public WordDictionary GetWordDictionary()
    {
        return _dictionary;
    }
}