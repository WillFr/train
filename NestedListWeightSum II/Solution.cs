/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // Constructor initializes an empty nested list.
 *     public NestedInteger();
 *
 *     // Constructor initializes a single integer.
 *     public NestedInteger(int value);
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // Set this NestedInteger to hold a single integer.
 *     public void SetInteger(int value);
 *
 *     // Set this NestedInteger to hold a nested list and adds a nested integer to it.
 *     public void Add(NestedInteger ni);
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class Solution {
    public int DepthSumInverse(IList<NestedInteger> nestedList, int depth = -1) {
        if(nestedList == null){
            return 0;
        }
        
        if(depth == -1)
        {
            depth = GetDepth(nestedList);
        }
        var ret = 0;
        foreach(var node in nestedList)
        {
            if(node.IsInteger())
            {
                ret += node.GetInteger()* depth;
            }
            else
            {
                ret += DepthSumInverse(node.GetList(), depth - 1);
            }
        }
        
        return ret ;
    }
    
    private static int GetDepth(IList<NestedInteger> nestedList)
    {
        var r = 1;
        foreach(var node in nestedList)
        {
            if(!node.IsInteger())
            {
                r = Math.Max(r, 1 + GetDepth(node.GetList()));
            }
        }
        
        return r;
    }
}