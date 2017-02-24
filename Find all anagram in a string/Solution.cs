public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        if(string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p) || s.Length < p.Length){
            return new List<int>();
        }
        
        var h = new Dictionary<char, int>();
        
        for(int i = 0 ; i < p.Length ; i ++){
            if(!h.ContainsKey(p[i])){
                h.Add(p[i], 0);
            }
            h[p[i]] ++;
        }
        var sum = h.Keys.Count();
        
        var r = new List<int>();
        
        for(int i = 0 ; i < p.Length ; i ++){
            if(h.ContainsKey(s[i])){
                if(h[s[i]] == 0){sum ++; }
                if(h[s[i]] == 1){sum --; }
                h[s[i]]--;
            }
        }
        if(sum == 0){r.Add(0); }
        
        for(int i = p.Length; i < s.Length; i++){
            var k = i - p.Length;
            
            if(h.ContainsKey(s[k])){
                if(h[s[k]] == 0){sum ++; }
                if(h[s[k]] == -1){sum --; }
                h[s[k]]++;
            }
            
            if(h.ContainsKey(s[i])){
                if(h[s[i]] == 0){sum ++; }
                if(h[s[i]] == 1){sum --; }
                h[s[i]]--;
            }
            
            if(sum == 0){r.Add(k + 1); }
        }
        
        return r;
    }
}