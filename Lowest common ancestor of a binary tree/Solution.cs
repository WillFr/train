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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var pl = new SpecialList<TreeNode>();
        var ql = new SpecialList<TreeNode>();
        
        if(!FindNodeAncestry(root, p, pl) || !FindNodeAncestry(root, q, ql)){ return null;}
        
        var i = 0;
        while(i<pl.Count() && i<ql.Count() && pl[i] == ql[i]){ i++; }
        
        return pl[i-1];
    }
    
    private bool FindNodeAncestry(TreeNode root, TreeNode target, SpecialList<TreeNode> ancestry){
         ancestry.AddS(root);
        if(root == target){
            return true;
        }
        
        var r = false;

        if(root.left != null){
            r |= FindNodeAncestry(root.left,target, ancestry);
        }
        
        if(!r && root.right != null){
            r |= FindNodeAncestry(root.right,target, ancestry);
        }
        
        ancestry.RemoveLast();
        return r;
    }
    
    private class SpecialList<T> : List<T>{
        private int size = 0;
        
        public void AddS(T root){
            if(size == this.Count()){
                this.Add(root);
            }
            else{
                this[size] = root;
            }
            size ++;
        }
        
        public void RemoveLast(){
            size--;
        }
    }
}