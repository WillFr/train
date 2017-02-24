public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        if(nums == null || nums.Length ==0){ return 0; }
        
        var c = 0;
        var max = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] == 1 ){
                c++;
            }
            else{
                max = Math.Max(max,c);
                c = 0;
            }
        }
        
        max = Math.Max(max,c);
        return max;
    }
}