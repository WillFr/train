public class Solution {
    public IList<int> NumIslands2(int m, int n, int[,] p) {
        var ret = new List<int>();
        var parents = new List<int>();
        if(m == 0 || n == 0 || p.GetLength(0) == 0){ return ret; }
        
        var g = new int[m,n];
        // first element is unused
        parents.Add(-1);
        
        parents.Add(-1);
        g[p[0,0],p[0,1]] = parents.Count()-1;
        ret.Add(1);
        
        for(int i = 1; i < p.GetLength(0); i++)
        {
            var l = p[i,0] > 0 ? g[p[i,0]-1,p[i,1]] : 0;
            var r = p[i,0] < m-1 ? g[p[i,0]+1,p[i,1]] : 0;
            var t = p[i,1] > 0 ? g[p[i,0],p[i,1]-1] : 0;
            var b = p[i,1] < n-1 ? g[p[i,0],p[i,1]+1] : 0;
            
            var neighbors = new HashSet<int>((new int[]{l,t,r,b}).Where(x => x != 0));
            
            if(!neighbors.Any())
            {
                parents.Add(-1);
                g[p[i,0],p[i,1]] = parents.Count()-1;
                ret.Add(ret.Last() + 1);
                continue;
            }
            
            if(neighbors.Count() == 1)
            {
                g[p[i,0],p[i,1]] = neighbors.First();
                ret.Add(ret.Last());
                continue;
            }
            
            var roots = new HashSet<int>(neighbors.Select(x => Find(x, parents)));
            ret.Add(ret.Last() + 1 - roots.Count());
            g[p[i,0],p[i,1]] = roots.First();

            Union(parents, roots.ToArray());
        }
        
        return ret;
    }
    
    private static void Print(int[,] g)
    {
        var m = g.GetLength(0);
        var n = g.GetLength(1);
        
        for(int ii = 0; ii < m; ii++)
            {
                 Console.Write(ii+": ");
                for(int jj = 0; jj < n ; jj++)
                {
                    Console.Write(g[ii,jj]+ " ");
                }
                
                Console.WriteLine();
            }
    }
    
    private static int Find(int i, List<int> parents)
    {
        int a = 0;
        return Find(i, parents, i, out a);
    }
    
    private static int Find(int i, List<int> parents, int firstIndex, out int count)
    {
        count = 1;
        while(parents[i] != -1)
        {
            i = parents[i];
            count ++;
        }
        
        parents[firstIndex] = count == 1 ? -1 : i;
        return i;
    }
    
    private static void Union(List<int> parents, params int[] vals )
    {
        for(int i = 1 ; i < vals.Length; i++)
        {
            UnionB(parents, vals[i-1], vals[i]);
        }
    }
    
    private static void UnionB(List<int> parents, int a, int b)
    {
        int ca = 0;
        var ra = Find(a, parents, a, out ca);
        
        int cb = 0;
        var rb = Find(b, parents, b, out cb);
        
        if(cb > ca)
        {
            parents[ra] = rb;
        }
        else
        {
            parents[rb] = ra;
        }
    }
}