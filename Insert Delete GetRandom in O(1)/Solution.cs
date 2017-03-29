public class RandomizedSet {
    private Dictionary<int,int> dict;
    private List<int> list;
    private Random rnd = new Random();
    
    /** Initialize your data structure here. */
    public RandomizedSet() {
        this.dict = new Dictionary<int,int>();
        this.list = new List<int>();
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {
        if(dict.ContainsKey(val)) { return false; } 
        
        dict.Add(val, list.Count());
        list.Add(val);
        return true;
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
        if(!dict.ContainsKey(val))
        {
            return false;
        }
        
        dict[list.Last()] = dict[val];
        Swap(list, dict[val], list.Count() -1);
        list.RemoveAt(list.Count() -1);
        dict.Remove(val);
        return true;
    }
    
    /** Get a random element from the set. */
    public int GetRandom() {
        
        return list[rnd.Next(0,list.Count())];
    }
    
    private static void Swap(List<int> l, int i , int j)
    {
        var t = l[i];
        l[i] = l[j];
        l[j] = t;
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */