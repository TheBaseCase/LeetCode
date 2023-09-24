// 
// https://leetcode.com/problems/inorder-successor-in-bst/
// https://www.lintcode.com/problem/448/description

public class Solution {
  public TreeNode inorderSuccessor(TreeNode root, TreeNode p) {
    if (root == null) return null;

    if (p.val >= root.val) return inorderSuccessor(root.right, p);

    TreeNode left = inorderSuccessor(root.left, p);
    return left != null ? left : root;
  }
}
