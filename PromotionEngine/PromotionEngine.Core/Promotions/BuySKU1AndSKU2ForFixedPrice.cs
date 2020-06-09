using System.Linq;

namespace PromotionEngine.Core.Promotions
{
    public class BuySKU1AndSKU2ForFixedPrice : IPromotion
    {
        public string PromotionDetails { get; private set; }

        public BuySKU1AndSKU2ForFixedPrice()
        {
            PromotionDetails = "Buy SKU 1 & SKU 2 for a fixed price (C + D = 30)";
        }

        public void CalculateCost(ICart cart)
        {
            var items = cart.GetItems();

            if (items.Count() > 0)
            {
                var itemsHavingC = items.Where(x => x.SKUId == 'C').FirstOrDefault();
                var itemsHavingD = items.Where(x => x.SKUId == 'D').FirstOrDefault();

                if (itemsHavingC != null && itemsHavingD != null)
                {
                    if (itemsHavingC.Quantity == 1 && itemsHavingD.Quantity == 1)
                    {
                        itemsHavingC.PromotionApplied = true;
                        itemsHavingD.PromotionApplied = true;
                    }
                }
            }
        }
    }
}
