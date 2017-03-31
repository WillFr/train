public class Solution {
    public string ReverseString(string s) {
        if(string.IsNullOrEmpty(s)){ return s; }
        
        var sb = new StringBuilder(s);
        for(int i = 0 ; i < s.Length / 2; i++)
        {
            sb[i] = s[s.Length-1-i];
            sb[s.Length-1-i] = s[i];
        }
        
        return sb.ToString();
    }
}