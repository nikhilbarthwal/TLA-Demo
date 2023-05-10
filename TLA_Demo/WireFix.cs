namespace TLA_Demo
{
    class ProgramFixed
    {
        private static readonly Mutex WithdrawMutex = new Mutex();
        private static readonly Mutex DepositMutex = new Mutex();

        public static void main()
        {
            var jack = new Customer("Jack", 100);
            var jill = new Customer("Jill", 100);

            Thread t1 = new Thread(() => Transfer(jack, jill, 65));
            Thread t2 = new Thread(() => Transfer(jack, jill, 50));

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            Console.WriteLine($"Balance in Jack's account: {jack.Balance}");
            Console.WriteLine($"Balance in Jill's account: {jill.Balance}");
        }

        private static void Transfer(Customer sender, Customer receiver, int amount)
        {
            if (CheckAndWithdraw(sender, amount))
                Deposit(receiver, amount);
            else
                Console.WriteLine($"Insufficient amount in {sender.Name} account");
        }

        private static bool CheckAndWithdraw(Customer sender, int amount)
        {
            WithdrawMutex.WaitOne();
            bool b;
            if (sender.Balance < amount)
                b = false;
            else
            {
                sender.Withdraw(amount);
                b = true;
            }
            WithdrawMutex.ReleaseMutex();
            return b;
        }

        private static void Deposit(Customer receiver, int amount)
        {
            DepositMutex.WaitOne();
            receiver.Deposit(amount);
            DepositMutex.ReleaseMutex();
        }
    }
}
