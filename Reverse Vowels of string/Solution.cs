public class Solution {
    public string ReverseVowels(string s) {
        if(string.IsNullOrEmpty(s) || s.Length == 1)
        {
            return s;
        }
        
        var v = new HashSet<char>(){'a','e','i','o','u','A','E','I','O','U'};
        
        var l = 0; 
        var r = s.Length -1;
        var sb = new StringBuilder(s);
        
        while(l < r){
            while(l<r && !v.Contains(s[l]) ){l++;}
            while(r>l && !v.Contains(s[r]) ){r--;}
            
            if(l<r)
            {
               sb[l] = s[r];
               sb[r] = s[l];
                
                l++;
                r--;
            }
        }
        
        return sb.ToString();
    }
}