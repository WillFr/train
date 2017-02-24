public class Solution {
    public int CountSegments(string s) {
        if(string.IsNullOrEmpty(s)){ return 0; }
        var c = 0;
        
        for(int i = 1; i < s.Length; i++){
            if(s[i] == ' ' && s[i-1] != ' '){ c++; }
        }
        
        if(s[s.Length-1] != ' '){ c++; }
        
        return c;
    }
}