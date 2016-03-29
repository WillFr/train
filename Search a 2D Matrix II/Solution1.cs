public class Solution {
    public bool SearchMatrix(int[,] matrix, int target) {
        if(matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0){ return false;}
        
        
        //check lines
        var lines = new List<int>();
        var r= matrix.GetLength(1)-1;
        for(int i = 0; i < matrix.GetLength(0); i++){
            if(matrix[i,0] == target || matrix[i,r] == target){return true;}
            if(matrix[i,0] < target && matrix[i,r] > target){lines.Add(i);}
        }
        
        if(!lines.Any()){ return false; }
        
        //check lines
        var cols = new List<int>();
        var b= matrix.GetLength(0)-1;
        for(int i = 0; i < matrix.GetLength(1); i++){
            if(matrix[0,i] == target || matrix[b,i] == target){return true;}
            if(matrix[0,i] < target && matrix[b,i] > target){cols.Add(i);}
        }
        
        if(!cols.Any()){ return false; }
        
        /*Console.WriteLine(String.Join(",", lines));
        Console.WriteLine(String.Join(",", cols));*/
        return SearchMatrix(matrix, target, lines, cols);
    }
    
    public bool SearchMatrix(int[,] matrix, int target, List<int> lines, List<int> cols){
        foreach(var li in lines){
            var ci = SearchLine(matrix,li,target, cols);
            if(matrix[li,ci] == target){ return true; }
        }
        
        return false;
    }
    /*
    Search lines then columns 
    */
    
    /*private static bool SearchLineCol(int[,] matrix, int target){
        var c = SearchLine(matrix,0,target);
        var l = SearchCol(matrix,c,target);
        
        return matrix[l,c] == target;
    }
    
    private static bool SearchColLine(int[,] matrix, int target){
        var l = SearchCol(matrix,0,target);
        var c = SearchLine(matrix,l,target);
        
        return matrix[l,c] == target;
    }*/
    
    private static int SearchLine(int[,] matrix, int lineI, int target, List<int> cols = null){
        var dl = 0;
        var dr = cols.Count();
        var l = cols.First();
        var r = cols.Last() +1;
        
        while(dr-dl > 1){
            var dp = Mid(dl,dr);
            var p = cols[dp];
            if(matrix[lineI,p]>target){ dr= dp; }
            else{ dl = dp; }
        }
        
        return cols[dl];
    }
    
    /*private static int SearchCol(int[,] matrix, int colI, int target){
        var l = 0;
        var r = matrix.GetLength(0);

        while(r-l > 1){
            var p = Mid(l,r);
            if(matrix[p,colI]>target){ r= p;}
            else{ l = p; }
        }
        
        return l;
    }*/
    
    private static int Mid(int l, int r){
        return l + (r-l)/2;
    }
}