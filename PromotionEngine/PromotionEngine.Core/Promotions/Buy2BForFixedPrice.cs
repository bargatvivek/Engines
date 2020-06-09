using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Core.Promotions
{
    public class Buy2BForFixedPrice : IPromotion
    {
        public string PromotionDetails { get; private set; }

        public Buy2BForFixedPrice()
        {
            PromotionDetails = "Buy '2' items of a SKU for a fixed price (2 of B's for 45)";
        }

        public void CalculateCost(ICart cart)
        {
            var items = cart.GetItems();

            if (items.Count() > 0)
            {
                var itemsHavingB = items.Where(x => x.SKUId == 'B').FirstOrDefault();

                if (itemsHavingB != null)
                {
                    var count = itemsHavingB.Quantity;

                    if (count >= 2)
                    {
                        var remaining = count % 2;
                        var mutiple = count / 2;
                        itemsHavingB.PromotionApplied = true;
                        itemsHavingB.TotalCost = (45 * mutiple) + (itemsHavingB.Price * remaining);
                    }
                    else
                    {
                        itemsHavingB.TotalCost = itemsHavingB.Price * count;
                    }
                }
            }
        }
    }
}
