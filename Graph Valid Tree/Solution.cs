public class Solution
{
    public bool ValidTree(int n, int[,] edges)
    {
        if (n <= 1) { return true; }
        if (edges.GetLength(0) < n - 1) { return false; }

        //var treated = new bool[n];
        //var leafs = new HashSet<int>();
        var edgeH = new Dictionary<int, List<int>>();

        for (int i = 0; i < edges.GetLength(0); i++)
        {
            var e1 = edges[i, 0];
            var e2 = edges[i, 1];

            /*if(leafs.Contains(e1)){ leafs.Remove(e1); } else if(!treated[e1]){ leafs.Add(e1); treated[e1] = true; }
            if(leafs.Contains(e2)){ leafs.Remove(e2); } else if(!treated[e2]){ leafs.Add(e2); treated[e2] = true; }*/

            if (!edgeH.ContainsKey(e1)) { edgeH.Add(e1, new List<int>()); }
            if (!edgeH.ContainsKey(e2)) { edgeH.Add(e2, new List<int>()); }

            if (edgeH[e1].Count() == 3) { Console.WriteLine(e1 + " has more than two edges"); return false; } else { edgeH[e1].Add(e2); }
            if (edgeH[e2].Count() == 3) { Console.WriteLine(e2 + " has more than two edges"); return false; } else { edgeH[e2].Add(e1); }
        }

        /*Console.WriteLine("leafs: "+ String.Join(",", leafs));
        
        if(!leafs.Any()){ return false; }*/

        return HasCycles(edgeH, edgeH.Keys.First(), -1, new bool[n]);
    }

    private static bool HasCycles(Dictionary<int, List<int>> edgeH, int root, int parent, bool[] treated)
    {
        if (treated[root]) { return false; }
        treated[root] = true;
        var children = edgeH[root].Where(x => parent == -1 || x != parent);

        //Console.WriteLine("parent = " + parent + " root = " + root + " ; children = "+ String.Join(",", children));

        var ret = true;

        foreach (var c in children)
        {
            ret &= HasCycles(edgeH, c, root, treated);
        }

        return ret;
    }
}