public class Solution {
    public int FindComplement(int num) {
        var mask = ~0;
        while ((mask & num) != 0){ mask <<= 1; }
        
        return ~num & ~mask;
    }
}