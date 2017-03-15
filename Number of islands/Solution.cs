public class Solution {
    const char MARKED = 'M';
    
    public int NumIslands(char[,] grid) {
        if(grid == null || grid.GetLength(0) == 0 || grid.GetLength(1) == 0)
        {
            return 0;
        }
        
        var m = grid.GetLength(0); 
        var n = grid.GetLength(1);
        var c = 0;
        
        for(int i = 0 ; i < m; i ++ )
        {
            for(int j = 0 ; j < n; j++)
            {
                if(grid[i,j] == '1')
                {
                    Visit(grid,i,j);
                    c++;
                }
            }
        }
        
        return c;
    }
    
    private static void Visit(char[,] grid, int ii, int jj)
    {
        var qi = new Queue<int>();
        var qj = new Queue<int>();
        
        qi.Enqueue(ii);
        qj.Enqueue(jj);
        
        while(qi.Any())
        {
            var i = qi.Dequeue();
            var j = qj.Dequeue();
            if( grid[i,j] == MARKED){ continue; }
            
            grid[i,j] = MARKED;
            
            if(i>0 && grid[i-1,j] == '1'){ qi.Enqueue(i-1);qj.Enqueue(j); }
            if(j>0 && grid[i,j-1] == '1'){ qi.Enqueue(i);qj.Enqueue(j-1); }
            if(i<grid.GetLength(0)-1 && grid[i+1,j] == '1'){ qi.Enqueue(i+1);qj.Enqueue(j); }
            if(j<grid.GetLength(1)-1 && grid[i,j+1] == '1'){ qi.Enqueue(i);qj.Enqueue(j+1); }
        }
    }
}
