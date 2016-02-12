/* The Knows API is defined in the parent class Relation.
      bool Knows(int a, int b); */

public class Solution : Relation
{
    public int FindCelebrity(int n)
    {
        for (int i = 0; i < n; i++)
        {
            if (!DoesIknowsAnyone(i, n))
            {
                if (DoesEveryOneKnowsI(i, n))
                {
                    return i;
                }
            }

        }

        return -1;
    }

    private bool DoesIknowsAnyone(int i, int n)
    {
        for (int k = 0; k < n; k++)
        {
            if (k == i) { continue; }
            if (Knows(i, k)) { return true; }
        }

        return false;
    }

    private bool DoesEveryOneKnowsI(int i, int n)
    {
        for (int k = 0; k < n; k++)
        {
            if (k == i) { continue; }
            if (!Knows(k, i)) { return false; }
        }

        return true;
    }
}