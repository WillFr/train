public class Solution {
    public int HammingWeight(uint n) {
        var c = 0;
        while(n != 0)
        {
            if((n & 1) != 0){ c++; }
            n >>= 1;
        }
        return c;
    }
}