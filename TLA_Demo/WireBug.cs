using System;
using System.Threading;

namespace TLA_Demo
{
    class ProgramBug
    {
        public static void MainBug()
        {
            var jack = new Customer("Jack", 100);
            var jill = new Customer("Jill", 100);

            Thread t1 = new Thread(() => Transfer(jack, jill, 65));
            Thread t2 = new Thread(() => Transfer(jack, jill, 50));

            t1.Start(); t2.Start();
            Thread.Sleep(1000);
            t1.Join(); t2.Join();

            Console.WriteLine($"Balance in Jack's account: {jack.Balance}");
            Console.WriteLine($"Balance in Jill's account: {jill.Balance}");
        }

        private static void Transfer(Customer sender, Customer receiver, int amount)
        {
            if (sender.Balance >= amount)
            {
                Thread withdraw = new Thread(() => Withdraw(sender, amount));
                withdraw.Start();withdraw.Join();
                Thread deposit = new Thread(() => Deposit(receiver, amount));
                deposit.Start();deposit.Join();
            }
            else
                Console.WriteLine($"Insufficient amount in {sender.Name} account");
        }

        private static void Withdraw(Customer sender, int amount) => sender.Withdraw(amount);

        private static void Deposit(Customer receiver, int amount) => receiver.Deposit(amount);
    }
}
