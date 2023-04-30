namespace TLA_Demo
{
    class Customer
    {
        public string Name { get; private set; }
        public int Balance { get; private set; }

        public Customer(string name, int startingBalance)
        {
            Name = name;
            Balance = startingBalance;
        }

        public Task Withdraw(int amount) => Task.Run( () => Balance -= amount);
        public Task Deposit(int amount) => Task.Run( () => Balance += amount);
    }
}
