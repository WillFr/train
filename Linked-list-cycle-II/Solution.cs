/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution
{
    public ListNode DetectCycle(ListNode head)
    {
        if (head == null || head.next == null) { return null; }

        var slow = head;
        var fast = head;

        do
        {
            fast = fast.next.next;
            slow = slow.next;
        } while (fast != null && fast.next != null && fast != slow);

        if (fast == null || fast.next == null)
        {
            // no cycle 
            return null;
        }

        slow = head;
        while (slow != fast)
        {
            slow = slow.next;
            fast = fast.next;
        }

        return slow;
    }
}