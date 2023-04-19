using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
   internal class LLRBTreeView
   {
      public void PostOrderPrint(LLRBNode node)
      {
         PostOrder(node, 0);
      }
      private void PostOrder(LLRBNode node, int deep)
      {
         if (node != null)
         {
            deep++;
            Console.WriteLine($"{deep} -> {node.Value}");
            PostOrder(node.LeftChild, deep);
            PostOrder(node.RightChild, deep);
         }
      }
   }
}