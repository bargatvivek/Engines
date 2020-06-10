using System.Collections.Generic;


namespace BusinessRuleEngine.Core.Product
{
    class BookOrPhysicalProduct : ICommand
    {
        public List<string> Actions { private get; set; }
        private readonly ICommand command;

        public BookOrPhysicalProduct(ICommand command)
        {
            this.command = command;
            Actions = new List<string>();
            Actions.Add("generate a commission payment to the agent");

        }
        public List<string> execute()
        {
            Actions.AddRange(this.command.execute());
            return Actions;
        }
    }
}
