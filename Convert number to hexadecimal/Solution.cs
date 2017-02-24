public class Solution {
    public string ToHex(int num) {
        var unum = (uint)num;
        
        var sb = new StringBuilder();
        var mask = 15;
        var first = true;
        for(int i = 28; i >=0 ; i-=4)
        {
            var t = (num >> i) & mask;
            if(t == 0 && first){ continue; }
            if(first && t != 0){ first = false; }
            
            sb.Append(t > 9 ? ((char)('a' + (t-10))).ToString() : t.ToString());
        }
        
        if(first){ sb.Append("0"); }
        return sb.ToString();
    }
}