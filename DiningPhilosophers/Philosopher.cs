namespace DiningPhilosophers
{
    public class Philosopher
    {
        private readonly List<Philosopher> _allPhilosophers;
        private readonly int _index;
        public int NumEatCycles { get; private set; }
        public string Name { get; private set; }
        public State State { get; private set; }

        private int _timesEaten = 0;
        public Chopstick LeftChopstick { get; set; }
        public Chopstick RightChopstick { get; set; }

        public Philosopher LeftPhilosopher
        {
            get
            {
                if (_index == 0)
                    return _allPhilosophers[_allPhilosophers.Count - 1];
                else
                    return _allPhilosophers[_index - 1];
            }
        }

        public Philosopher RightPhilosopher
        {
            get
            {
                if (_index == _allPhilosophers.Count - 1)
                    return _allPhilosophers[0];
                else
                    return _allPhilosophers[_index + 1];
            }
        }

        public Philosopher(List<Philosopher> allPhilosophers, int index, int numEatingCycles)
        {
            _allPhilosophers = allPhilosophers;
            _index = index;

            this.NumEatCycles = numEatingCycles;
            this.Name = string.Format("Philosopher {0}", _index);
            this.State = State.Thinking;
        }

        public void EatAll()
        {
            // Cycle through thinking and eating until done eating.
            while (_timesEaten < NumEatCycles)
            {
                this.Think();
                if (this.PickUp())
                {
                    // Chopsticks acquired, eat up
                    this.Eat();

                    // Release chopsticks
                    this.PutDownLeft();
                    this.PutDownRight();
                }
            }
        }

        private bool PickUp()
        {
            // Monitor.Enter(LeftChopstick);
            // Monitor.Enter(RightChopstick);
            // return true;
            // Try to pick up the left chopstick
            if (Monitor.TryEnter(this.LeftChopstick))
            {
                Console.WriteLine(this.Name + " picks up left chopstick.");

                // Now try to pick up the right
                if (Monitor.TryEnter(this.RightChopstick))
                {
                    Console.WriteLine(this.Name + " picks up right chopstick.");

                    // Both chopsticks acquired, its now time to eat
                    return true;
                }
                else
                {
                    // Could not get the right chopstick, so put down the left
                    this.PutDownLeft();
                }
            }

            // Could not acquire chopsticks, try again
            return false;
        }

        private void Eat()
        {
            this.State = State.Eating;
            _timesEaten++;
            Console.WriteLine(this.Name + " eats.");
        }

        private void PutDownLeft()
        {
            Monitor.Exit(this.LeftChopstick);
            Console.WriteLine(this.Name + " puts down left chopstick.");
        }

        private void PutDownRight()
        {
            Monitor.Exit(this.RightChopstick);
            Console.WriteLine(this.Name + " puts down right chopstick.");
        }

        private void Think()
        {
            this.State = State.Thinking;
        }
    }
}