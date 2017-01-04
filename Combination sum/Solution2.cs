 public class Solution
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            return CombinationSum(candidates, target, candidates.Length - 1, new Dictionary<Tuple<int, int>, IList<IList<int>>>());
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target, int i, Dictionary<Tuple<int,int>, IList<IList<int>>> memo)
        {
            var r = new List<IList<int>>();
            if (target == 0) { r.Add(new List<int>()); return r; }

            if (memo.ContainsKey(new Tuple<int, int>(target,i)))
            {
                return memo[new Tuple<int, int>(target, i)].Select(x => (IList<int>)x.ToList()).ToList();
            }

            for (int k = i; k >= 0; k--)
            {
                var c = candidates[k];
                if (target - c < 0) { continue; }

                var tr = CombinationSum(candidates, target - c, k, memo);
                foreach (var t in tr)
                {
                    t.Add(c);
                    r.Add(t);
                }
            }

            memo.Add(new Tuple<int, int>(target,i), r.Select(x => (IList<int>)x.ToList()).ToList());
            return r;
        }
    }