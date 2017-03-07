public class Solution {
    public int MaxKilledEnemies(char[,] grid) {
        if(grid == null){ return 0; }
        
        var m = grid.GetLength(0);
        var n = grid.GetLength(1);
        
        if(m == 0 || n == 0){ return 0; }
        
        var dp = new int[m,n];
        for(int i = 0; i < m; i++)
        {
            var e = 0;
            var b = false;
            for (int j = 0; j <= n; j++)
            {
                if(j == n || grid[i,j] == 'W')
                {
                    var jj = j-1;
                    while(b && jj >= 0 && grid[i,jj] != 'W') { if(grid[i,jj] != 'E') { dp[i,jj]  += e; } jj--; }
                    e = 0;
                    b = false;
                }
                else if(grid[i,j] == 'E'){
                    e++;
                }
                else{
                    b = true;
                }
            }
        }
        
        var max = 0;
        for(int j = 0; j < n; j++)
        {
            var e = 0;
            var b = false;
            for (int i = 0; i <= m; i++)
            {
                if(i ==  m || grid[i,j] == 'W')
                {
                    var ii = i-1;
                    while(b && ii >= 0 && grid[ii,j] != 'W') { if(grid[ii,j] != 'E') { dp[ii,j]  += e; max = Math.Max(dp[ii,j], max); } ii--; }
                    e = 0;
                    b = false;
                }
                else if(grid[i,j] == 'E'){
                    e++;
                }
                else{
                    b = true;
                }
            }
        }
        
        return max;
    }
}