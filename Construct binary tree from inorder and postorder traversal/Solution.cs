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
        
        return BuildTreeHelper(inorder, postorder.Select((x, i) => new { x, i }).ToDictionary(pair => pair.x, pair => pair.i), 0, postorder.Length-1);
    }
    
    public TreeNode BuildTreeHelper(int[] inorder, Dictionary<int,int> postorder, int l, int r) {
        //Console.WriteLine("Helper " + l + " - " + r);
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
        //Console.WriteLine("root="+rootVal);
        int ll = l, lr = -1, rl = -1, rr = r;
        for(int i = l; i <= r; i++){
            if(inorder[i] == root.val){ lr = i-1;rl = i+1; continue; }
        }
        
        
        root.left = BuildTreeHelper(inorder, postorder,ll,lr);
        root.right = BuildTreeHelper(inorder, postorder,rl,rr);
        
        return root;
    }
}