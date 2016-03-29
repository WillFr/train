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
    public IList<IList<int>> VerticalOrder(TreeNode root) {
        var ret = new List<IList<int>>();
        if(root == null){ return ret; }
        
        var d = new Dictionary<int,List<int>>();
        var min = Helper(root, d );
        
        var i = min;
        
        while(d.ContainsKey(i)){
            ret.Add(d[i]);
            i++;
        }
        
        return ret;
    }
    
    private static int Helper(TreeNode root, Dictionary<int,List<int>> dic){
        var q = new Queue<Tuple<TreeNode, int>>();
        q.Enqueue( new Tuple<TreeNode, int>(root,0) );
        var min = 0;
        
        while(q.Any()){
            var t = q.Dequeue();
            if(!dic.ContainsKey(t.Item2)){
                dic.Add(t.Item2, new List<int>());
            }
            
            dic[t.Item2].Add(t.Item1.val);
            
            if(t.Item1.left != null){
                q.Enqueue( new Tuple<TreeNode, int>(t.Item1.left ,t.Item2-1));
                if(t.Item2-1 < min){ min = t.Item2-1; }
            }
            
            if(t.Item1.right != null){
                q.Enqueue( new Tuple<TreeNode, int>(t.Item1.right ,t.Item2+1));
            }
        }
        
        return min;
    }
}