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
public class NestedIterator {
    private int i = -1;
    private IList<NestedInteger> list;
    private NestedIterator iterator;
    
    
    public NestedIterator(IList<NestedInteger> nestedList) {
        this.list = nestedList;
    }

    public bool HasNext() {
        if(this.iterator!= null && this.iterator.HasNext()){ return true;}
        if(i+1 == list.Count()){return false;  }
        
        do{ 
            this.iterator = list[i+1].IsInteger() ? null : new NestedIterator(list[++i].GetList()) ;
        }while(i+1<list.Count() && this.iterator != null && !this.iterator.HasNext());
        
        return (i+1 < list.Count() && list[i+1].IsInteger()) 
        || (i < list.Count() && this.iterator != null && this.iterator.HasNext() );
    }

    public int Next() {
        if(this.iterator!= null){
            return this.iterator.Next();
        }
        
        i++;
        return list[i].GetInteger();
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */