public class Solution {
    public int MaxCount(int m, int n, int[,] ops) {
        if(m == 0 || n == 0 || ops == null){ return 0; }
        
        var minM = m;
        var minN = n;
        
        for(int i = 0; i < ops.GetLength(0); i++)
        {
            if(ops[i,0] == 0 || ops[i,1] == 0){
                continue;
            }
            
            minM = Math.Min(ops[i,0], minM);
            minN = Math.Min(ops[i,1], minN);
        }
        
        return minM * minN;
    }
}