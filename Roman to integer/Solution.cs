public class Solution {
    public int RomanToInt(string s) {
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
        
        var h = new Dictionary<char,int>{
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
        
        var sum = 0;
        for(int i=0 ; i<s.Length; i++)
        {
            if(i < s.Length-1 && h[s[i]] < h[s[i+1]])
            {
                // numbers are not sorted in increasing order and therefore should be substracted
                sum -= h[s[i]];
            }
            else
            {
               sum += h[s[i]]; 
            }
        }
        
        return sum;
    }
}