
namespace DiningPhilosophers
{
    public class Chopstick
    {
        private static int _count = 0;
        public string Name { get; private set; }

        public Chopstick()
        {
            _count++;
            this.Name = "Chopstick " + _count;
        }
    }
}