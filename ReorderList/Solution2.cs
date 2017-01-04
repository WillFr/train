/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
 
 /*
 1234
 4321
 42 - 31
 42 - 13
 
 
 123
 321
 31-2
 31-2
 
 */
public class Solution {
    public void ReorderList(ListNode head) {
        if(head == null || head.next == null || head.next.next == null){
            return;
        }
        
        var count = Count(head);
        var h1 = head;
        var h2 = head;
        for(int i = 1; i < (count + 1)/2; i++){
            h2 = h2.next;
        }
        
        var n = h2.next;
        h2.next = null;
        h2 = n;
        
        var h2r = Reverse(h2);

        Merge(h1,h2r);
        
    }
    
    private static int Count(ListNode root){
        if(root == null){
            return 0;
        }
        
        return 1 + Count(root.next);
    }
    
    private static ListNode Reverse(ListNode head){
        if(head.next == null){
            return head;
        }
        
        var n = head.next;
        var r = Reverse(n);
        n.next = head;
        head.next = null;
        
        return r;
    }
    
    private static void Merge(ListNode h1, ListNode h2){
        var t = h1;
        var t1 = h1.next;
        var t2 = h2;
        
        var odd = t2;
        while(odd != null){
            t.next = odd;
            t = t.next;
            
            if(odd == t1){
                t1 = t1.next;
                odd = t2;
            }
            else{
                t2 = t2.next;
                odd = t1;
            }
        }
    }
    
    private static void Print(ListNode n){
        if(n != null){
            Console.Write(n.val);
            Print(n.next);
        }
    }
}