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
    public void Flatten(TreeNode root) {
        Helper(root);
    }
    
    private TreeNode Helper(TreeNode root){
        if(root == null) { return root; }
        
        var r = root.right;
        var l = root.left;
        
        var tailL = Helper(l);
        var tailR = Helper(r);
        
        var tail = root;
        tail.left = null;
        tail.right = null;
        
        tail.right = l;
        tail = l != null ? tailL : tail;
        
        tail.right = r;
        tail = r != null ? tailR : tail;
        
        return tail;
    }
}