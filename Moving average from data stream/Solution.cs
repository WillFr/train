public class MovingAverage {
    private int size = 0;
    private double sum = 0;
    private Queue<int> q = new Queue<int>();
    
    /** Initialize your data structure here. */
    public MovingAverage(int size) {
        this.size = size;
    }
    
    public double Next(int val) {
        if(q.Count() == size)
        {
            var t = q.Dequeue();
            sum -= t;
        }
        
        sum += val;
        q.Enqueue(val);
        
        return sum / q.Count();
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */