public class Solution {
    public int[] NextGreaterElements(int[] nums) {
        if(nums == null){ return null; } 
        if(nums.Length == 0) { return new int[0]; }
        
        var ret = new int[nums.Length];
        var s = new Stack<int>();
        
        for(int ii = (nums.Length * 2) - 1; ii >= 0; ii--)
        {
            var i = ii % nums.Length;
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
        }
        
        return ret;
    }
}