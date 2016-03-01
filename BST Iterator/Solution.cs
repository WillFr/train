/**
 * Definition for binary tree
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class BSTIterator {

    private Stack<TreeNode> stack = new Stack<TreeNode>();
    
    public BSTIterator(TreeNode root) {
        StackIt(root);
        
    }

    /** @return whether we have a next smallest number */
    public bool HasNext() {
        return this.stack.Any();
    }

    /** @return the next smallest number */
    public int Next() {
        var r = stack.Pop();
        StackIt(r.right);
        return r.val;
    }
    
    private void StackIt(TreeNode n){
        var t = n;
        while(t != null){
            this.stack.Push(t);
            t = t.left;
        }
    }
}

/**
 * Your BSTIterator will be called like this:
 * BSTIterator i = new BSTIterator(root);
 * while (i.HasNext()) v[f()] = i.Next();
 */