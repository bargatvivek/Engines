using System.Collections.Generic;


namespace BusinessRuleEngine.Core.Membership
{
    internal class ActivateMembership : ICommand
    {
        public List<string> execute()
        {
            return new List<string>() { "activate the membership" };
        }
    }
}
