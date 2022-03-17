using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp
{


        public class AVLTree<T> : BinarySearchTree<T>
        {
            public AVLTree()
            {
            }

            public AVLTree(IEnumerable<T> collection)
                : base(collection)
            {
            }

            public AVLTree(Comparer<T> comparer)
                : base(comparer)
            {
            }


            public override void Insertar(T value)
            {
                base.Add(value);
                var node = Find(value);

                AbstractNode<T> parentNode = node.Parent;

                while (parentNode != null)
                {
                    int balance = GetBalance(parentNode as BinaryTreeNode<T>);
                    if (Math.Abs(balance) == 2)
                    {
                        BalanceAt(parentNode as BinaryTreeNode<T>, balance);
                    }

                    parentNode = parentNode.Parent;
                }
            }

            public override bool Remove(T item)
            {
                if (Root == null)
                    return false;

                BinaryTreeNode<T> valueNode = Find(item);
                AbstractNode<T> parentNode = valueNode.Parent;

                bool removed = base.Remove(item);

                if (!removed)
                    return false;

                while (parentNode != null)
                {
                    int balance = GetBalance(parentNode as BinaryTreeNode<T>);

                    if (Math.Abs(balance) == 1)
                        break;
                    if (Math.Abs(balance) == 2)
                    {
                        BalanceAt(parentNode as BinaryTreeNode<T>, balance);
                    }

                    parentNode = parentNode.Parent;
                }

                return true;
            }

            /// <summary>
            /// Balances an AVL Tree node
            /// </summary>
            protected virtual void BalanceAt(BinaryTreeNode<T> node, int balance)
            {
                if (balance == 2)
                {
                    int rightBalance = GetBalance(node.Right);

                    if (rightBalance == 1 || rightBalance == 0)
                    {
                        RotateLeft(node);
                    }
                    else if (rightBalance == -1)
                    {
                        RotateRight(node.Right);
                        RotateLeft(node);
                    }
                }
                else if (balance == -2)
                {
                    int leftBalance = GetBalance(node.Left);
                    if (leftBalance == 1)
                    {
                        RotateLeft(node.Left);
                        RotateRight(node);
                    }
                    else if (leftBalance == -1 || leftBalance == 0)
                    {
                        RotateRight(node);
                    }
                }
            }

            /// <summary>
            /// Determines the balance of a given node
            /// </summary>
            protected virtual int GetBalance(BinaryTreeNode<T> node)
            {
                if (node != null)
                {
                    IEnumerable<BinaryTreeNode<T>> leftSubtree = null, righSubtree = null;

                    if (node.Left != null)
                        leftSubtree = node.Left.ToEnumerable(BinaryTreeTraversalType.InOrder);

                    if (node.Right != null)
                        righSubtree = node.Right.ToEnumerable(BinaryTreeTraversalType.InOrder);

                    // ReSharper disable AssignNullToNotNullAttribute
                    var leftHeight = leftSubtree.IsNullOrEmpty() ? 0 : leftSubtree.Max(x => x.Depth) - node.Depth;
                    var righHeight = righSubtree.IsNullOrEmpty() ? 0 : righSubtree.Max(x => x.Depth) - node.Depth;
                    // ReSharper restore AssignNullToNotNullAttribute

                    return righHeight - leftHeight;
                }
                return 0;
            }

            /// <summary>
            /// Rotates a node to the left within an AVL Tree
            /// </summary>
            protected virtual void RotateLeft(BinaryTreeNode<T> node)
            {
                if (node == null)
                    return;

                BinaryTreeNode<T> pivot = node.Right;

                if (pivot == null)
                    return;
                var rootParent = node.Parent as BinaryTreeNode<T>;
                bool isLeftChild = (rootParent != null) && rootParent.Left == node;
                bool makeTreeRoot = node == Root;

                node.Right = pivot.Left;
                pivot.Left = node;

                node.Parent = pivot;
                pivot.Parent = rootParent;

                if (node.Right != null)
                    node.Right.Parent = node;

                if (makeTreeRoot)
                    Root = pivot;

                if (isLeftChild)
                    rootParent.Left = pivot;
                else if (rootParent != null)
                    rootParent.Right = pivot;
            }

            /// <summary>
            /// Rotates a node to the right within an AVL Tree
            /// </summary>
            protected virtual void RotateRight(BinaryTreeNode<T> node)
            {
                if (node == null)
                    return;

                BinaryTreeNode<T> pivot = node.Left;

                if (pivot == null)
                    return;
                var rootParent = node.Parent as BinaryTreeNode<T>;
                bool isLeftChild = (rootParent != null) && rootParent.Left == node;
                bool makeTreeRoot = Root == node;

                node.Left = pivot.Right;
                pivot.Right = node;

                node.Parent = pivot;
                pivot.Parent = rootParent;

                if (node.Left != null)
                    node.Left.Parent = node;

                if (makeTreeRoot)
                    Root = pivot;
                if (isLeftChild)
                    rootParent.Left = pivot;
                else if (rootParent != null)
                    rootParent.Right = pivot;
            }
        }
}
