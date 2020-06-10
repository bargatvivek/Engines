
using BusinessRuleEngine.Core.Product;
using NUnit.Framework;
using System.Collections.Generic;

namespace BusinessRuleEngine.Core.Test
{
    class BusinessRuleEngine_Tests
    {
        [Test]
        public void If_payment_for_book_generate_commission_and_create_duplicate_slip()
        {
            var payment = new Payment();
            List<string> actions = payment.PaymentFor(new BookOrPhysicalProduct(new Book()));

            CollectionAssert.AreEqual(actions, new List<string>()
                                                    {
                                                      "generate a commission payment to the agent",
                                                       "create a duplicate packing slip for the royality department" 
                                                    });
        }
    }
}
