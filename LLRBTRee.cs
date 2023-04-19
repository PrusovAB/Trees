using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Trees
{
   internal class LLRBTRee
   {
      public LLRBNode Root { get; set; }
      public bool AddChild(int value)
      {
         if (Root != null)
         {
            bool result = AddChild(Root, value);
            Root = Rebalance(Root);
            Root.Color = Color.BLACK;
            return result;
         }
         else
         {
            Root = new LLRBNode();
            Root.Color = Color.BLACK;
            Root.Value = value;
            return true;
         }
      }

      private bool AddChild(LLRBNode node, int value)
      {
         if (node.Value == value)
         {
            return false;
         }
         else
         {
            if (node.Value > value)
            {
               if (node.LeftChild != null)
               {
                  bool result = AddChild(node.LeftChild, value);
                  node.LeftChild = Rebalance(node.LeftChild);
                  return result;
               }
               else
               {
                  node.LeftChild = new LLRBNode();
                  node.LeftChild.Color = Color.RED;
                  node.LeftChild.Value = value;
                  return true;
               }
            }
            else
            {
               if (node.RightChild != null)
               {
                  bool result = AddChild(node.RightChild, value);
                  node.RightChild = Rebalance(node.RightChild);
                  return result;
               }
               else
               {
                  node.RightChild = new LLRBNode();
                  node.RightChild.Color = Color.RED;
                  node.RightChild.Value = value;
                  return true;
               }
            }
         }
      }

      private LLRBNode Rebalance(LLRBNode node)
      {
         LLRBNode result = node;
         bool needRebalance;

         do
         {
            needRebalance = false;
            if (result.RightChild != null
               && result.RightChild.Color == Color.RED
               && (result.LeftChild == null || result.LeftChild.Color == Color.BLACK))
            {
               needRebalance = true;
               result = RightSwap(result);
            }
            if (result.LeftChild != null
               && result.LeftChild.Color == Color.RED
               && result.LeftChild.LeftChild != null && result.LeftChild.LeftChild.Color == Color.RED)
            {
               needRebalance = true;
               result = LeftSwap(result);
            }
            if (result.LeftChild != null
               && result.LeftChild.Color == Color.RED
               && result.RightChild != null
               && result.RightChild.Color == Color.RED)
            {
               needRebalance = true;
               ColorSwap(result);
            }
         } while (needRebalance);
         return result;
      }

      private LLRBNode RightSwap(LLRBNode node)
      {
         LLRBNode rightChild = node.RightChild;
         LLRBNode betweenNode = rightChild.LeftChild;
         rightChild.LeftChild = node;
         node.RightChild = betweenNode;
         rightChild.Color = node.Color;
         node.Color = Color.RED;

         return rightChild;
      }
      private LLRBNode LeftSwap(LLRBNode node)
      {
         LLRBNode leftChild = node.LeftChild;
         LLRBNode betweenChild = leftChild.RightChild;
         leftChild.RightChild = node;
         node.LeftChild = betweenChild;
         leftChild.Color = node.Color;
         node.Color = Color.RED;

         return leftChild;
      }
      private void ColorSwap(LLRBNode node)
      {
         node.RightChild.Color = Color.BLACK;
         node.LeftChild.Color = Color.BLACK;
         node.Color = Color.RED;
      }
   }
}