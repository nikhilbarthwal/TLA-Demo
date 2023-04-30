namespace TLA_Demo
{
    class ProgramBug
    {
        public static void MainBug()
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
            if (sender.Balance >= amount)
            {
                await Withdraw(sender, amount);
                await Deposit(receiver, amount);
            }
            else
                Console.WriteLine($"Insufficient amount in {sender.Name} account");
        });

        private static Task Withdraw(Customer sender, int amount) => Task.Run(() => sender.Withdraw(amount));

        private static Task Deposit(Customer receiver, int amount) => Task.Run(() => receiver.Deposit(amount));

    }
}
