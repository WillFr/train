public class Solution
{
    public void ReverseWords(char[] s)
    {
        if (s.Length <= 2) { return; }

        var idxs = GetWordsIndexes(s);
        foreach (var tuple in idxs)
        {
            ReversePartOfString(s, tuple.Item1, tuple.Item2);
        }

        ReversePartOfString(s, 0, s.Length - 1);
    }

    public List<Tuple<int, int>> GetWordsIndexes(char[] s)
    {
        var l = new List<Tuple<int, int>>();

        var currentStart = s[0] == ' ' ? -1 : 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ' && currentStart != -1)
            {
                l.Add(new Tuple<int, int>(currentStart, i - 1));
                currentStart = -1;
            }
            else if (s[i] != ' ' && currentStart == -1)
            {
                currentStart = i;
            }
        }

        if (currentStart != -1)
        {
            l.Add(new Tuple<int, int>(currentStart, s.Length - 1));
        }

        return l;
    }

    private static void ReversePartOfString(char[] s, int start, int end)
    {
        while (start < end)
        {
            Switch(s, start++, end--);
        }
    }

    private static void Switch(char[] s, int i, int j)
    {
        var t = s[i];
        s[i] = s[j];
        s[j] = t;
    }
}