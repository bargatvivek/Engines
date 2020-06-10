using System.Collections.Generic;

namespace BusinessRuleEngine.Core.Product
{
    public class Book : ICommand
    {
        public List<string> execute()
        {
            return new List<string>() { "create a duplicate packing slip for the royality department" };
        }
    }
}
