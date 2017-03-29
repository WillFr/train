public class LRUCache {
    private LinkedList<Node> list;
    private int capacity;
    private int count; 
    private Dictionary<int,LinkedListNode<Node>> dict;
    
    private struct Node
    {
        public int Key;
        public int Val;
    }
    public LRUCache(int capacity) {
        this.capacity = capacity;
        this.list = new LinkedList<Node>();
        this.dict = new Dictionary<int,LinkedListNode<Node>>();
    }
    
    public int Get(int key) {
        if(this.dict.ContainsKey(key))
        {
            var node = dict[key];
            list.Remove(node);
            list.AddFirst(node);
            return this.dict[key].Value.Val;
        }
        else
        {
            return -1;
        }
    }
    
    public void Put(int key, int value) {
        if(dict.ContainsKey(key))
        {
            var node = dict[key];
            dict.Remove(key);
            list.Remove(node);
            count --;
        }
        
        if(count == capacity)
        {
            dict.Remove(list.Last.Value.Key);
            list.Remove(list.Last);
        }
        else
        {
            count ++;
        }
        
        list.AddFirst(new LinkedListNode<Node>(new Node{ Key = key, Val = value }));
        dict.Add(key, list.First);
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */