public class Solution {
    public IList<string> FindMissingRanges(int[] nums, int lower, int upper) {
        if(nums == null || nums.Length == 0)
        {
            return new List<string>() { RangeToString(lower, upper) };
        }
        
        var r = new List<string>();
        if(nums[0] != lower)
        {
            r.Add(RangeToString(lower, nums[0]-1));
        }
        
        for(int i = 1; i < nums.Length ; i++){
            if(nums[i-1] == nums[i])
            {
                continue;
            }
            
            if(nums[i] !=  nums[i-1] +1)
            {
                r.Add(RangeToString(nums[i-1]+1, nums[i]-1));
            }
        }
        
        if(nums[nums.Length-1] != upper)
        {
            r.Add(RangeToString(nums[nums.Length-1] + 1, upper));
        }
        
        return r;
    }
    
    private static string RangeToString(int a, int b)
    {
        return a == b ? a.ToString() : a+"->"+b;
    }
}