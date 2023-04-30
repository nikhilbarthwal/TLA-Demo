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

            Console.WriteLine("First transfer " + (transfer1.Result ? "succeeded!" : "failed!"));
            Console.WriteLine("Second transfer " + (transfer2.Result ? "succeeded!" : "failed!"));

            Console.WriteLine($"Balance ins Jack's account: {jack.Balance}");
            Console.WriteLine($"Balance ins Jill's account: {jill.Balance}");
        }

        private static Task<bool> Transfer(Customer sender, Customer receiver, int amount) => Task.Run(() =>
        {
            var success = Task.Run(() =>
                {
                    if (sender.Balance >= amount)
                    {
                        sender.Withdraw(amount);
                        return true;
                    }
                    Console.WriteLine($"Insufficient amount in {sender.Name} account");
                    return false;
                }
            ).Result;

            if (success) Task.Run(() => receiver.Deposit(amount)).Wait();
            return success;
        });
    }
}