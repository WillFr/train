public class Solution {
    public int LengthOfLongestSubstringKDistinct(string s, int k) {
        if(string.IsNullOrEmpty(s) || k == 0){ return 0; }
        var max = 0;
        var d = new Dictionary<char, int>();
        var l = 0;
        var c = 0;
        for(int i = 0; i < s.Length; i++){
            if(!d.ContainsKey(s[i])){ d.Add(s[i], 0); c++; }
            
            d[s[i]]++;
            l++;
            
            while( c> k)
            {
                var j = i-l+1;
                d[s[j]]--;
                l--;
                if(d[s[j]] == 0){
                    d.Remove(s[j]);
                    c--;
                }
            }
            
            max = Math.Max(l,max);
        }
        return max;
    }
}