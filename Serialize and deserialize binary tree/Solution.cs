/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if(root == null) {return string.Empty; }
        
        var sb = new StringBuilder();
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while(q.Any())
        {
            var current = q.Dequeue();
            sb.Append(current == null ? string.Empty : current.val.ToString()); 
            sb.Append(";"); 
            
            if(current != null)
            {
                q.Enqueue(current.left);
                q.Enqueue(current.right);
            }
        }
        
        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if(string.IsNullOrEmpty(data)){ return null; }
        var arr = data.Split(';');
        var root = new TreeNode(int.Parse(arr[0]));
        
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var i = 1;
        while(q.Any() && i < arr.Length)
        {
            var current = q.Dequeue();
            if(!string.IsNullOrEmpty(arr[i]))
            {
                current.left = new TreeNode(int.Parse(arr[i]));
                q.Enqueue(current.left);
            }
            i++;
            if(!string.IsNullOrEmpty(arr[i]))
            {
                current.right = new TreeNode(int.Parse(arr[i]));
                q.Enqueue(current.right);
            }
            i++;
        }
        
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));