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
    public IList<int> ClosestKValues(TreeNode root, double target, int k) {
        var r = new List<int>();
        if(root == null || k == 0){ return r; }
        
        var l = new LinkedList<TreeNode>();
        var closest = FillList(l, root, target);
        
        Console.WriteLine(String.Join(",", l.Select(x => x.val)));
        Console.WriteLine(closest.Value.val);
        var left = closest;
        var right = closest.Next;
        
        while(r.Count() != k){
            var dl = Distance(left?.Value, target);
            var dr =  Distance(right?.Value, target);
            //Console.WriteLine($"{left?.Value.val} <? {right?.Value.val}");
            //Console.WriteLine($"{dl} <? {dr}");
            var t = dl < dr ? left : right;
            r.Add(t.Value.val);
            left = dl < dr? left.Previous : left;
            right = dl >= dr ? right.Next : right;
        }
        
        return r;
    }
    
    private static double Distance(TreeNode t, double target )
    {
        if(t == null) { return double.MaxValue; }
        
        return Math.Abs(t.val - target);
    }
    
    
    private static LinkedListNode<TreeNode> FillList(LinkedList<TreeNode> ll, TreeNode root, double target){
        if(root == null){ return null; }
        
        var l = FillList(ll, root.left, target);
        var node = new LinkedListNode<TreeNode>(root);
        ll.AddLast(node);
        var r = FillList(ll, root.right, target);
        
        var d1 = Distance(l?.Value, target);
        var d2 = Distance(r?.Value, target);
        var d3 = Distance(root, target);
        
        if(d1 <= d2 && d1 <= d3){ return l; }
        else if (d2 <= d1 && d2 <= d3){ return r; }
        else { return node; }
    }
    
}