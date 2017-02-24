public class Solution {
    public int FindComplement(int num) {
        return ~num & (int)(Math.Pow(2, Math.Floor(Math.Log(num,2)))-1);
    }
}