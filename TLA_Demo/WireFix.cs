namespace TLA_Demo
{
    class ProgramFixed
    {
        public static void MainFixed()
        {
            var jack = new Customer("Jack", 100);
            var jill = new Customer("Jill", 100);

            var transfer1 = Transfer(jack, jill, 65);
            var transfer2 = Transfer(jack, jill, 50);

            transfer1.Wait();
            transfer2.Wait();

            Console.WriteLine($"Balance ins Jack's account: {jack.Balance}");
            Console.WriteLine($"Balance ins Jill's account: {jill.Balance}");
        }

        private static async Task Transfer(Customer sender, Customer receiver, int amount) => await Task.Run( async () =>
        {
            if (Withdraw(sender, amount).Result)
                await Deposit(receiver, amount);
            else
                Console.WriteLine($"Insufficient amount in {sender.Name} account");
        });

        private static Task<bool> Withdraw(Customer sender, int amount) => Task.Run(() =>
        {
                if (sender.Balance < amount) return false;
                sender.Withdraw(amount);
                return true;
        });
        
        private static Task Deposit(Customer receiver, int amount) => Task.Run(() =>
        {
            var depositLock = new object();
            lock (depositLock)
            {
                receiver.Deposit(amount);
            }
        });
    }
}
