using System.Collections.Generic;


namespace BusinessRuleEngine.Core
{
    public interface ICommand
    {
        List<string> execute();
    }
}
