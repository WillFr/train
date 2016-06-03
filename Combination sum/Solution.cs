public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        Array.Sort(candidates);
        return CombinationSum(candidates, target, candidates.Length - 1);
    }

    public IList<IList<int>> CombinationSum(int[] candidates, int target, int i)
    {
        var r = new List<IList<int>>();
        if (target == 0) { r.Add(new List<int>()); return r; }

        for (int k = i; k >= 0; k--)
        {
            var c = candidates[k];
            if (target - c < 0) { continue; }

            var tr = CombinationSum(candidates, target - c, k);
            foreach (var t in tr)
            {
                t.Add(c);
                r.Add(t);
            }
        }

        return r;
    }
}