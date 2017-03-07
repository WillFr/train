public class NumMatrix {
    List<int[,]> floors = new List<int[,]>();
    public NumMatrix(int[,] matrix) {
        floors.Add(matrix);
        if(matrix.GetLength(0) == 0 && matrix.GetLength(1) == 0){ return;}
        
        var L = 0;
        var H = 0;
        while(! (L == 1 && H == 1))
        {
            var m = floors.Last();
            L = m.GetLength(0)/2 + (m.GetLength(0)%2 != 0 ? 1:0);
            H = m.GetLength(1)/2 + (m.GetLength(1)%2 != 0 ? 1:0);
            
            var arr = new int[L,H];
            for(int i = 0; i < L; i++){
                for(int j = 0; j < H; j++)
                {
                    var sum =   m[i*2,j*2]
                                + (i*2 +1 < m.GetLength(0) ? m[i*2+1,j*2] : 0) 
                                + (j*2 +1 < m.GetLength(1) ? m[i*2,j*2+1] : 0) 
                                + (i*2 +1 < m.GetLength(0) && j*2 +1 < m.GetLength(1) ? m[i*2+1,j*2+1] : 0);
                    arr[i,j] = sum;
                }
            }
            floors.Add(arr);
        }
        
        //PrintFloors();
    }
    
    private void Print(int[,] arr)
    {
        for(int i = 0; i < arr.GetLength(0); i++)
        {
            for( int j = 0 ; j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i,j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("--");
    }
    
    private void PrintFloors()
    {
        foreach(var f in floors)
        {
            Print(f);
        }
        Console.WriteLine("_______");
    }
    
    public void Update(int row, int col, int val) {
        var diff = val - this.floors[0][row,col];
        for(int i = 0; i < floors.Count(); i++)
        {
            this.floors[i][row,col] += diff;
            row = row/2;
            col = col/2;
        }
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2, int f = -1, int i = 0, int j = 0) {
        if(f == -1){ f = floors.Count()-1; }

        var c = Coverage(f,i,j);
        //Console.WriteLine($"C {f},{i},{j} = " + string.Join(",", c));
        if(c[0]>=row1 && c[1] >= col1 && c[2] <= row2 && c[3] <= col2){
            //Console.WriteLine($"Fully covered {f},{i},{j}");
            return floors[f][i,j];
        }
        else if (c[0] > row2 || c[1] > col2 || c[2] < row1 || c[3] < col1)
        {
            //Console.WriteLine($"No coverage {f},{i},{j}");
            return 0;
        }
        else{
            var s = SumRegion(row1,col1,row2,col2, f-1, i*2,j*2)
                +   SumRegion(row1,col1,row2,col2, f-1, i*2+1,j*2)
                +   SumRegion(row1,col1,row2,col2, f-1, i*2,j*2+1)
                +   SumRegion(row1,col1,row2,col2, f-1, i*2+1,j*2+1);
            
            return s;
        }
    }

    
    private int[] Coverage(int f, int i, int j)
    {
        var unit = (int)Math.Pow(2,f);
        var ctl = new int[]{
            i*unit ,
            j*unit,
            (i+1)*unit-1,
            (j+1)*unit-1};
        
        return ctl;
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * obj.Update(row,col,val);
 * int param_2 = obj.SumRegion(row1,col1,row2,col2);
 */