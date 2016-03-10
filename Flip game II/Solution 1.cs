public class Solution {
    public bool CanWin(string s) {
        return CanWin(new StringBuilder(s));
    }
    
    public bool CanWin(StringBuilder sb){
        for(int i = 0 ; i< sb.Length-1 ; i++){
            if(sb[i] == '+' && sb[i+1]=='+'){
                sb[i] = '-';
                sb[i+1] = '-';
                
                var t = CanWin(sb);
                
                sb[i] = '+';
                sb[i+1] = '+';
                
                if(!t){ return true; }
            }
        }
        
        return false;
    }
}