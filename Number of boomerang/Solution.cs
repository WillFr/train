public class Solution {
    public int NumberOfBoomerangs(int[,] points) {
        if(points == null || points.GetLength(0) == 0){ return 0; }
        
        var r = 0;
        
        for(int i = 0; i < points.GetLength(0) ; i++){
            var d = new Dictionary<int,int>();
            
            for(int j = 0; j < points.GetLength(0); j++){
                if(i == j){ continue; }
                var x1 = points[i,0] - points[j,0];
                var y1 = points[i,1] - points[j,1];
                var d1 = x1*x1 + y1*y1;
                
                if(d.ContainsKey(d1)){
                    d[d1]++;
                }
                else{
                    d.Add(d1,1);
                }
            }
            
            foreach(var k in d.Keys){
                // Console.WriteLine(k + " : " + d[k]);
                r += d[k] * (d[k]-1);
            }
        }
        
        return r;
    }
}