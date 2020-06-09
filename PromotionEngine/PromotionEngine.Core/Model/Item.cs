
using PromotionEngine.Core.DataStore;

namespace PromotionEngine.Core.Model
{
    public class Item
    {
        public Item(char skuId, int quantity)
        {
            SKUId = skuId;
            Price = Stock.sku[skuId];
            Quantity = quantity;
            PromotionApplied = false;
        }
        public char SKUId { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; set; }
        public bool PromotionApplied { get; set; }
        public decimal TotalCost { get; set; }
    }
}
