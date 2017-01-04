public class Solution {
    public int Search(int[] nums, int target) {
        if(nums == null || nums.Length == 0 )
        {
            return -1;
        }
        
        if(nums.Length == 1)
        {
            return nums[0] != target ? -1 : 0;
        }
        
        // find the rotation point
        var l = 0; 
        var r = nums.Length-1;
        
        var rot = 0;
        if(nums[l] > nums[r]){
            while( r - l != 1){
                var p = Middle(l,r);
                if(nums[p] >= nums[l]){
                    l = p;
                }
                else{
                    r = p;   
                }
            }
            rot = nums.Length - (l+1);
            
            l++;
            r--;
        }
        
        
        
        var rotR = (r+rot)%nums.Length+1;
        var rotL = (l+rot)%nums.Length;
        
        while( rotR - rotL != 1){
            var p = Middle(rotL,rotR);
            var unRotP = (p + nums.Length - rot)%nums.Length;
            if(target >= nums[unRotP]){
                l = unRotP;
                rotL = p;
            }
            else{
                r = unRotP; 
                rotR = p;
            }
        }
        
        return nums[l] == target ? l : -1;
    }
    

    private static int Middle(int l, int r){
        return l + (r-l)/2;
    }
}