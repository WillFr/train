public class Solution {
    public int Calculate(string s) {
        var n = new Stack<int>();
        var o = new Stack<bool>();
        
        var top = 0;
        var temp = 0;
        var isPos = true;
        
        for(int i = 0; i < s.Length;  i++){
             if(s[i] ==' '){continue;}
            if(s[i] =='('){
                n.Push(top);
                top = 0;
                o.Push(isPos);
                temp = 0;
                isPos = true;
            }
            else if(s[i] ==')'){
                top += temp * (isPos?1:-1);
                var t = n.Pop();
                var pos = o.Pop();
                top = t+top*(pos?1:-1);
                temp = 0;
            }
            else if(s[i] == '+'){
                top += temp * (isPos?1:-1);
                temp = 0;
                isPos = true;
            }
            else if(s[i] == '-'){
                top += temp * (isPos?1:-1);
                temp = 0;
                isPos = false;
            }else{
               temp = temp *10 + s[i]-'0'; 
            }
            
        }
        
        top += temp * (isPos?1:-1);
        
        return top;
        
    }
}