// 101. Symmetric Tree
//
// Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).
//
// Example 1:
// Input: root = [1,2,2,3,4,4,3]
// Output: true
//
//
// Example 2:
// Input: root = [1,2,2,null,3,null,3]
// Output: false
//
// Constraints:
//
// The number of nodes in the tree is in the range [1, 1000].
// -100 <= Node.val <= 100
//
// Follow up: Could you solve it both recursively and iteratively?

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public bool IsSymmetric(TreeNode root)
    {
        if (root == null)
            return false;

        return IsSymmetricIteratively(root);
        // return IsSymmetricRecursive(root.left, root.right);
    }

    public bool IsSymmetricIteratively(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root.left);
        queue.Enqueue(root.right);

        while (queue.Count > 0)
        {
            var p = queue.Dequeue();
            var q = queue.Dequeue();

            if (p == null && q == null) continue;
            if ((p == null) != (q == null)) return false;
            if (p.val != q.val) return false;

            queue.Enqueue(p.left);
            queue.Enqueue(q.right);
            queue.Enqueue(p.right);
            queue.Enqueue(q.left);
        }

        return true;
    }

    public bool IsSymmetricRecursive(TreeNode left, TreeNode right)
    {
        if (left == null && right == null)
            return true;

        if ((left == null) != (right == null))
            return false;

        if (left.val != right.val)
            return false;

        var leftIsSymmetric = IsSymmetricRecursive(left.left, right.right);
        var rightIsSymmetric = IsSymmetricRecursive(left.right, right.left);

        return leftIsSymmetric && rightIsSymmetric;
    }
}
