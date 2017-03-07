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
    public int LongestConsecutive(TreeNode root) { bool dummy; return LongestConsecutiveHelper(root, out dummy); }
    
    public int LongestConsecutiveHelper(TreeNode root, out bool atRoot) {
        if(root == null){ atRoot = true; return 0; } 
        if(root.right == null && root.left == null){ atRoot = true; return 1;}
        
        bool ls = false,rs = false;
        var lr = LongestConsecutiveHelper(root.left, out ls);
        var rr = LongestConsecutiveHelper(root.right, out rs);
        
        bool arr = false,arl = false;
        if(root.right != null && rs && root.right.val == root.val + 1)
        {
            rr++;
            arr = true;
        }
        
        if(root.left != null && ls && root.left.val == root.val + 1)
        {
            lr++;
            arl = true;
        }
        
        var max = Math.Max(lr,rr);
        atRoot = max == lr ? arl : arr;
        atRoot = max == 1 ? true : atRoot;
        return max;
    }
}