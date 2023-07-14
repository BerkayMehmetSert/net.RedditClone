using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Core.Utilities.Filter;

public static class FilterHelper
{
    private static readonly string[] BadWords = File.ReadAllLines("bad-words.txt");

    public static void FilteredText(string text)
    {
        if (BadWords.Any(text.Contains))
            throw new BusinessException(FilterBusinessMessages.BadWords);
    }
}