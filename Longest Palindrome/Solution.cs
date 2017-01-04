public class Solution {
    public int LongestPalindrome(string s) {
        if(string.IsNullOrEmpty(s)){ return 0; } 
        
        var set = new HashSet<char>();
        
        var l = 0;
        foreach(var c in s){
            if(set.Contains(c)){
                l+=2;
                set.Remove(c);
            }
            else{
                set.Add(c);
            }
            
        }
        
        if(set.Any()){
            l++;
        }
        
        return l;
    }
}