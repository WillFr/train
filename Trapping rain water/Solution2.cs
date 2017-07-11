public class Solution {
    public int Trap(int[] height) {
        if(height == null || height.Length < 3){ return 0; }
        
        var s = new Stack<int>();
        
        for(int i = height.Length - 1; i >= 0; i--)
        {
            if(!s.Any() || height[i] >= height[s.Peek()])
            {
                s.Push(i);
            }
        }
        
        var lastHeight = 0;
        var count = 0;
        for(int i = 0; i < height.Length ; i ++)
        {
            var skip = false;
            if(i == s.Peek()){ 
                s.Pop();
                skip = true;
            }
            if(height[i] >= lastHeight){
                lastHeight = height[i];
                skip = true;
            }
            
            if(skip){ continue; }
            count += !s.Any() ? 0 : Math.Min(lastHeight, height[s.Peek()]) - height[i];
        }
        
        return count;
    }
}