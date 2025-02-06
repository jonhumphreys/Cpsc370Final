namespace Cpsc370Final;

public class MadLib
{
    private Dictionary<string, List<string>> _wordDictionary = new Dictionary<string, List<string>>(); 
    private List<string> _finalStory; 
    private string[] _templateStory;

    public void SetTemplateStory(string[] template)
    {
        _templateStory = template;
    }
    
    public List<string> GetFinalStory()
    {
        return _finalStory;
    }

    public void GenerateFinalStory()
    {
        foreach (string word in _templateStory)
        {
            if (_wordDictionary.ContainsKey(word))
            { _finalStory.Add(SelectReplacement(word));} 
            else {_finalStory.Add(word);}
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