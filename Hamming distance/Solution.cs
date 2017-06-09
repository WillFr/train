public class Solution {
    public int HammingDistance(int x, int y) {
        var c = 0;
        var t = x ^ y;
        
        while(t != 0)
        {
            if((t&1) != 0){ c++; }
            t >>= 1;
        }
        
        return c;
    }
}