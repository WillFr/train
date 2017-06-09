/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class Solution {
    public int DepthSum(IList<NestedInteger> nestedList, int depth = 1) {
        if(nestedList == null){
            return 0;
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
                ret += DepthSum(node.GetList(), depth + 1);
            }
        }
        
        return ret ;
    }
}