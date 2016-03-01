public class Solution {
    public int NthSuperUglyNumber(int n, int[] primes) {
        if(n == 1){ return 1; }
        if(primes == null || !primes.Any()){ return 1;}
        if(primes.Length == 1){ return (int)Math.Pow(primes[0],(n-1)); }
        
        
        var uglies = new int[n];
        uglies[0] = 1;
        var c = 1;
        
        var poss  = new Possibilities(primes);
        
        while(c < n){
            var m = poss.GetMin();
            var prime = m.GetPrime(uglies);
            var index = m.UglyIndex;
            var possibility = m.Value;
            
            if(possibility != uglies[c-1]){
                uglies[c++] = possibility;
            }
            
            poss.Set(prime,index+1, uglies[index+1] * prime);
        }
        
        return uglies.Last();
    }
    
    private class Possibilities{
        private Dictionary<int,Possibility> dic  = new Dictionary<int,Possibility>();
        private Heap minHeap;
        public Possibilities(int[] primes){
            foreach(var p in primes){
                var poss = new Possibility(p,0);
                dic.Add(p,poss);
            }
            
            this.minHeap = new Heap(dic.Values.ToArray());
        }
        
        public void Set(int p, int i, int v){
            dic[p] = new Possibility(v,i);
            this.minHeap.ReplaceMin(dic[p]);
        }
        
        public Possibility GetMin(){
            var min = minHeap.GetMin();
            return min;
        }
        
        public override string ToString(){
            var r = "";
            
            foreach(var k in dic.Keys){
                r += ","+dic[k].Value;
            }
            
            return r;
        }
    }
    
    private class Heap{
         private Possibility[] arr;
         
         public Heap(Possibility[] poss){
             arr = new Possibility[poss.Length+1];
             for(int i = 1; i <arr.Length ; i ++){
                 arr[i] = poss[i-1];
             }
         }
         
         public Possibility GetMin(){ 
             return arr[1];
         }
         
         public void ReplaceMin(Possibility rep){
             arr[1] = rep;
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
                Switch(arr, i, mi);
                PercolateDown(mi);
             }
         }
         
         private static void Switch(Possibility[] arr, int i , int j){
             var t = arr[i];
             arr[i] = arr[j];
             arr[j] = t;
         }
    }
    
    private class Possibility{
        public int Value {get; private set;}
        public int UglyIndex {get; private set;}
        public int GetPrime(int[] uglies){ return Value/uglies[UglyIndex]; }
        
        public Possibility(int val, int index){
            this.Value = val; 
            this.UglyIndex = index;
        }
    }
}