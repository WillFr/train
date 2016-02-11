public class Solution
{
    public int ThreeSumSmaller(int[] nums, int target)
    {
        if (nums == null || nums.Length < 3) { return 0; }

        return Improvement1(nums, target);
    }

    public static int BruteForce(int[] nums, int target) //n^3
    {
        var c = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                for (int k = j + 1; k < nums.Length; k++)
                {
                    if (nums[i] + nums[j] + nums[k] < target)
                    {
                        c++;
                    }
                }
            }
        }

        return c;
    }

    public static int Improvement1(int[] nums, int target)
    {
        // a+b+c < t <=> a+b < t-c

        Array.Sort(nums);

        var c = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            var t = target - nums[i];
            var r = Get2LowerThanXCount(t, nums, i);
            //Console.WriteLine("t = "+t+ "; r="+r);
            c += r;
        }

        return c;
    }

    private static int Get2LowerThanXCount(int target, int[] arr, int except)
    {
        // assume the array is sorted and do it in n time;
        var ret = 0;

        int l = except + 1;
        int r = arr.Length - 1;

        while (l < r)
        {
            if (r == except) { r--; }

            if (l != except && arr[l] + arr[r] < target)
            {
                ret += r - l;
                if (except <= r) { ret--; }
                l++;
            }
            else
            {
                r--;
            }
        }

        return ret;
    }
}