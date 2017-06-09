public class Solution {
    public int GetSum(int a, int b) {
        /*
            100
            001
            ---
            101
            
            => OR
            
            01
            01
            --
            10
            
            => XOR + AND for carry 
            
            20
            30
            
            
            10100
            11110
            --
           001010
           101000
            --
          0100010
          0010000
          --
          0110010
          0000000
          
        */
        
        var ret = a ^ b;
        var carry = (a & b) << 1;
        while(carry != 0)
        {
            var t = ret ^ carry;
            carry = (ret & carry) << 1;
            ret = t;
        }
        
        return ret;
    }
}