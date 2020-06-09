using PromotionEngine.Core.Model;
using System.Collections.Generic;

namespace PromotionEngine.Core
{
    public interface ICart
    {
        void Add(Item item);
        void Remove(Item item);
        IEnumerable<Item> GetItems();
    }
}
