public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        // a +b+c = 0   <=> a+b = -c
        var r = new List<IList<int>>();
        
        if(nums == null || nums.Length<3){ return r;}
        
        Array.Sort(nums);
        
        var s =  new Dictionary<int,int>();
        for(int i = 0; i< nums.Length; i++){
            if(!s.ContainsKey(nums[i])){
                s.Add(nums[i], 1);
            }
            else{
                s[nums[i]]++;
            }
        }
        
        
        for(int i = 0; i<nums.Length; i++){
            if(i > 0 && nums[i] == nums[i-1]){ continue;}
            for(int j = i+1; j< nums.Length; j++){
                if(j > i+1 && nums[j] == nums[j-1]){ continue;}
                
                var a = nums[i];
                var b = nums[j];
                var c = (a+b) * (-1);
                
                if(c >= b && s.ContainsKey(c) && (
                s[c] == 1 && c!= a && c!= b
                || s[c] == 2 && (c!= a || c!= b)
                || s[c] >= 3
                )){
                    r.Add(new List<int>(){a,b,c});
                }
            }
        }
        
        return r;
    }
}