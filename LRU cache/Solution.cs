public class LRUCache
{
    private class CachedValue
    {
        public CachedValue Prev { get; set; }
        public CachedValue Next { get; set; }
        public int Val { get; set; }
        public int Key { get; set; }
    }


    private CachedValue head;
    private CachedValue tail;
    private Dictionary<int, CachedValue> dict = new Dictionary<int, CachedValue>();
    private int count = 0;
    private int capacity;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
    }

    public int Get(int key)
    {
        if (dict.ContainsKey(key))
        {
            var r = dict[key];
            BringToHead(r);
            return r.Val;
        }
        else
        {
            return -1;
        }
    }

    public void Set(int key, int value)
    {
        //Console.WriteLine("Adding " + key + ":" + value + " -- " + (head == null ? "NULL" : head.Key.ToString()) +" : " +  (tail == null ? "NULL" : tail.Key.ToString())+" : " +  (tail == null || tail.Prev == null ? "NULL" : tail.Prev.Key.ToString())+" : " +  (head == null || head.Next == null ? "NULL" : head.Next.Key.ToString()));
        if (dict.ContainsKey(key))
        {
            var r = dict[key];
            r.Val = value;
            BringToHead(r);
        }
        else
        {
            var nv = new CachedValue() { Val = value, Key = key };

            if (count == capacity)
            {
                DiscardLRU();
            }
            else
            {
                count++;
            }

            AddNew(nv);
            dict.Add(key, nv);
        }


        //Console.WriteLine("Added " + key + ":" + value + " -- " + (head == null ? "NULL" : head.Key.ToString()) +" : " +  (tail == null ? "NULL" : tail.Key.ToString())+" : " +  (tail == null || tail.Prev == null ? "NULL" : tail.Prev.Key.ToString())+" : " +  (head == null || head.Next == null ? "NULL" : head.Next.Key.ToString()));
    }

    private void DiscardLRU()
    {
        var t = tail;
        dict.Remove(tail.Key);

        if (t == head)
        {
            head = null;
            tail = null;
            return;
        }

        tail = tail.Prev;
        tail.Next = null;
        t.Prev = null;
    }

    private void AddNew(CachedValue nv)
    {
        nv.Next = head;
        nv.Prev = null;
        if (head != null) { head.Prev = nv; }
        else { tail = nv; }

        head = nv;
    }

    private void BringToHead(CachedValue r)
    {
        if (r == head) { return; }

        r.Prev.Next = r.Next;
        if (r == tail)
        {
            tail = r.Prev;
        }
        else
        {
            r.Next.Prev = r.Prev;
        }

        r.Next = head;
        head.Prev = r;

        head = r;
        head.Prev = null;
    }
}