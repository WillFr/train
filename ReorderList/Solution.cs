/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public void ReorderList(ListNode head) {
        if(head == null || head.next == null){ return; }
        
        head.next = Reverse(head.next);
        ReorderList(head.next);
    }
    
    private static ListNode Reverse(ListNode head){
        if(head == null || head.next == null){
            return head;
        }
        
        var t = head.next;
        head.next = null;
        var r = Reverse(t);
        t.next = head;
        
        return r;
        
    }
}