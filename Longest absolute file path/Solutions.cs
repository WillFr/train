public class Solution {
    public int LengthLongestPath(string input) {
        if(string.IsNullOrEmpty(input)){
            return 0;
        }
        
        var s = new Stack<int>();
        var max = 0;
        
        var arr = input.Split('\n');
        var level = -1;
        var length = 0;
        foreach(var el in arr){
            var tLevel = el.LastIndexOf('\t') + 1;
            while(level >= tLevel){
                var poped = s.Pop();
                length -= poped + 1;
                level--;
            }
            
            var elTrimmed = el.TrimStart('\t');
            
            level ++;
            length += elTrimmed.Length + 1;
            s.Push(elTrimmed.Length);
            //Console.WriteLine(length + " :: " + string.Join("/", s));
            if(length > max && elTrimmed.IndexOf('.') != -1){
                max = length;
                //Console.WriteLine("MAX" + string.Join("/", s));
            }
        }
        
        return max == 0 ? 0 : max-1;
    }
}