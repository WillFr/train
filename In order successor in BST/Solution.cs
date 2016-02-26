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
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
        if(root == null){ return null; }
        if(p == null){ return null; }
        if(p == root){ return root.right; }
        
        if(p.right != null){ return LeftMost(p.right); }
        else{ 
            var t = root;
            TreeNode lastRight = null;
            
            while(t != p){
                if (p.val <= t.val){ lastRight = t; t = t.left; }
                else{ t = t.right; }
            }
            
            return lastRight;
        }
    }
    
    private static TreeNode LeftMost(TreeNode root){
        if(root.left == null && root.right == null){
            return root;
        }
        else if(root.left != null){
            return LeftMost(root.left);
        }
        else{
            return root;
        }
    }
}