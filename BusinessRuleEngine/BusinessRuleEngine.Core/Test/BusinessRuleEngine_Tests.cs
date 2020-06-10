
using BusinessRuleEngine.Core.Membership;
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

        [Test]
        public void If_payment_for_physical_product_generate_commission_and_packing_slip()
        {
            var payment = new Payment();
            List<string> actions = payment.PaymentFor(new BookOrPhysicalProduct(new PhysicalProduct()));

            CollectionAssert.AreEqual(actions, new List<string>()
            {
                "generate a commission payment to the agent",
                "generate a packing slip for shipping"
            });
        }

        [Test]
        public void If_payment_for_activate_membership_email_and_activate_membership()
        {
            var payment = new Payment();
            List<string> actions = payment.PaymentFor(new ActivateOrUpgradeMembership(new ActivateMembership()));

            CollectionAssert.AreEqual(actions, new List<string>()
            {
                "email the owner and inform them of the activation/upgrade",
                "activate the membership"
            });
        }

        [Test]
        public void If_payment_for_upgrade_membership_email_and_apply_upgrade()
        {
            var payment = new Payment();
            List<string> actions = payment.PaymentFor(new ActivateOrUpgradeMembership(new UpgradeMembership()));

            CollectionAssert.AreEqual(actions, new List<string>() { "email the owner and inform them of the activation/upgrade", "apply the upgrade" });
        }
    }
}
