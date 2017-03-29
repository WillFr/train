public class Solution {
    public double MyPow(double x, int n) {
        if(x == 0){ return 0; }
        if(x == 1){ return 1; }
        if(x == -1){ return n %2 == 0 ? 1 : -1; }
        if(n == 0){ return 1; }
        if(n == 1){ return x; }
        if(n == int.MinValue){ return 0; }

        if(n < 0){ return MyPow(1/x, -n); }
        
        double r = 1;
        var mask = 1;
        var t = x;
        for(int i = 1; i < 33; i++)
        {
            if((mask & n) != 0)
            {
                r *= t;
            }
            
            t = t*t;
            mask <<= 1;
        }
        
        return r;
    }
}