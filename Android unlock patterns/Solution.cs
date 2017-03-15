public class Solution {
    public int NumberOfPatterns(int m, int n) {
        if(n == 0 || m > n){ return 0; } 
        if(n>9){ n = 9; }
        
        var arr = new bool[3,3];
        return (Browse(0,0, m, n, 0, arr) + Browse(0,1, m, n, 0, arr) ) * 4 + Browse(1,1, m, n, 0, arr);

    }
    
    private static int Browse(int x, int y, int m, int n, int c, bool[,] arr)
    {
        c++;
        var r = (c >= m && c <= n) ? 1 : 0;

        arr[x, y] = true;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (arr[i,j]
                    || i == x && j == y
                    || i == x && Math.Abs(j - y) == 2 && !arr[i, 1]
                    || j == y && Math.Abs(i - x) == 2 && !arr[1, j]
                    || Math.Abs(i - x) == 2 && Math.Abs(j - y) == 2 && !arr[1, 1])
                { continue; }

                r += Browse(i, j, m, n, c, arr);
            }
        }

        arr[x, y] = false;

        return r;
    }
}