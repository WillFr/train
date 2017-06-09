public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var h = new Dictionary<int,int>();
        for(int i = 0; i < nums.Length; i++)
        {
            // we are guaranteed to have a unique solution : if they are duplicate
            // they are either useful because we need to sum them to the target, or we do not care 
            // because they won't be part of the solution (it would result in several solutions)
            if(h.ContainsKey(nums[i]))
            {
                if(target == nums[i] * 2)
                {
                    return new int[]{h[nums[i]], i};
                }
            }
            else
            {
                h.Add(nums[i], i);
            }
        }
        
        for(int i = 0; i < nums.Length; i++)
        {
            if(h.ContainsKey(target-nums[i]) && h[target-nums[i]] != i)
            {
                return new int[]{h[target-nums[i]],i};
            }
        }
        
        return null;
    }
}