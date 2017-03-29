public class ValidWordAbbr {

    private Dictionary<string, string> hash = new Dictionary<string, string>();
    
    public ValidWordAbbr(string[] dictionary) {
        foreach(var s in dictionary)
        {
            var abr = GetAbreviation(s);
            if(!hash.ContainsKey(abr))
            {
                hash.Add(abr, s.ToLower());
            }
            else if(!hash[abr].Equals(s.ToLower()))
            {
                hash[abr] = "\n";
            }
        }
    }
    
    public bool IsUnique(string s) {
        var abr = GetAbreviation(s);
        return !hash.ContainsKey(abr) || hash[abr].Equals(s.ToLower());
    }
    
    private string GetAbreviation(string s)
    {
        var abr = s.Length > 2 ? s[0] + (s.Length-2).ToString() + s[s.Length-1] : s;
        return abr.ToLower();
    }
}

/**
 * Your ValidWordAbbr object will be instantiated and called as such:
 * ValidWordAbbr obj = new ValidWordAbbr(dictionary);
 * bool param_1 = obj.IsUnique(word);
 */