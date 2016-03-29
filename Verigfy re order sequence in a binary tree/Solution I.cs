public class Solution {
    public bool VerifyPreorder(int[] preorder) {
        if(preorder == null || preorder.Length <= 2){ return true; }
        
        var s = new Stack<int>();
        s.Push(preorder[0]);
        var min = int.MinValue;
        for(int i = 1; i < preorder.Length; i++){
            var curr = preorder[i];
            
            if(curr<=min){ return false;}
            
            var parent = s.Peek();
            
            if(curr > parent){
                while(curr > parent){ 
                    min = s.Pop();
                    parent = s.Any() ? s.Peek() : int.MaxValue;
                }
            }
            
            s.Push(curr);
        }
        
        return true;
        
    }
}