public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        var random = new Random();
        var wordsToHide = _words.Where(w => !w.IsHidden()).OrderBy(x => random.Next()).Take(numberToHide).ToList();
        foreach (var word in wordsToHide)
        {
            word.Hide();
        }
    }
        public string GetDisplayText()
    {
        var text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()}: {text}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public void ShowAllWords()
    {
        foreach (var word in _words)
        {
            word.Show();
        }
    }
        public int GetRemainingWordCount()
    {
        return _words.Count(w => !w.IsHidden());
    }

}