public class Solution {
    public bool CanWin(string s) {
        return CanWin(new StringBuilder(s), new Dictionary<string, bool>());
    }
    
    public bool CanWin(StringBuilder sb, Dictionary<string, bool> dic){
        var s = sb.ToString();
        if(dic.ContainsKey(s)){ return dic[s]; }
        
        for(int i = 0 ; i< sb.Length-1 ; i++){
            if(sb[i] == '+' && sb[i+1]=='+'){
                sb[i] = '-';
                sb[i+1] = '-';
                
                var t = CanWin(sb,dic);
                
                sb[i] = '+';
                sb[i+1] = '+';
                
                if(!t){  return true; }
            }
        }
        
        dic.Add(sb.ToString(), false);
        return false;
    }
}