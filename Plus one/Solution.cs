public class Solution {
    public int[] PlusOne(int[] digits) {
        var i = digits.Length-1;
        
        while(i >= 0 && digits[i]  == 9){ digits[i] = 0; i--; }
        
        if(i>= 0)
        {
            digits[i]++;
            return digits;
        }
        else
        {
            var r = new int[digits.Length+1];
            r[0] = 1;
            for(int k = 0; k < digits.Length; k++)
            {
                r[k+1] = digits[k];
            }
            
            return r;
        }
        
        
    }
}