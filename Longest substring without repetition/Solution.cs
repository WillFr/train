public class Solution {
    public int LengthOfLongestSubstring(string s) {
        /*
            The idea is to have a sliding window with an associated set of character:
            we will traverse the string from left to right andd for every new character : 
            if it belongs to the set, then we need to reduce the string : we will slide the left side of the window to the right until we remove the same character we are about to add (so that there is duplicates)
            if it does not belong to the set : we slide the right side of the window to the right and record the window size as a potential max;
        */
        
        if(string.IsNullOrEmpty(s)){ return 0; }
        
        var max = 0;
        var l = 0; // index of the left side of the window
        var r = -1; // index of the right side of the window
        var set = new HashSet<char>();
        
        foreach(var c in s)
        {
            if(set.Contains(c)){
                while(s[l] != c){ 
                    set.Remove(s[l]);
                    l++;
                }
                l++;
                r++;
            }
            else
            {
                set.Add(c);
                r++;
                max = (int)Math.Max(max, set.Count());
            }
            
            //Console.WriteLine(l+ " - " +r + " :: " + string.Join(",", set));
        }
        
        return max;
    }
}