using System.Collections.Generic;

namespace BusinessRuleEngine.Core
{
    public class Payment
    {
        public List<string> PaymentFor(ICommand command)
        {
            return command.execute();
        }
    }
}
