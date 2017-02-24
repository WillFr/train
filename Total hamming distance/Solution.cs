public class Solution {
    public int TotalHammingDistance(int[] nums) {
        if(nums == null || nums.Length == 0){ return 0; }
        var mask = 1;
        var hamming = 0;
        var max = nums.Max();
        
        for(int i = 0; i < 32 && mask<= max; i ++){
            var reff = mask & nums[0];
            var diff = 0;
            foreach(var n in nums){
                if((n & mask) != reff){ diff ++; } 
            }
            mask = mask * 2;
            hamming += diff * (nums.Length - diff);
        }
        
        return hamming;
    }
}