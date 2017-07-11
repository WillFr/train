public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        if(nums == null){ return null; }
        if(nums.Length <= 1){ return new int[nums.Length]; }
        
        var rtl = new int[nums.Length];
        rtl[nums.Length-1] = nums[nums.Length-1];
        
        for(int i = nums.Length - 2 ; i >= 0; i--){
            rtl[i] = rtl[i+1] * nums[i];
        }

        var left = 1;

        for(int i = 0; i < nums.Length;i++){
            rtl[i] = i<rtl.Length-1 ? left * rtl[i+1] : left;
            left *= nums[i];
        }
        
        return rtl;
    }
}