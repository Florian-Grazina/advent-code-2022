string input = File.ReadAllText("../../../input.txt");

int result = GetFirstMarker(input, 14);
Console.WriteLine(result);

static int GetFirstMarker(string input, int nbOfChar)
{
    for (int i = 0; i < input.Length - nbOfChar; i++)
    {
        string scan = input.Substring(i, nbOfChar);

        if (WordContainsDoubleLEtter(scan))
            continue;

        else
            return i + nbOfChar;
    }
    return 0;
}

static bool WordContainsDoubleLEtter(string word)
{
    foreach (char c in word)
    {
        string newWord = word;
        newWord = newWord.Replace(c.ToString(), "");

        if(word.Length - newWord.Length >= 2)
            return true;
    }

    return false;
}