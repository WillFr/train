public class Solution {
    public bool ValidUtf8(int[] data) {
        if(data == null || data.Length == 0)
        {
            return true;
        }
        

        for(int i = 0; i < data.Length ; i++)
        {
            int mask = 1<<7;
            if((~data[i] & mask) != 0)
            {
                // one byte char
                continue;
            }
            
            var byteCount = 0;
            while((data[i] & mask) != 0){
                mask >>= 1;
                byteCount++;
            }
            
            if(byteCount > 4 || byteCount == 1){ return false; }
            
            for(int k = i+1; k < i+byteCount; k++)
            {
                if(k >= data.Length) { return false; } 
                
                if((data[k] & (1 << 7)) != 0 && (~data[k] & (1<<6)) != 0)
                {
                    continue;
                }
                
                return false;
            }
            i += byteCount-1;
        }
        
        return true;
    }
}