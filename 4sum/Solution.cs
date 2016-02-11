public class Solution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        var r = new List<IList<int>>();
        if (nums.Length < 4) { return r; }

        Array.Sort(nums);

        var count = new Dictionary<int, int>();
        var h2 = new Dictionary<int, List<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!count.ContainsKey(nums[i])) { count.Add(nums[i], 0); }
            count[nums[i]]++;
        }

        var arr = count.Keys.ToArray();

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i; j < arr.Length; j++)
            {
                var s = arr[i] + arr[j];

                if (!h2.ContainsKey(s))
                {
                    h2.Add(s, new List<int>());
                }

                h2[s].Add(arr[i]);
                h2[s].Add(arr[j]);
            }
        }

        //Console.WriteLine(string.Join("\n", h2.Keys.Select(x => x+":"+ string.Join(";",h2[x]))));


        foreach (var k in h2.Keys)
        {
            for (int i = 0; i < h2[k].Count(); i += 2)
            {
                var i1 = h2[k][i];
                var i2 = h2[k][i + 1];

                var t = i1 + i2;
                if (target - t < t) { continue; }

                count[i1]--;
                count[i2]--;

                if (h2.ContainsKey(target - t))
                {
                    for (int j = 0; j < h2[target - t].Count(); j += 2)
                    {
                        var j1 = h2[target - t][j];
                        var j2 = h2[target - t][j + 1];

                        if (j1 < i2) { continue; }

                        count[j1]--;
                        count[j2]--;

                        if (count[i1] >= 0 && count[i2] >= 0 && count[j1] >= 0 && count[j2] >= 0)
                        {

                            var max = Math.Max(i2, j2);
                            var min = Math.Min(i1, j1);
                            var sMax = 0;
                            var sMin = 0;
                            if (max == j2)
                            {
                                if (min == j1) { sMax = i2; sMin = i1; }
                                else { sMax = Math.Max(j1, i2); sMin = Math.Min(j1, i2); }
                            }
                            else
                            {
                                if (min == i1) { sMax = j2; sMin = j1; }
                                else { sMax = Math.Max(i1, j2); sMin = Math.Min(i1, j2); }
                            }

                            var l = new List<int>() { min, sMin, sMax, max };
                            r.Add(l);
                        }

                        count[j1]++;
                        count[j2]++;
                    }
                }

                count[i1]++;
                count[i2]++;
            }
        }

        return r;
    }
}