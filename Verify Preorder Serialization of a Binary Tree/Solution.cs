public class Solution {
    public bool IsValidSerialization(string preorder) {
        if(string.IsNullOrEmpty(preorder)){ return false;}
        
        var arr = preorder.Split(',');
        
        var lastNull = arr.Length-1;
        if(arr[lastNull] != "#"){ return false; }
        
        var lastNumber = arr.Length-1;
        while(lastNumber >= 0 && arr[lastNumber] == "#"){lastNumber-=1;}
        
        if(lastNumber < 0 && lastNull != 0){ return false;}
        
        while(lastNull>0 && lastNumber>=0){
            if(lastNull - lastNumber < 2) { return false;}
            //Console.WriteLine(lastNumber + "  ::  " + lastNull);
            do{lastNumber-=1;}while(lastNumber>=0 && arr[lastNumber] == "#");
            lastNull -= 2;
            
        }
        
        //Console.WriteLine(lastNumber + "  ::  " + lastNull);
        
        return lastNull == 0;
    }
    
}