public class Solution {
    public int NthSuperUglyNumber(int n, int[] primes) {
        if(n == 1){ return 1; }
        if(primes == null || !primes.Any()){ return 1;}
        if(primes.Length == 1){ return (int)Math.Pow(primes[0],(n-1)); }
        
        
        var uglies = new int[n];
        uglies[0] = 1;
        var c = 1;
        
        var minHeap = new Heap(primes);
        
        while(c < n){
            var m = minHeap.GetMin();
            var prime = m.GetPrime(uglies);
            var index = m.UglyIndex;
            var possibility = m.Value;
            
            if(possibility != uglies[c-1]){
                uglies[c++] = possibility;
            }
            
            minHeap.ReplaceMin(uglies[index+1] * prime, index+1);
        }
        
        return uglies.Last();
    }

    private class Heap{
         private Possibility[] arr;
         
         public Heap(int[] primes){
             arr = new Possibility[primes.Length+1];
             for(int i = 1; i <arr.Length ; i ++){
                 arr[i] = new Possibility(primes[i-1],0);
             }
         }
         
         public Possibility GetMin(){ 
             return arr[1];
         }
         
         public void ReplaceMin(int value, int idx){
             arr[1].Value = value; 
             arr[1].UglyIndex = idx; 
             PercolateDown(1);
         }
         
         private void PercolateDown(int i){
             var m = arr[i];
             var mi = i;
             
             if(i*2 < arr.Length && arr[i*2].Value < m.Value){
                 m = arr[i*2];
                 mi = i*2;
             }
             
             if(i*2+1 < arr.Length && arr[i*2+1].Value < m.Value){
                 m = arr[i*2+1];
                 mi = i*2+1;
             }
             
             if(mi != i){
                var t = arr[i];
                 arr[i] = arr[mi];
                 arr[mi] = t;
                PercolateDown(mi);
             }
         }
    }
    
    private class Possibility{
        public int Value {get; set;}
        public int UglyIndex {get; set;}
        public int GetPrime(int[] uglies){ return Value/uglies[UglyIndex]; }
        
        public Possibility(int val, int index){
            this.Value = val; 
            this.UglyIndex = index;
        }
    }
}