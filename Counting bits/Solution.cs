public class Solution {
    public int[] CountBits(int num) {
        /*
            1   1
            2   1
            3   2
            4   1
            5   2
            6   2
            7   3
            8   1
            9   2
            10  2
            11  3
            12  2
            13  3
            14  3
            15  4
            16  1
        */
        
        var arr = new int[num+1];
        arr[0] = 0;
        for(int i = 1; i <= num; i++)
        {
            /*
                The idea is that every number can be represented as 2n (even) or 2n + 1 (odd)
                multiplying by 2 is like adding a 0 in binary : the number of 1 does not change
                only adding one at the right end increases the number of 1 by 1
            */
            arr[i] = arr[i/2] + (i%2 == 0 ? 0 : 1);
        }
        
        return arr;
    }
}