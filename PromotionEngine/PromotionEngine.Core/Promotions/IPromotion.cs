using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Core.Promotions
{
    interface IPromotion
    {
        string PromotionDetails { get; }
        void CalculateCost(ICart cart);
    }
}
