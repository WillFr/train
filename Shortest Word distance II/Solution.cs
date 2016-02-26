public class WordDistance {
    private Dictionary<string,List<int>> dic = new Dictionary<string,List<int>>();
    
    public WordDistance(string[] words) {
        for(int i = 0; i < words.Length; i++){
            if(!dic.ContainsKey(words[i])){ dic.Add(words[i], new List<int>()); }
            dic[words[i]].Add(i);
        }
        
        foreach(var k in dic.Keys){
            dic[k].Sort();
        }
    }

    public int Shortest(string word1, string word2) {
        var a = dic[word1];
        var b = dic[word2];

        return GetMin(a,b);
    }
    
    private int GetMin(List<int> a, List<int> b){
        var min = (int)Math.Abs(a[0]-b[0]); 
        if(a.Count() == 1 && b.Count==1){ return min; }
        
        int i = 0, j = 0;
        
        while(i<a.Count() && j<b.Count()){
            if(a[i]<b[j]){
                while(i<a.Count()-1 && a[i+1] < b[j]){i++;}
                var d = (int)Math.Abs(a[i]-b[j]);
                if(d<min){ min = d; }
                i++;
            }
            else{
                while(j< b.Count()-1 && b[j+1]<a[i]){j++;}
                var d = (int)Math.Abs(a[i]-b[j]);
                if(d<min){ min = d; }
                j++;
            }
        }
        
        return min;
    }
}