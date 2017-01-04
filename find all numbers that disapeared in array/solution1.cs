public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        var r = new List<int>();
        if(nums == null || nums.Length == 0){
            return r;
        }
        
        for(int i = 0; i < nums.Length; i++){
            if(nums[i] == i+1){ continue; }
            
            var j = nums[i];
            while(j != nums[j-1]){
                var t= nums[j-1];
                nums[j-1] = j;
                j = t;
            }
        }
        
        for(int i = 0; i < nums.Length; i ++){
            if(nums[i] != i+1){ r.Add(i+1); }
        }
        
        return r;
    }
}