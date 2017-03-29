public class Solution {
    public int MaxSubArrayLen(int[] nums, int k) {
        if(nums == null || nums.Length == 0){ return 0; }
        
        var sums = new int[nums.Length];
        sums[0] = nums[0];
        for(int i = 1; i < nums.Length; i++)
        {
            sums[i] = sums[i-1] + nums[i];
        }
        
        var dict = new Dictionary<int,int>();
        dict.Add(0,-1);
        for(int i = 0; i < nums.Length; i++)
        {
            if(!dict.ContainsKey(sums[i]))
            {
                dict.Add(sums[i],i);
            }
        }
        
        
        var max = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            if(dict.ContainsKey(sums[i]-k) && dict[sums[i]-k] <= i)
            {
                max = Math.Max(max, i - dict[sums[i]-k]);
            }
        }
        
        return max;
    }
}