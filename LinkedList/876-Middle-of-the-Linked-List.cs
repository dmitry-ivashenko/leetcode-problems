// 876. Middle of the Linked List
//
// Given the head of a singly linked list, return the middle node of the linked list.
//
// If there are two middle nodes, return the second middle node.
//
//
//
// Example 1:
//
//
// Input: head = [1,2,3,4,5]
// Output: [3,4,5]
// Explanation: The middle node of the list is node 3.
// Example 2:
//
//
// Input: head = [1,2,3,4,5,6]
// Output: [4,5,6]
// Explanation: Since the list has two middle nodes with values 3 and 4, we return the second one.
//
//
// Constraints:
//
// The number of nodes in the list is in the range [1, 100].
// 1 <= Node.val <= 100

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode MiddleNode(ListNode head)
    {
        var fast = head;
        var slow = head;

        while (fast != null && slow != null)
        {
            fast = fast.next;
            if (fast == null) break;
            fast = fast.next;
            slow = slow.next;
        }

        return slow;
    }
}
