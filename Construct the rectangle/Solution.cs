public class Solution {
    public int[] ConstructRectangle(int area) {
        if(area == 0){ return new int[] {0,0}; }
        
        // w * L = area
        // L >= W
        var s = Math.Sqrt(area);
        var L = (int)Math.Ceiling(s);
        while(area%L != 0){ L++; }
        var W = area/L;
        
        return new int[]{L,W};
    }
}