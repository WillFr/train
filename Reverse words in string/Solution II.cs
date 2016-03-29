public class Solution {
    public string ReverseWords(string ss) {
        var s = new StringBuilder(ss);
        var last = 0;
        for(int i =0; i <=s.Length; i++){
            if((i == s.Length || s[i] == ' ') && last != i){
                Reverse(s, last, i-1);
                last = i+1;
            }
        }
        
        Reverse(s,0,s.Length-1);
        
        var trim = 0;
        var wasSpace = true;
        
        for(int i = 0; i < s.Length; i ++){
            if(s[i] == ' ' && wasSpace){ continue; }
            wasSpace = s[i] == ' ';
            s[trim++] = s[i];
        }
        
        if(trim > 0 && s[trim-1] == ' '){ trim --; }
        return s.ToString().Substring(0,trim);
    }
    
    private static void Reverse(StringBuilder s, int l, int r){
        while(l < r){
            Swap(s, l , r);
            l++;
            r--;
        }
    }
    
    private static void Swap(StringBuilder s, int i, int j){
        var t = s[i];
        s[i] = s[j];
        s[j] = t;
    }
}