public class Solution {
    public string DecodeString(string str, int s = 0, int e = -1) {
        if(e == -1){ e = str.Length-1; }
        if(string.IsNullOrEmpty(str) || e < s){ return string.Empty; }
        
        int i = s;
        var sb = new StringBuilder();
        while(i <= e)
        {
            if(str[i]>= '0' && str[i] <= '9'){
                var c = 0;
                while(str[i] != '[')
                {
                    c = c*10 + ((int)(str[i++]-'0'));
                }
                var ss = i +1;
                var ee = ss+1;
                var count = 0;
                while(ee < str.Length && !(count == 0 && str[ee] == ']' )){
                    if(str[ee] == ']'){
                        count--;
                    }
                    else if(str[ee] == '[')
                    {
                        count++;
                    }
                    
                    ee++;
                }
                i = ee+1;
                ee--;
                var resolved = DecodeString(str, ss,ee);
                for(int k = 0; k < c; k++)
                {
                    sb.Append(resolved);
                }
            }
            else
            {
                sb.Append(str[i++]);
            }
        }
        
        return sb.ToString();
    }
}