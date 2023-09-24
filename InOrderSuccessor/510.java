// 510. Inorder Successor in BST II
// https://leetcode.com/problems/inorder-successor-in-bst-ii/
// https://www.lintcode.com/problem/3665/

public class Solution {

  public ParentTreeNode inorderSuccessor(ParentTreeNode node) {
    if (node == null) return null;
    if (node.right != null) return findLeftMostNode(node.right);
    return findParent(node);
  }

  private ParentTreeNode findLeftMostNode(ParentTreeNode node) {
    if (node == null) return null;
    if (node.left == null) return node;
    return findLeftMostNode(node.left);
  }

  private ParentTreeNode findParent(ParentTreeNode node) {
    if (node == null) return null;
    if (node.parent != null && node.parent.val > node.val) {
      return node.parent;
    }
    return findParent(node.parent);
  }
}
