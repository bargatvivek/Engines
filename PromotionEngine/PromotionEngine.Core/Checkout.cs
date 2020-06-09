using PromotionEngine.Core.Promotions;
using System.Collections.Generic;

namespace PromotionEngine.Core
{
    public class Checkout
    {
        List<IPromotion> _promotions = new List<IPromotion>();

        public Checkout()
        {
            _promotions.Add(new Buy3AForFixedPrice());
            _promotions.Add(new BuyCAndDForFixedPrice());
            _promotions.Add(new Buy2BForFixedPrice());
        }

        public decimal CalculateFinalCost(ICart cart)
        {
            decimal finalCost = 0;

            // Apply promotion, if any
            foreach (var promotion in _promotions)
            {
                promotion.CalculateCost(cart);
            }

            // calculate total cost for the item in cart, to whom promotion is not applied
            foreach (var item in cart.GetItems())
            {
                if (!item.PromotionApplied && item.Quantity > 1 && item.TotalCost == 0)
                {
                    finalCost += item.Quantity * item.Price;
                }
                else
                {
                    finalCost += item.TotalCost;
                }
            }
            return finalCost;
        }
    }
}
