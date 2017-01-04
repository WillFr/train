public class Solution {
    public int Trap(int[] height) {
        if(height.Length < 3){
            return 0;
        }
        
        var water = new int[height.Length];
        
        int l = 0, L = 0;
        int r = height.Length-1, R = height.Length-1;
        
        while(R>L)
        {
            while(l<= R && height[l] <= height[R]){
                if(height[l] >= height[L]){ L = l; }
                
                water[l] = Math.Max(0, height[L]-height[l]);
                l++;
            }
            L = l;
            
            while(r >= L && height[r] <= height[L]){
                if(height[r] >= height[R]){ R = r; }
                
                water[r] = Math.Max(0, height[R]-height[r]);
                r--;
            }
            R = r;
        }
        
        // Console.WriteLine(string.Join(",", water));
        return water.Sum();
    }
}