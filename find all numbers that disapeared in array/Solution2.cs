public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        var r = new List<int>();
        if(nums == null || nums.Length == 0){
            return r;
        }
        
        for(int i = 0; i < nums.Length; i++){
            var abs = (int)Math.Abs(nums[i]);
            nums[abs - 1] = (int)Math.Abs(nums[abs - 1]) * -1;
        }
        
        for(int i = 0; i < nums.Length; i ++){
            if(nums[i] > 0){ r.Add(i+1); }
        }
        
        return r;
    }
}