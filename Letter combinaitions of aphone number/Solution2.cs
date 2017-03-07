public class Solution {
    public IList<string> LetterCombinations(string digits, int index = 0, Dictionary<char,char[]> map = null, StringBuilder existing = null, List<string> ret = null) {
        var r = new List<StringBuilder>();
        
        if(string.IsNullOrEmpty(digits))
        {
            return new List<string>();
        }
        
        if(ret == null)
        {
            ret = new List<string>() { };
        }
        
        if(existing == null)
        {
            existing = new StringBuilder();
        }
        
        if(map == null)
        {
            map = new Dictionary<char,char[]>{
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
        }

        foreach(var d in map[digits[index]])
        {
            existing.Append(d);
            if(index == digits.Length-1)
            {
                ret.Add(existing.ToString());
            }
            else
            {
                LetterCombinations(digits, index+1, map, existing, ret);
            }
            existing.Length --;
        }
        
        return ret;
    }
}