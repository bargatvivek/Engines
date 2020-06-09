using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Core.DataStore
{
    public static class Stock
    {
        public static readonly Dictionary<char, decimal> sku = new Dictionary<char, decimal>();
        static Stock()
        {
            sku.Add('A', 50);
            sku.Add('B', 30);
            sku.Add('C', 20);
            sku.Add('D', 15);
        }
    }
}
