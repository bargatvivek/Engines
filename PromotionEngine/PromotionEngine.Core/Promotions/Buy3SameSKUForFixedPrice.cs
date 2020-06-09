using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Core.Promotions
{
    public class Buy3SameSKUForFixedPrice : IPromotion
    {
        public string PromotionDetails { get; private set; }

        public Buy3SameSKUForFixedPrice()
        {
            PromotionDetails = "Buy '3' items of a SKU for a fixed price (3 A's for 130)";
        }

        public void CalculateCost(ICart cart)
        {
            var items = cart.GetItems();

            if (items.Count() > 0)
            {
                var itemsHavingA = items.Where(x => x.SKUId == 'A').FirstOrDefault();

                if (itemsHavingA != null)
                {
                    itemsHavingA.PromotionApplied = true;
                }
            }
        }
    }
}
