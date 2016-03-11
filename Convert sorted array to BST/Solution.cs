/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode SortedArrayToBST(int[] nums) {
        if(nums == null || nums.Length == 0){ return null;}
        
        return GetMiddleNode(nums,0, nums.Length-1);
    }
    
    private TreeNode GetMiddleNode(int[] arr, int l, int r){
        var m = GetMiddle(l,r);
        var ret = new TreeNode(arr[m]);

        ret.left = m==l ? null : GetMiddleNode(arr,l,m-1);
        ret.right = m==r ? null : GetMiddleNode(arr,m+1,r);

        return ret;
    }
    
    private static int GetMiddle(int a, int b){
        return a + (b-a)/2;
    }
    
}