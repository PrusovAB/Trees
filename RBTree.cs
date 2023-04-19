using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
   internal class RBTree<T>
   {
      RBTNode Root { get; set; }
      public bool IsContains(int value)
      {
         RBTNode node = IsContains(Root, value);
         if (node != null) { return true; }
         else { return false; }
      }

      private RBTNode IsContains(RBTNode node, int value)
      {
         if (node.Value == value)
         {
            return node;
         }
         else
         {
            foreach (RBTNode child in node.Children)
            {
               RBTNode result = IsContains(child, value);
               if (result != null)
                  return result;
            }
         }
         return null;
      }

   }
}