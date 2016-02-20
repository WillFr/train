public class Solution {
    public int NthUglyNumber(int k) {
        if(k<1){ return -1;}
        
        var r = new int[k];
        r[0] = 1;
        var p = 0;
        var p2=0;
        var p3=0;
        var p5=0;
        
        for(int i=1;i<k;i++){
            var v2 = p2<=p ? r[p2] * 2 : int.MaxValue;
            var v3 = p3<=p ? r[p3] * 3 : int.MaxValue;
            var v5 = p5<=p ? r[p5] * 5 : int.MaxValue;
            
            var t = Math.Min(v2,Math.Min(v3,v5));
            
            if(t == v2){ p2 ++; }
            if(t == v3){ p3 ++; }
            if(t == v5){ p5 ++; }
            
            r[++p] = t;
        }
        
        //Console.WriteLine(String.Join(",", r));
        
        return r[k-1];
        
    }
}