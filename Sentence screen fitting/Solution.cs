public class Solution {
    public int WordsTyping(string[] sentence, int rows, int cols) {
        if(sentence == null || sentence.Length == 0){ return -1; }
        if(rows == 0 || cols == 0){ return 0; }
        
        cols  = cols+1;
        int sentenceLength = sentence.Select(x =>x.Length).Sum()+sentence.Length;
        if(sentenceLength <= cols && cols % sentenceLength < sentence[0].Length+1){
            return cols/sentenceLength * rows;
        }
        
        return WordsTypinghelper(sentence, sentenceLength , rows, cols);
    }
    
    private static int WordsTypinghelper(string[] sentence, int sentenceLength, int rows, int cols)
    {
        int r = 0, rot = 0;
        while(rows != 0)
        {
            int c = 0, w=0,rotation = 0;
            r += cols/sentenceLength;
            c = cols/sentenceLength*sentenceLength;
            //Console.Write(string.Join(" ", sentence)+ " ");
            
            while(sentence[w].Length+1 <= cols-c)
            {
                
                c += sentence[w].Length+1;
                //Console.Write(sentence[w] + " ");
                
                rotation ++;
                w++;
            } 
            
            Rotate(sentence, rotation);
            rot += rotation;
            
            r += rot/sentence.Length;
            rot = rot % sentence.Length;
            rows--;
            //Console.WriteLine();
        }
                
        return r;
    }
    
    private static void Rotate(string[] arr, int r)
    {
        Reverse(arr,0,r-1);
        Reverse(arr,r,arr.Length-1);
        Reverse(arr, 0, arr.Length-1);
    }
    
    private static void Reverse(string[] arr, int s, int e)
    {
        while(e>s)
        {
            Swap(arr, s++ , e--);
        }
    }
    
    
    private static void Swap(string[] arr, int i, int j)
    {
        var t = arr[i];
        arr[i] = arr[j];
        arr[j] = t;
    }
}