using System.Collections.Generic;


namespace BusinessRuleEngine.Core.Product
{
    public class PhysicalProduct : ICommand
    {
        public List<string> execute()
        {
            return new List<string>() { "generate a packing slip for shipping" };
        }
    }
}
