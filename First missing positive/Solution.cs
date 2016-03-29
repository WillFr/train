public class Solution {
    public int FirstMissingPositive(int[] nums) {
        /*var maxP = 0;
        var c = 0;
        
        var posSum = 0;
        foreach(var i in nums){
            if(i<=0){ continue;}
            
            if((c<maxP && i<maxP) || i>maxP){
                if(i > maxP){ maxP = i; }
                c++;
                posSum += i;
            }
        }
        
        Console.WriteLine(c);
        if(c == 0){ return 1; }

        var shouldBe = maxP * (1+maxP) / 2; //test : 1,2 => 3
        var missing = shouldBe-posSum;
        
        if(missing == 0){ return maxP+1; }
        
        var m = maxP-c;
        var fm = (2*missing-m*(m-1))/(2*m);
        return fm;
        
        
        
        -----------------------------*/
        var f = nums.FirstOrDefault( x => x > 0 && x <= nums.Length);
        if (f == default(int)){ return 1; }

        
        for(int i = 0; i < nums.Length; i++){
            if(nums[i]<= 0 || nums[i] > nums.Length ){ 
                nums[i] = f; 
                continue; 
            }
        }
        
        //Console.WriteLine(String.Join(",", nums));
        
        for(int i = 0; i < nums.Length; i++){
            var t = (int)Math.Abs(nums[i]);
            if(nums[t-1] > 0){nums[t-1] *= -1; }
            
        }
        
        //Console.WriteLine(String.Join(",", nums));
        
        for(int i = 0; i < nums.Length; i++){
            if(nums[i] > 0){
                return i+1;
            }
        }
        
        return nums.Length+1;
    }
}