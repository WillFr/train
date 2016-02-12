public class Solution
{
    public bool ValidTree(int n, int[,] edges)
    {

        if (n <= 1) { return true; }
        if (edges.GetLength(0) != n - 1) { return false; }

        var edgeH = new List<int>[n];
        var root = -1;
        for (int i = 0; i < edges.GetLength(0); i++)
        {
            var e1 = edges[i, 0];
            var e2 = edges[i, 1];

            if (edgeH[e1] == null) { edgeH[e1] = new List<int>(); }
            if (edgeH[e2] == null) { edgeH[e2] = new List<int>(); }

            if (edgeH[e1].Count() == 3) { return false; } else { edgeH[e1].Add(e2); if (root == -1) { root = e1; } }
            if (edgeH[e2].Count() == 3) { return false; } else { edgeH[e2].Add(e1); }
        }

        return !HasCycles(edgeH, root, -1, new bool[n]);
    }

    private static bool HasCycles(List<int>[] edgeH, int root, int parent, bool[] treated)
    {
        if (treated[root]) { return true; }
        treated[root] = true;


        var children = edgeH[root].Where(x => parent == -1 || x != parent);

        foreach (var c in children)
        {
            if (HasCycles(edgeH, c, root, treated))
            {
                return true;
            }
        }

        return false;
    }
}