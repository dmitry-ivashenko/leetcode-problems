// 530. Minimum Absolute Difference in BST
//
// Given the root of a Binary Search Tree (BST), return the minimum absolute difference
// between the values of any two different nodes in the tree.
//
// Example 1:
// Input: root = [4,2,6,1,3]
// Output: 1
//
// Example 2:
// Input: root = [1,0,48,null,null,12,49]
// Output: 1
//
// Constraints:
//
// The number of nodes in the tree is in the range [2, 104].
// 0 <= Node.val <= 105

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
    private int _min = int.MaxValue;
    private TreeNode _prev = null;

    public int GetMinimumDifference(TreeNode root)
    {
        Visit(root);
        return _min;
    }

    public void Visit(TreeNode node)
    {
        if (node == null) return;

        Visit(node.left);

        if (_prev != null)
        {
            _min = Math.Min(_min, node.val - _prev.val);
        }

        _prev = node;

        Visit(node.right);
    }
}
