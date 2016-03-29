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
            List<int> prs;
            uglies[c++] = poss.GetMin(out prs);
            
            foreach(var p in prs){
                var i = poss.Get(p);
                poss.Set(p,i+1, uglies[i+1] * p);
            }
            //Console.WriteLine(poss.ToString());
        }
        
        //Console.WriteLine(String.Join(",", uglies));
        return uglies.Last();
    }
    
    private class Possibilities{
        private Dictionary<int,int> dic  = new Dictionary<int,int>();
        private Dictionary<int,int> idx  = new Dictionary<int,int>();
        
        public Possibilities(int[] primes){

            foreach(var p in primes){
                dic.Add(p,p);
                idx.Add(p,0);
            }
        }
        
        public int Get(int p){
            return idx[p];
        }
        
        public void Set(int p, int i, int v){
            idx[p] = i;
            dic[p] = v;
        }
        public int GetMin(out List<int> minK){
            var min = int.MaxValue;
            minK = new List<int>();
            
            foreach(var k in dic.Keys){
                if(dic[k] <= min){
                    if(dic[k] < min){
                        min = dic[k];
                        minK.Clear();
                    }
                    minK.Add(k);
                }
            }
            
            return min;
        }
        
        public override string ToString(){
            var r = "";
            
            foreach(var k in dic.Keys){
                r += ","+dic[k];
            }
            
            return r;
        }
    }
}