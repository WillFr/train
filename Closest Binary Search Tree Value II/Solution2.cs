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
        
        var l = new List<TreeNode>();
        var closest = FillList(l, root, target);
        
        //Console.WriteLine(String.Join(",", l.Select(x => x.val)));
        //Console.WriteLine(closest.Value.val);
        var left = closest;
        var right = closest +1;
        
        while(r.Count() != k){
            var dl = Distance(left == -1 ? null : l[left], target);
            var dr =  Distance(right<l.Count() ? l[right] : null, target);
            //Console.WriteLine($"{left?.Value.val} <? {right?.Value.val}");
            //Console.WriteLine($"{dl} <? {dr}");
            var t = dl < dr ? left : right;
            r.Add(l[t].val);
            left = dl < dr? left-1 : left;
            right = dl >= dr ? right +1 : right;
        }
        
        return r;
    }
    
    private static double Distance(TreeNode t, double target )
    {
        if(t == null) { return double.MaxValue; }
        
        return Math.Abs(t.val - target);
    }
    
    
    private static int FillList(List<TreeNode> ll, TreeNode root, double target){
        if(root == null){ return -1; }
        
        var l = FillList(ll, root.left, target);
        var i = ll.Count();
        ll.Add(root);
        var r = FillList(ll, root.right, target);
        
        var d1 = Distance(l == -1 ? null : ll[l], target);
        var d2 = Distance(r == -1 ? null : ll[r], target);
        var d3 = Distance(root, target);
        
        if(d1 <= d2 && d1 <= d3){ return l; }
        else if (d2 <= d1 && d2 <= d3){ return r; }
        else { return i; }
    }
    
}