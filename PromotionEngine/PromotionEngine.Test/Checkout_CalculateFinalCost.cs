using NUnit.Framework;
using PromotionEngine.Core;
using PromotionEngine.Core.Model;
using System.Linq;

namespace PromotionEngine.Test
{
    public class Checkout_CalculateFinalCost
    {
        private Cart _cart;
        private Checkout _checkout;

        [OneTimeSetUp]
        public void SetUp()
        {
            _cart = Cart.Instance;
            _checkout = new Checkout();

            // Senario B
            _cart.Add(new Item('A', 5));
            _cart.Add(new Item('B', 5));
            _cart.Add(new Item('C', 1));
        }

        [Test]
        public void Buy_3_items_of_same_sku_for_fixed_price_3AsFor130_AppliedOrNot()
        {
            _checkout.CalculateFinalCost(_cart);
            var item = _cart.GetItems().Where(x => x.SKUId == 'A').FirstOrDefault();

            Assert.AreEqual(item.PromotionApplied, true);
        }

        [Test]
        public void Buy_3_items_of_same_sku_for_fixed_price_3AsFor130_Return_230_for_5A()
        {
            _checkout.CalculateFinalCost(_cart);
            var item = _cart.GetItems().Where(x => x.SKUId == 'A').FirstOrDefault();
            Assert.AreEqual(item.TotalCost, 230);
        }

        [Test]
        [Description("Promotion2 : Buy SKU 1 & SKU 2 for a fixed price (C + D = 30)")]
        public void Buy_sku1_and_sku2_for_fixed_price_C_and_D_for_30_PromotionShouldNotApplied()
        {
            _checkout.CalculateFinalCost(_cart);
            var itemC = _cart.GetItems().Where(x => x.SKUId == 'C').FirstOrDefault();
            var itemD = _cart.GetItems().Where(x => x.SKUId == 'D').FirstOrDefault();

            Assert.AreEqual(itemD, null);
            Assert.AreEqual(itemC.PromotionApplied, false);
        }

    }
}
