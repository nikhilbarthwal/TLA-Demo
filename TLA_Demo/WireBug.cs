using System;
using System.Reflection.Metadata;
using System.Threading;

namespace TLA_Demo
{
    class ProgramBug
    {
        // private static Mutex mutex = new Mutex();
        private static Mutex withdrawMutex = new Mutex();
        private static Mutex depositMutex = new Mutex();

        public static void main()
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
            // mutex.WaitOne();
            if (sender.Balance >= amount)
            {
                Withdraw(sender, amount);
                Deposit(receiver, amount);
            }
            else
                Console.WriteLine($"Insufficient amount in {sender.Name} account");
            // mutex.ReleaseMutex();
        }

        private static void Withdraw(Customer sender, int amount)
        {
            withdrawMutex.WaitOne();
            sender.Withdraw(amount);
            withdrawMutex.ReleaseMutex();
        }

        private static void Deposit(Customer receiver, int amount)
        {
            depositMutex.WaitOne();
            receiver.Deposit(amount);
            depositMutex.ReleaseMutex();
        }
    }
}
