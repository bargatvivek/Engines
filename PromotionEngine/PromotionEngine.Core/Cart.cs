using PromotionEngine.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Core
{
    public class Cart : ICart
    {

        private IList<Item> cartItems = new List<Item>();
        private static Lazy<Cart> _cartInitializer = new Lazy<Cart>(() => new Cart());

        private Cart() { }

        public static Cart Instance
        {
            get
            {
                return _cartInitializer.Value;
            }
        }

        public void Add(Item item)
        {
            cartItems.Add(item);
        }

        public void Remove(Item item)
        {
            cartItems.Remove(item);
        }

        public IEnumerable<Item> GetItems()
        {
            return cartItems;
        }

    }
}
