public class Solution {
    public int CountDigitOne(int n) {
        if(n <= 0) { return 0;}
        
        var r = 0;
        var div = 1;
        
        for(int i = 0; div <= n && i<= 9; i++){
            var num = n / div % 10;
            var onesChunkLengthInThisCol = div;
            
            if(num > 1){ r+= onesChunkLengthInThisCol; }
            else if(num == 1){ r += (i != 0 ? (n%onesChunkLengthInThisCol)+1 : 1); }
            
            var left = i == 9 ? 0 : n/(div * 10);
            r += left * onesChunkLengthInThisCol;
            
            div *=10;
        }
        
        return r;
    }
}