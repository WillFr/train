public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        // a +b+c = 0   <=> a+b = -c
        var r = new List<IList<int>>();
        
        if(nums == null || nums.Length<3){ return r;}
        
        var s =  new Dictionary<int,int>();
        for(int i = 0; i< nums.Length; i++){
            if(!s.ContainsKey(nums[i])){
                s.Add(nums[i], 1);
            }
            else{
                s[nums[i]]++;
            }
        }
        
        var dup = new HashSet<long>();
        
        for(int i = 0; i<nums.Length; i++){
            if(i > 0 && nums[i] == nums[i-1]){ continue;}
            for(int j = i+1; j< nums.Length; j++){
                if(j > i+1 && nums[j] == nums[j-1]){ continue;}
                
                var a = nums[i];
                var b = nums[j];
                var c = (a+b) * (-1);
                
                var t = new Triple(a,b,c);
                if(!dup.Contains(t.Key) && s.ContainsKey(c) && (
                s[c] == 1 && c!= a && c!= b
                || s[c] == 2 && (c!= a || c!= b)
                || s[c] >= 3
                )){
                    r.Add(t.List);
                    dup.Add(t.Key);
                }
            }
        }
        
        return r;
    }
    
    private class Triple{
        public long Key {get; private set;}
        public List<int> List {get; private set;}
        public Triple(int a, int b, int c){
            this.List = SortThree(a,b,c);
            var min = this.List[0];
            var max = this.List[1];
            this.Key = ((long)Math.Abs(max))<<32 + Math.Abs(min);
            

        }
        
        private static List<int> SortThree(int a, int b, int c){
            if(a<b){
                if(a<c){
                    if(b<c){
                        return new List<int>(){a,b,c};
                    }
                    else{
                        return new List<int>(){a,c,b};
                    }
                }
                else{ //c<a && a<b
                    return new List<int>(){c,a,b};
                   
                }
            }
            else{ // a > b
                if(b>c){
                    return new List<int>(){c,b,a};
                }
                else{ //a>b && c>b
                    if(a<c){
                        return new List<int>(){b,a,c};
                    }
                    else{ 
                        return new List<int>(){b,c,a};
                    }
                }
            }
        }
    } 
}