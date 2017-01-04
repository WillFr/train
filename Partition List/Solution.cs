/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode Partition(ListNode head, int x) {
        if(head == null || head.next == null){ return head; }
        
        ListNode beforeHead = null, beforeTail = null, afterHead = null, afterTail = null;
        
        var t = head;
        while(t != null){
            var next = t.next;
            if(t.val < x){
                if(beforeHead == null){
                    beforeHead = t;
                }
                else{
                    beforeTail.next = t;
                }
                
                beforeTail = t;
            }else{
                if(afterHead == null){
                    afterHead = t;
                }
                else{
                    afterTail.next = t;
                }
                
                afterTail = t;
            }

            t = next;
        }
        
        if(beforeHead == null){
            afterTail.next = null;
            return afterHead;
        }
        
        if(afterHead == null){
            beforeTail.next = null;
            return beforeHead;
        }
        
        
        afterTail.next = null;
        beforeTail.next = afterHead;
        
        return beforeHead;
    }
}