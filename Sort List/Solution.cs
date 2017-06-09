/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode SortList(ListNode head) {
        if(head == null || head.next == null){ return head; }
        
        var p1 = head;
        var p2 = head.next;
        
        while(p2.next != null && p2.next.next != null){
            p1 = p1.next;
            p2 = p2.next.next;
        }
        
        var t = p1.next;
        p1.next = null;
        
        var h1 = SortList(head);
        var h2 = SortList(t);
        return Merge(h1,h2);
    }
    
    private static ListNode Merge(ListNode h1, ListNode h2)
    {
        var t1 = h1; 
        var t2 = h2;
        
        ListNode head;
        if(t2 == null || t1 != null && t1.val <= t2.val){
            head = t1;
            t1 = t1.next;
        }
        else
        {
            head = t2;
            t2 = t2.next;
        }
        
        var tail = head;
        while(t1 != null || t2 != null)
        {
            if(t2 == null || t1 != null && t1.val <= t2.val){
                tail.next = t1;
                t1 = t1.next;
            }
            else
            {
                tail.next = t2;
                t2 = t2.next;
            }
             
            tail = tail.next;
        }
        
        return head;
    }
}