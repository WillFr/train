public class Solution {
    public int DistributeCandies(int[] candies) {
        if(candies == null){ return 0; }
        var s = new HashSet<int>();
        foreach(var c in candies){ s.Add(c); }
        return (int)Math.Min(s.Count(), candies.Length/2);
    }
}