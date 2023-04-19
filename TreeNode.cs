using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
   internal class RBTNode
   {
      public int Value { get; set; }
      public List<RBTNode> Children { get; set; }

      public override string ToString()
      {
         if (Value != null)
            return string.Format("{0}", this.Value);
         return "value is null";
      }
   }
}