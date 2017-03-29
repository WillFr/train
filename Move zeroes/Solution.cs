public class Solution {
    public void MoveZeroes(int[] nums) {
        if(nums == null || nums.Length == 0){ return; }
        
        var l = 0;
        var r = 0;
        
        while(r < nums.Length)
        {
            if(nums[r] == 0)
            {
                r++;
            }
            else
            {
                nums[l++] = nums[r++];
            }
        }
        
        while(l < nums.Length)
        {
            nums[l++] = 0;
        }
    }
}