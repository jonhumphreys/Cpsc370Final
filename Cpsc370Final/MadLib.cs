namespace Cpsc370Final;

public class MadLib
{
    private string[] _templateStory;
    private WordDictionary _wordDictionary;
    private List<string> _finalStoryWords;

    public MadLib(string[] templateStory, WordDictionary wordDictionary)
    {
        _templateStory = templateStory;
        _wordDictionary = wordDictionary;
        _finalStoryWords = new List<string>();
    }
    
    public void SetWordDictionary(WordDictionary wordDictionary)
    {
        _wordDictionary = wordDictionary;
    }
    
    public void SetTemplateStory(string[] template)
    {
        _templateStory = template;
    }

    public string GetFinalStory()
    {
        string story = "";
        foreach (string word in _finalStoryWords)
        {
            story += word;
        }
        story = story.Trim();
        return story;
    }

    public List<string> GetFinalStoryWords()
    {
        return _finalStoryWords;
    }

    public void GenerateFinalStory()
    {
        foreach (string word in _templateStory)
        {
            if (_wordDictionary.ContainsKey(word))
            { _finalStoryWords.Add(SelectReplacement(word));} 
            else {_finalStoryWords.Add(word);}
        }
    }

    private string SelectReplacement(string word)
    {
        List<string> listToSelectFrom = _wordDictionary[word];
        string randomWord = SelectRandomWord(listToSelectFrom);
        return randomWord;
    }

    private string SelectRandomWord(List<string> listToSelectFrom)
    {
        string randomWord = listToSelectFrom[new Random().Next(0, listToSelectFrom.Count)];
        return randomWord;
    }
}