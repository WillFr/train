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
    public int LongestConsecutive(TreeNode root) {
        if(root == null){ return 0; }
        
        TreeNode s;
        return LongestConsecutive(root,out s);
    }
    
     public int LongestConsecutive(TreeNode root, out TreeNode seqStart){
         var ret = 1;
         seqStart = root;
         
         if(root.left != null){
             TreeNode ls;
             var l = LongestConsecutive(root.left, out ls);
             
             if(ls == root.left && root.val == root.left.val-1 && l+1 > ret){
                 seqStart = root;
                 ret = l+1;
             }
             else if(l > ret){
                 seqStart = ls;
                 ret = l;
             }
         }
         
         if(root.right != null){
             TreeNode rs;
             var r = LongestConsecutive(root.right, out rs);
             
             if(rs == root.right && root.val == root.right.val-1 && r+1 > ret){
                 seqStart = root;
                 ret = r+1;
             }
             else if(r > ret){
                 seqStart = rs;
                 ret = r;
             }
         }
         
         return ret;
     }
}