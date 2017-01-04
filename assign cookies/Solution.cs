public class Solution {
    public int FindContentChildren(int[] g, int[] s) {
        if(g == null || s == null) { return 0; } 
        
        Array.Sort(g);
        Array.Sort(s);
        
        var i = 0;
        var j = 0;
        var r = 0;
        while(i<s.Length && j< g.Length){
            if(s[i] >= g[j] ){j++; r++;}
            i++;
        }
        
        return r;
    }
}