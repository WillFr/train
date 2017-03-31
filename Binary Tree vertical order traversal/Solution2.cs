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
        if(root == null)
        {
            return new List<IList<int>>();
        }
        var dict = new Dictionary<int, List<int>>();
        
        var t = Helper(root, dict);
        
        var ret = new List<IList<int>>();
        for(int i = t.Item1; i <= t.Item2 ; i++)
        {
            var l = dict.ContainsKey(i) ? dict[i] : new List<int>();
            ret.Add(l);
        }
        return ret;
    }
    
    private static Tuple<int,int> Helper(TreeNode root, Dictionary<int, List<int>> dict)
    {
        var q = new Queue<Tuple<TreeNode,int>>();
        q.Enqueue(new Tuple<TreeNode,int>(root,0));
        var min = 0;
        var max = 0;
        while(q.Any())
        {
            var c = q.Dequeue();
            var index = c.Item2;
            var cNode = c.Item1;
            
            min = Math.Min(min,index);
            max = Math.Max(max,index);
            
            if(!dict.ContainsKey(index)){ dict.Add(index, new List<int>()); }
            dict[index].Add(cNode.val);
            
            if(cNode.left != null){ q.Enqueue(new Tuple<TreeNode, int>(cNode.left, index-1)); }
            if(cNode.right != null){ q.Enqueue(new Tuple<TreeNode, int>(cNode.right, index+1)); }
        }
        
        
        return new Tuple<int,int>(min,max);
    }
}