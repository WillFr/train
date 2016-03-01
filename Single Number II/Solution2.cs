/*
The idea is to count how many time the bits appear.
here they can appear  eiher 0 time, one time or two time, 
because if they appear three time, then we can reset the counter to 0, because they are part of the numbers that appear three time


*/


public class Solution {
    public int SingleNumber(int[] nums) {
        var n1 = 0; 
        var n2 = 0;
        
        foreach(var i in nums){
            var t = n2;
            n2 = (n1 & i ) | (n2 & ~i); // the bit who were already at 1, or the bit that were already at 2 and  dd not change
            n1 = (~n1 & i & ~t) | (n1 & ~i); // the bits who were previously at 0, or already at one and did not change
        }
        
        return n1 | n2;
    }
}