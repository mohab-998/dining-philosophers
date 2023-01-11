namespace DiningPhilosophers
{
    static class Helpers
    {
        public static List<Philosopher> InitPhilosophers(int philosophersCount)
        {
            // Construct philosophers
            var philosophers = new List<Philosopher>(philosophersCount);
            for (int i = 0; i < philosophersCount; i++)
            {
                philosophers.Add(new Philosopher(philosophers, i, 5));
            }

            // Assign chopsticks to each philosopher
            foreach (var philosopher in philosophers)
            {
                // Assign left chopstick
                philosopher.LeftChopstick = philosopher.LeftPhilosopher.RightChopstick ?? new Chopstick();

                // Assign right chopstick
                philosopher.RightChopstick = philosopher.RightPhilosopher.LeftChopstick ?? new Chopstick();
            }

            return philosophers;
        }

    }
}