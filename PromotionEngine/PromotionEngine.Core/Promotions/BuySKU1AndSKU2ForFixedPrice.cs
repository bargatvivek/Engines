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
                        itemsHavingC.TotalCost = 0;

                        itemsHavingD.PromotionApplied = true;
                        itemsHavingD.TotalCost = 30;
                    }
                    else
                    {
                        itemsHavingC.TotalCost = itemsHavingC.Quantity * itemsHavingC.Price;
                        itemsHavingD.TotalCost = itemsHavingD.Quantity * itemsHavingD.Price;
                    }
                }
                else
                {
                    if (itemsHavingC != null && itemsHavingC.Quantity != 0)
                    {
                        itemsHavingC.TotalCost = itemsHavingC.Quantity * itemsHavingC.Price;
                    }

                    if (itemsHavingD != null && itemsHavingD.Quantity != 0)
                    {
                        itemsHavingD.TotalCost = itemsHavingD.Quantity * itemsHavingD.Price;
                    }
                }
            }
        }
    }
}
