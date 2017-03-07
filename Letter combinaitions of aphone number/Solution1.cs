public class Solution {
    public IList<string> LetterCombinations(string digits) {
        var r = new List<StringBuilder>();
        
        if(string.IsNullOrEmpty(digits))
        {
            return new List<string>();
        }
        
        var map = new Dictionary<char,char[]>{
            {'2', new char[]{'a','b','c'}},
            {'3', new char[]{'d','e','f'}},
            {'4', new char[]{'g','h','i'}},
            {'5', new char[]{'j','k','l'}},
            {'6', new char[]{'m','n','o'}},
            {'7', new char[]{'p','q','r','s'}},
            {'8', new char[]{'t','u','v'}},
            {'9', new char[]{'w','x','y', 'z'}},
            {'0', new char[]{' '}},
            
        };
        
        r.Add(new StringBuilder());
        
        foreach(var d in digits)
        {
            var possibilities = map.ContainsKey(d) ? map[d] : Enumerable.Empty<char>();
            var end = r.Count();
            for(int i = 0; i < end; i++)
            {
                var e = r[i];
                char first= '0';
                foreach(var p in possibilities)
                {
                    if(first == '0')
                    {
                        first = p;
                        continue;
                    }
                    
                    var t = new StringBuilder(e.ToString());
                    t.Append(p);
                    r.Add(t);
                }
                
                if(first != '0')
                {
                    e.Append(first);
                }
            }
        }
        
        return r.Where(x => x.Length >0).Select(x => x.ToString()).ToList();
    }
}