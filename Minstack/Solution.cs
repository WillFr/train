public class MinStack {
    
    private Stack<int> stack = new Stack<int>();
    private Stack<int> minStack = new Stack<int>();
    
    /** initialize your data structure here. */
    public MinStack() {
        
    }
    
    public void Push(int x) {
        this.stack.Push(x);
        if(!this.minStack.Any() || x<= this.minStack.Peek())
        {
            this.minStack.Push(x);
        }
    }
    
    public void Pop() {
        var x = this.stack.Pop();
        if(x == this.minStack.Peek())
        {
            this.minStack.Pop();
        }
    }
    
    public int Top() {
        return this.stack.Peek();
    }
    
    public int GetMin() {
        return this.minStack.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */