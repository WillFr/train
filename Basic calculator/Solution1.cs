public class Solution {
    public int Calculate(string s) {
        s = s.Replace(" ", string.Empty);
        
        var closingI = s.IndexOf(')');
        if(closingI == -1){
            return CalculateNoParenthesis(s);
        }
        
        var openingI = closingI-1;
        while(s[openingI] != '('){
            openingI--;
        }
        
        var a = s.Substring(0,openingI);
        var b = s.Substring(openingI+1, closingI-openingI-1);
        var c = s.Substring(closingI+1);
        
        var t = a+CalculateNoParenthesis(b)+c;
        return Calculate(t);
    }
    
    public int CalculateNoParenthesis(string s) {
        s = s.Replace("--", "+").Replace("+-", "-");

        var numbers = s.Split(new char[]{'+','-'}).Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse).ToArray();
        
        var sum = numbers[0];
        var start = 0;
        if(s[0] == '-' || s[0] == '+'){
            sum = s[0] == '-' ? -numbers[0] : numbers[0];
            start = 1;
        }
        
        var n = 1;
        for(int i = start; i < s.Length; i++){
            if(s[i] == '+'){
                sum += numbers[n++];
            }
            else if(s[i] == '-'){
                sum -= numbers[n++];
            }
        }
        
        return sum;
        
    }
}