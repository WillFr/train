public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        if(nums == null || nums.Length == 0 || target < nums[0] || target > nums.Last()){
            return new int[]{-1,-1}; 
        }
        
        
        //lower limit
        var l = -1;
        var r= nums.Length-1;
        
        while(r-l != 1){
            var p = MedR(l,r);
            if(nums[p]>= target){
                r = p;
            }else{
                l = p;
            }
        }
        if(nums[r]!= target){ return new int[]{-1,-1}; }
        
        var lowerB = r;
        
        //upper limit
        l = lowerB;
        r= nums.Length;
        
        while(r-l != 1){
            var p = MedL(l,r);
            if(nums[p] <= target){
                l = p;
            }else{
                r = p;
            }
        }
        
        var upperB = l;
        
        return new int[]{lowerB, upperB };
        
    }
    
    private static int MedL(int l, int r){
        return l + (r-l)/2;
    }
    private static int MedR(int l, int r){
        return l + (r-l+1)/2;
    }
}