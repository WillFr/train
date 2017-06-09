public class Solution {
    public int SingleNumber(int[] nums) {
        if(nums == null || nums.Length == 0){
            throw new NotImplementedException();
        }
        
        if(nums.Length == 1) {
            return nums[0];
        }
        
        var x = nums[0];
        for(int i = 1; i < nums.Length ; i++)
        {
            x = x ^ nums[i];
        }
        
        return x;
    }
}