public class Solution {
    public string IntToRoman(int num) {
        /*
            Examples:
            I => 1
            II => 2
            III => 3 
            IV => 4
            V => 5
            VI => 6
            VII => 7
            VIII => 8
            IX => 9
            X => 10
            L => 50
            C => 100
            M => 1000
        */
        
        var h = new Dictionary<string,int>{
            {"I", 1},
            {"IV", 4},
            {"V", 5},
            {"IX", 9},
            {"X", 10},
            {"XL", 40},
            {"L", 50},
            {"XC", 90},
            {"C", 100},
            {"CD", 400},
            {"D", 500},
            {"CM", 900},
            {"M", 1000}
        };
        
        var keys = h.Keys.OrderByDescending(x => h[x]).ToArray();
        
        var sb = new StringBuilder();
        var i = 0;
        while(i != keys.Length){
            var successive = 0;
            while(num >= h[keys[i]]){
                num -= h[keys[i]];
                sb.Append(keys[i]);
                successive++;
            }
            i++;
        }
        
        return sb.ToString();
    }
}