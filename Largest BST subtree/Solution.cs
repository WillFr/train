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
    public int LargestBSTSubtree(TreeNode root) {
        if(root == null){ return 0; }
        int c,min,max;
        CountBSTNodes(root, out c, out min, out max);
        
        return c;
    }
    
    private static bool CountBSTNodes(TreeNode root, out int count, out int min, out int max){
        min = root.val; max = root.val;
        if(root.left == null && root.right == null){ count = 1;  return true; }
        
        
        var retVal = true;
        
        bool isLeftBST = true;
        int l = 0;
        
        if(root.left != null){
            int minl, maxl;
            isLeftBST = CountBSTNodes(root.left, out l, out minl, out maxl);
            min = minl;
            if(!isLeftBST || maxl > root.val){ retVal = false;}
            
        }
        
        bool isRightBST = true;
        int r = 0;
        if(root.right != null){
            int  minr, maxr;
            isRightBST = CountBSTNodes(root.right, out r, out minr, out maxr);
            max = maxr;
            if(!isRightBST || minr < root.val){ retVal = false; }
        }
        
        if(retVal){ 
            count = 1+l+r; 
        }
        else{
            count = (int)Math.Max(l,r);
        }
        
        return retVal;
    }
}