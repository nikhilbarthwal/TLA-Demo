using System;
using System.Reflection.Metadata;
using System.Threading;

namespace TLA_Demo
{
    class ProgramBug
    {
        private static readonly Mutex CheckMutex = new Mutex();
        private static readonly Mutex WithdrawMutex = new Mutex();
        private static readonly Mutex DepositMutex = new Mutex();

        public static void Start()
        {
            var jack = new Customer("Jack", 100);
            var jill = new Customer("Jill", 100);

            Thread t1 = new Thread(() => Transfer(jack, jill, 65));
            Thread t2 = new Thread(() => Transfer(jack, jill, 50));

            t1.Start(); t2.Start();
            t1.Join(); t2.Join();

            Console.WriteLine($"Balance in Jack's account: {jack.Balance}");
            Console.WriteLine($"Balance in Jill's account: {jill.Balance}");
        }

        private static void Transfer(Customer sender, Customer receiver, int amount)
        {
            if (Check(sender, amount))
            {
                Withdraw(sender, amount);
                Deposit(receiver, amount);
            }
            else
                Console.WriteLine($"Insufficient amount in {sender.Name} account");
        }

        private static bool Check(Customer sender, int amount)
        {
            CheckMutex.WaitOne();
            bool b = sender.Balance >= amount;
            CheckMutex.ReleaseMutex();
            return b;
        }

        private static void Withdraw(Customer sender, int amount)
        {
            WithdrawMutex.WaitOne();
            sender.Withdraw(amount);
            WithdrawMutex.ReleaseMutex();
        }

        private static void Deposit(Customer receiver, int amount)
        {
            DepositMutex.WaitOne();
            receiver.Deposit(amount);
            DepositMutex.ReleaseMutex();
        }
    }
}
