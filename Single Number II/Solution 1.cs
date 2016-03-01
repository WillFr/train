public class Solution {
    public int SingleNumber(int[] nums) {
        var h = new Dictionary<int, int>();
        
        foreach(var i in nums){
            if(h.ContainsKey(i)){
                if(h[i]==2){
                    h.Remove(i);
                }
                else{
                    h[i]++;
                }
            }
            else{
                h.Add(i,1);
            }
        }
        
        return h.Keys.First();
    }
}