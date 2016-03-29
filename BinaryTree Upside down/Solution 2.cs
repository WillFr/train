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
    public TreeNode UpsideDownBinaryTree(TreeNode root) {
        if(root == null){ return root; }
        var ret = root;
        
        var r = Helper(root);
        
        return r;
    }
    
    private static TreeNode Helper(TreeNode root){
        if(root.left == null){
            return root;
        }
        
        var t = root.left;
        
        var r = Helper(root.left);
        
        t.right = root;
        t.left = root.right;
        
        root.left = null;
        root.right = null;
        
        return r;
    }
}