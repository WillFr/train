public class Solution {
    public bool IsStrobogrammatic(string num) {
        var s2 = new HashSet<int>{'0','1','8' };
        var s1 = new int[]{'6','9'};
        
        for(int i = 0; i < (num.Length+1)/2; i++)
        {
            if(num[i] == '0' || num[i] == '1' || num[i] == '8' )
            {
                if(num[i] == num[num.Length-1-i])
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            else if(num[i] == '6')
            {
                if(num[num.Length-1-i] == '9')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            else if(num[i] == '9')
            {
                if(num[num.Length-1-i] == '6')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        return true;
    }
}