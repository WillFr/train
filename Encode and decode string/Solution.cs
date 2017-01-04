public class Codec {

    // Encodes a list of strings to a single string.
    public string encode(IList<string> strs) {
        return string.Join(string.Empty, strs.Select(x => x.Length+"."+x));
    }

    // Decodes a single string to a list of strings.
    public IList<string> decode(string s) {
        Console.WriteLine(s);
        var ret = new List<string>();
        
        if(string.IsNullOrEmpty(s)){ return ret; } 
        
        var start = 0;
        do{
            var dotI = s.IndexOf('.',start);
            var length = int.Parse(s.Substring(start,dotI-start));
            
            ret.Add(length == 0 ? string.Empty : s.Substring(dotI+1, length));
            start = dotI+length+1;
        }while(start < s.Length);
        
        return ret;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(strs));