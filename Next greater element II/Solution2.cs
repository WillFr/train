public class Solution {
    public int[] NextGreaterElements(int[] nums) {
        if(nums == null){ return null; } 
        if(nums.Length == 0) { return new int[0]; }
        
        var ret = new int[nums.Length];
        var s = new Stack<int>();
        
        int ii = (nums.Length * 2) - 1;
        int max = int.MinValue;
        
        while(ii >= 0 && !(ii < nums.Length && nums[ii] == max))
        {
            var i = ii % nums.Length;
            max = Math.Max(nums[i],max);
            while(s.Any() && s.Peek() <= nums[i]){ s.Pop(); }
            if(s.Any())
            {
                ret[i] = s.Peek();
            }
            else
            {
                ret[i] = -1;
            }
            
            s.Push(nums[i]);
            ii--;
        }
        
        return ret;
    }
}