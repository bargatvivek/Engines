using System.Collections.Generic;


namespace BusinessRuleEngine.Core.Membership
{
    internal class UpgradeMembership : ICommand
    {
        public List<string> execute()
        {
            return new List<string>() { "apply the upgrade" };
        }
    }
}
