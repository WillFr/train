public class Solution {
    public IList<IList<string>> SolveNQueens(int n) {
        var arr = new int[n,n];
        var arrQ = new int[n];
        var r = new List<IList<string>>();
        Solve(arr, arrQ,0,r);
        
        return r;

    }
    
    private static void Solve(int[,] arr, int[] q, int col, List<IList<string>> sols){
        //Console.WriteLine("Solve col "+col);
        //Print(q);
        if(col>= q.Length){ 
            Console.WriteLine(">>>>"+q);
            sols.Add(Convert(q));
            return;
        }
        
        for(int i = 0; i < q.Length; i ++){
            if(arr[col,i] != 0){ continue; }
            q[col] = i;
            PutQueen(arr,col,q[col]);
            Solve(arr, q, col +1, sols);
            RemQueen(arr,col,q[col]);
        }
    }
    private static List<string> Convert(int[] arr){
        var r = new List<string>();
        for(int i = 0; i < arr.Length; i++){
            var t = new List<char>();
            
            for(int j = 0; j < arr.Length; j++){
                t.Add(arr[i]==j ? 'Q' : '.' );
            }
            
            r.Add(string.Join("",t));
        }
        
        return r;
    }
    

    
    private static void PutQueen(int[,] arr, int i, int j){
        var n = arr.GetLength(0);
        var t = arr[i,j];
        for(int k = 0; k<n;k++){
            arr[i,k]++;
            arr[k,j]++;
            
            if(i-k >= 0 && j-k >=0) arr[i-k,j-k]++;
            if(i-k >= 0 && j+k <n) arr[i-k,j+k]++;
            if(i+k <n   && j-k >=0) arr[i+k,j-k]++;
            if(i+k <n && j+k <n) arr[i+k,j+k]++;
        }
       arr[i,j] = t+1;
    }
    private static void RemQueen(int[,] arr, int i, int j){
        var n = arr.GetLength(0);
        var t = arr[i,j];
        for(int k = 0; k<n;k++){
            arr[i,k]--;
            arr[k,j]--;
            
            if(i-k >= 0 && j-k >=0) arr[i-k,j-k]--;
            if(i-k >= 0 && j+k <n) arr[i-k,j+k]--;
            if(i+k <n   && j-k >=0) arr[i+k,j-k]--;
            if(i+k <n && j+k <n) arr[i+k,j+k]--;
        }
        arr[i,j] = t-1;
    }
    
    private static void Print(int[] arr){
        var n = arr.Length;
        for(int i = 0; i <n  ; i ++){
            for(int j = 0; j < n ; j++){
                
                Console.Write((arr[i]==j?"Q":"."));
            }
            
            Console.WriteLine();

        }
        
            Console.WriteLine("---------------------------");
    }
}