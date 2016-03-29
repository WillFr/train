/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode ReverseBetween(ListNode head, int m, int n) {
        var length = n-m +1;
        
        if(m == 1){
            ListNode tail;
            var h = ReverseList(head, length, out tail);
            head.next = tail;
            return h;
        }
        else{
            var c = 2;
            var t = head;
            while(c != m){
                t = t.next;
                c++;
            }
            
            ListNode tail;
            var h = ReverseList(t.next, length, out tail);
            t.next.next = tail;
            t.next = h;    
            
            return head;
        }
        
    }
    
    private ListNode ReverseList(ListNode head, int count, out ListNode next){
        if(count == 1){
            next = head.next;
            return head;
        }
        
        var t = head.next;
        var r = ReverseList(head.next, count - 1, out next);
        t.next = head;
        head.next = null;
        
        return r;
        
    }
}