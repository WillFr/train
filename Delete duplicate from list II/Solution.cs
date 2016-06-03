/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        if(head == null || head.next == null){ return head;}
        
        var t = head.next;
        if(head.val != t.val){
            head.next = DeleteDuplicates(head.next);
            return head;
        }
        
        while(t != null && t.val == head.val){
            t = t.next;
        }
        
        return DeleteDuplicates(t);
    }
}