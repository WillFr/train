public class Solution {
    public void WiggleSort(int[] nums) {
        int i;
        for(i = 0; i < nums.Length-2; i+=2)
        {
            if(nums[i] >= nums[i+1] && nums[i] >= nums[i+2])
            {
                Swap(nums, i, i+1);
            }
            else if(nums[i+2] >= nums[i+1] && nums[i+2] >= nums[i])
            {
                Swap(nums, i+2, i+1);
            }
        }
        
        if(i == nums.Length-2 && nums[i] > nums[i+1])
        {
            Swap(nums, i, i+1);
        }
        
    }
    
    private static void Swap<T>(T[] arr, int i , int j)
    {
        var t = arr[i];
        arr[i] = arr[j];
        arr[j] = t;
    }
}