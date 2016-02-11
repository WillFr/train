public class Solution
{
    public bool CanJump(int[] nums)
    {
        if (nums.Length <= 1) { return true; }

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] == 0)
            {
                int j = i - 1;
                while (j >= 0 && j + nums[j] <= i) { j--; }
                if (j < 0) { return false; }
            }
        }

        return true;
    }
}