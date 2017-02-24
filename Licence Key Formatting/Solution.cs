public class Solution {
    public string LicenseKeyFormatting(string S, int K) {
        if(K<=0){ return null; }
        
        var dashCount = 0;
        for(int i = 0; i < S.Length; i++)
        {
            if(S[i] == '-'){ dashCount++; } 
        }
        var sLength = S.Length - dashCount;
        
        if(sLength == 0) { return string.Empty; }
        
        var mod = sLength%K;
        var nsLength = sLength + sLength/K - (( mod == 0)?1:0);
        var firstGroupLength = ((mod == 0)?K:sLength%K);
        
        var sb = new StringBuilder(nsLength);
        int j = 0;
        for(int k = 0; k < firstGroupLength; k++)
        {
            while(j < S.Length && S[j] == '-'){ j++;  }
            if(j == S.Length){ return null; }
            
            sb.Append(ToUpper(S[j++]));
        }
        
        if(j < S.Length)
        {
            sb.Append('-');
        }
        
        var gc = 0;
        while(j < S.Length)
        {
            while(j < S.Length && S[j] == '-'){ j++;  }
            if(j == S.Length){ Console.WriteLine("ss"); return sb.ToString(); }
            
            if(gc == K){ sb.Append('-'); gc = 1;}
            else{ gc++; }
            
            sb.Append(ToUpper(S[j++]));
            //Console.WriteLine($"{j} < {S.Length}");
        }
        
        return sb.ToString();
        
    }
    
    private static char ToUpper(char c){
        if(!(c>='a' && c<='z')){ return c; }
        return (char)(c + 'A'-'a');
    }
}