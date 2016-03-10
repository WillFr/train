public class Solution {
    public IList<IList<string>> SolveNQueens(int n) {
        
        var r = new List<IList<string>>();
        
        var list = Solve(new bool[n,n],new bool[n,n],n);
        
        foreach(var arrr in list){
            r.Add(Convert(arrr));
        }
        
        return r;

    }
    
    private static List<string> Convert(bool[,] arr){
        var r = new List<string>();
        for(int i = 0; i < arr.GetLength(0); i++){
            var t = new List<char>();
            
            for(int j = 0; j < arr.GetLength(0); j++){
                t.Add(arr[i,j] ? 'Q' : '.' );
            }
            
            r.Add(string.Join(",",t));
        }
        
        return r;
    }
    
    private static List<bool[,]> Solve(bool[,] ori,bool[,] oriQ, int target){
        if(target == 0){ return new List<bool[,]>(){oriQ}; }
        
        var r = new List<bool[,]>();
        var n = ori.GetLength(0);
        
        for(int i = 0; i <n  ; i ++){
            for(int j = 0; j < n ; j++){
                if(ori[i,j]){ continue; }
                
                var arr = Clone(ori);
                var arrQ = Clone(oriQ);
                
                PutQueen(arr, i, j); 
                arrQ[i,j] = true;
                
                //Print(arrQ);
                r.AddRange(Solve(arr,arrQ,target-1));
            }
        }
        
        return r;
    }
    
    private static void PutQueen(bool[,] arr, int i, int j){
        var n = arr.GetLength(0);
        for(int k = 0; k<n;k++){
            arr[i,k] = true;
            arr[k,j] = true;
            
            if(i-k >= 0 && j-k >=0) arr[i-k,j-k] = true;
            if(i-k >= 0 && j+k <n) arr[i-k,j+k] = true;
            if(i+k <n   && j-k >=0) arr[i+k,j-k] = true;
            if(i+k <n && j+k <n) arr[i+k,j+k] = true;
        }
    }
    
    private static bool[,] Clone(bool[,] f){
        var g = new bool[f.GetLength(0), f.GetLength(1)];
        Array.Copy(f, 0, g, 0, f.Length); 
        return g;
    }
    
    private static void Print(bool[,] arr){
        var n = arr.GetLength(0);
        for(int i = 0; i <n  ; i ++){
            for(int j = 0; j < n ; j++){
                Console.Write((arr[i,j]?"Q":".")+",");
            }
            
            Console.WriteLine();
        }
    }
}