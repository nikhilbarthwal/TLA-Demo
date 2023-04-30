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

    class Program
    {
        public static void Main()
        {
            for (int i = 0; i < 10; i++)
            {
                ProgramBug.MainBug();
                // ProgramFixed.MainFixed();
                Console.WriteLine("____________________________________________");
            }
        }
    }
}
