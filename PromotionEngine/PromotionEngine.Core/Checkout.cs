using PromotionEngine.Core.Promotions;
using System.Collections.Generic;

namespace PromotionEngine.Core
{
    public class Checkout
    {
        List<IPromotion> _promotions = new List<IPromotion>();

        public Checkout()
        {
            _promotions.Add(new Buy3SameSKUForFixedPrice());
        }

        public decimal CalculateFinalCost(ICart cart)
        {
            decimal finalcost = 0;
            foreach (var promotion in _promotions)
            {
                promotion.CalculateCost(cart);
            }
            return finalcost;
        }
    }
}
