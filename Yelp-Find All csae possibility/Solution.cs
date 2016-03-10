using System;
using System.Text;
// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{
    static void Main(string[] args)
    {
        PrintAllPossibility("aBc");
    }
    
    private static void PrintAllPossibility(string s){
        var stl = s.ToLower();
        Console.WriteLine(stl);
        PrintAllPossibility(new StringBuilder(stl),0);
    }
    
    // ab
    
    // Ab
    // AB
    // Ab
    // ab
    private static void PrintAllPossibility(StringBuilder s, int i){
        if(s.Length == i) { return; }
        
        //p2: do nothing
        PrintAllPossibility(s, i+1);
        
        //p1: turn UpperCase 
        s[i] = (char)(s[i] + 'A'-'a');
        Console.WriteLine(s.ToString());
        
        PrintAllPossibility(s, i+1);
        
        s[i] = (char)(s[i] - 'A'+'a');        
    }
}