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

        public void Withdraw(int amount)
        {
            Thread.Sleep(50);
            Balance -= amount;
        }

        public void Deposit(int amount)
        {
            Thread.Sleep(50);
            Balance += amount;
        }
    }

    class Program
    {
        public static void Main()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Attempt: {i}");
                ProgramBug.MainBug();
                // ProgramFixed.MainFixed();
                Console.WriteLine("____________________________________________");
            }
        }
    }
}
