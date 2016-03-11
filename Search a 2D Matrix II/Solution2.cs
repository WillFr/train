public class Solution {
    public bool SearchMatrix(int[,] matrix, int target){
        if(matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0 ) { return false; }
        var b = matrix.GetLength(0)-1;
        var r = matrix.GetLength(1)-1;
        
        return SearchMatrix(matrix,target, 0, 0, b, r);
    }
    
    public bool SearchMatrix(int[,] matrix, int target, int l, int t, int b, int r) {
        
        if( t > b || l>r){ return false;}
        if(r==l && b==t){ return target == matrix[b,l]; }
        if(matrix[t, l]>target || matrix[b, r]<target){ return false;}
        
        var tuple = GetLineColInSquareMatrix(matrix, target, t,l, (int)Math.Min(r-l+1, b-t+1));

        if(matrix[tuple.Item1, tuple.Item2] == target){ return true; }
        
        var bl = SearchMatrix(matrix, target, l, tuple.Item1+1, b, tuple.Item2) ;
        if(bl){ return true; }
        var tr = SearchMatrix(matrix, target, tuple.Item2+1, t, tuple.Item1, r) ;
        if(tr){ return true;}

        
        return false;
    }
    
    private static Tuple<int,int> GetLineColInSquareMatrix(int[,] matrix, int target, int ts,int ls, int s){
        var l = 0;
        var r = s;
        
        while(r-l > 1){
            var p = Mid(l,r);
            if(matrix[ts+p,ls+p] > target){ r = p; }
            else {l = p;}
        }
            
        return new Tuple<int,int>(ts+l,ls+l);
    }
    
    private static int Mid(int l, int r){
        return l + (r-l)/2;
    }
}