public class Solution {
    private const int limit = 2;
    public int RemoveDuplicates(int[] nums) {
        if(nums == null) { return 0;}
        if(nums.Length <= 1) return nums.Length;
        
        var count = 1;
        var k = 1;
        
        for(int i = 1; i<nums.Length; i++){
            if(nums[i] == nums[i-1]){
                if(k == limit){ continue; }
                else{nums[count] = nums[i]; k++; count ++;}
            }
            else{
                nums[count] = nums[i];
                count ++;
                k = 1;
            }
        }
        
        return count;
    }
}