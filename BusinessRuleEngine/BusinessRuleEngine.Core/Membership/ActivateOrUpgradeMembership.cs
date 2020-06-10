using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.Core.Membership
{
    public class ActivateOrUpgradeMembership : ICommand
    {
        public List<string> Actions { private get; set; }
        private readonly ICommand command;

        public ActivateOrUpgradeMembership(ICommand command)
        {
            this.command = command;
            Actions = new List<string>();
            Actions.Add("email the owner and inform them of the activation/upgrade");
        }

        public List<string> execute()
        {
            Actions.AddRange(this.command.execute());
            return Actions;
        }
    }
}
