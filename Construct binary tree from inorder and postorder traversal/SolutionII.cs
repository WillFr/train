/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 *    1
 *  2   3
 * 5    4
 *
 * io : 2 1 4 3
 * po : 2 4 3 1
 */
public class Solution {
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        if(inorder.Length == 0){
            return null;
        }
        
        var poDic = postorder.Select((x, i) => new { x, i }).ToDictionary(pair => pair.x, pair => pair.i);
        var ioDic = inorder.Select((x, i) => new { x, i }).ToDictionary(pair => pair.x, pair => pair.i);
        
        return BuildTreeHelper(inorder, ioDic, poDic , 0, postorder.Length-1);
    }
    
    public TreeNode BuildTreeHelper(int[] inorder, Dictionary<int,int> inorderDic, Dictionary<int,int> postorder, int l, int r) {
  
        if(inorder.Length == 0 || r<l){
            return null;
        }
        
        var max = -1;
        var rootVal = -1;
        for(int i = l; i <= r; i++){
            if(max < postorder[inorder[i]])
            {
                max = postorder[inorder[i]];
                rootVal = inorder[i];
            }
            
        }
        var root = new TreeNode(rootVal);
        
        var ri = inorderDic[rootVal];
        var lr = ri-1;
        var rl = ri+1;
        
        
        root.left = BuildTreeHelper(inorder, inorderDic, postorder,l,lr);
        root.right = BuildTreeHelper(inorder, inorderDic, postorder,rl,r);
        
        return root;
    }
}