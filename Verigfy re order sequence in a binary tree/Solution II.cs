public class Solution {
    public bool VerifyPreorder(int[] preorder) {
        if(preorder == null || preorder.Length <= 2){ return true; }
        
        var s = new MyStack(preorder);
        s.Push(preorder[0]);
        
        var min = int.MinValue;
        for(int i = 1; i < preorder.Length; i++){
            var curr = preorder[i];
            
            if(curr<=min){ return false; }
            
            var parent = s.Peek();
            while(curr > parent){ 
                min = s.Pop();
                parent = s.Any() ? s.Peek() : int.MaxValue;
            }
            
            s.Push(curr);
        }
        
        return true;
        
    }
    
    private class MyStack{
        private int[] arr;
        private int p = -1;
        
        public MyStack(int[] arr){ this.arr = arr; }
        
        public void Push(int i){
            p++;
            arr[p] = i;
        }
        
        public int Pop(){
            var r = arr[p];
            p--;
            return r;
        }
        
        public int Peek(){
            return arr[p];
        }
        
        public bool Any(){
            return p != -1;
        }
    }
}