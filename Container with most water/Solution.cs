public class Solution {
    public int MaxArea(int[] height) {
        if(height == null || height.Length == 0){ return 0; }
        
        var max = 0;
        var l = 0;
        var r = height.Length - 1;
        
        while(l!=r){
            max = Math.Max(max, (r-l) * Math.Min(height[l], height[r]));
            
            if(height[l] < height[r]){ l++; }
            else{ r--;}
        }
        
        return max;
    }
}