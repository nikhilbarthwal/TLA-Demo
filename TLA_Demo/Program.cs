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
            #if FIXED
                ProgramBug.Start();
            #else
                ProgramFixed.Start();
            #endif
        }
    }
}
