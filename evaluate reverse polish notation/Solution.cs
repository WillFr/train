public class Solution {
    public int EvalRPN(string[] tokens, int start = -1) {
        if(start == -1){ start = tokens.Length-1; }
        if(start == -1){ return 0; }
        
        int p = 0;
        return Helper(tokens, start, out p);
        
    }
    
    private int Helper(string[]tokens, int start, out int outp){
        var operators = "+-/*";
        
        if(!operators.Contains(tokens[start]))
        {
            outp=start-1;
            return int.Parse(tokens[start]);
        }
        else{
            var ppStart  = 0;
            var p = Helper(tokens, start - 1, out ppStart);
            //Console.WriteLine(ppStart);
            var pp = Helper(tokens, ppStart, out ppStart);
            
            //Console.WriteLine(p + " | " + pp);
            outp = ppStart;
            if(tokens[start][0] == '+'){
                return p + pp;
            }
            
            if(tokens[start][0] == '*'){
                return p * pp;
            }
            
            if(tokens[start][0] == '/'){
                return pp / p;
            }
            
            if(tokens[start][0] == '-'){
                return pp-p;
            }
            
            return p;
        }
    }
}