using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
static class PiCalculators
{
    /// <summary>Estimates the value of PI using a LINQ-based implementation.</summary>
    public static double SerialLinqPi(int numberOfSteps)
    {
        double stepSize = 1.0 / (double)numberOfSteps;
        return (from i in Enumerable.Range(0, numberOfSteps)
                let x = (i + 0.5) * stepSize
                select 4.0 / (1.0 + x * x)).Sum() * stepSize;
    }

    /// <summary>Estimates the value of PI using a PLINQ-based implementation.</summary>
    public static double ParallelLinqPi(int numberOfSteps)
    {
        double stepSize = 1.0 / (double)numberOfSteps;
        return (from i in ParallelEnumerable.Range(0, numberOfSteps)
                let x = (i + 0.5) * stepSize
                select 4.0 / (1.0 + x * x)).Sum() * stepSize;
    }

    /// <summary>Estimates the value of PI using a for loop.</summary>
    public static double SerialPi(int numberOfSteps)
    {
        double sum = 0.0;
        double stepSize = 1.0 / (double)numberOfSteps;
        for (int i = 0; i < numberOfSteps; i++)
        {
            double x = (i + 0.5) * stepSize;
            sum += 4.0 / (1.0 + x * x);
        }
        return stepSize * sum;
    }

    /// <summary>Estimates the value of PI using a Parallel.For.</summary>
    public static double ParallelPi(int numberOfSteps)
    {
        double sum = 0.0;
        double stepSize = 1.0 / (double)numberOfSteps;
        object monitor = new object();
        Parallel.For(0, numberOfSteps, () => 0.0, (i, state, local) =>
        {
            double x = (i + 0.5) * stepSize;
            return local + 4.0 / (1.0 + x * x);
        }, local => { lock (monitor) sum += local; });
        return stepSize * sum;
    }

    /// <summary>Estimates the value of PI using a Parallel.ForEach and a range partitioner.</summary>
    public static double ParallelPartitionerPi(int numberOfSteps)
    {
        double sum = 0.0;
        double stepSize = 1.0 / (double)numberOfSteps;
        object monitor = new object();
        Parallel.ForEach(Partitioner.Create(0, numberOfSteps), () => 0.0, (range, state, local) =>
        {
            for (int i = range.Item1; i < range.Item2; i++)
            {
                double x = (i + 0.5) * stepSize;
                local += 4.0 / (1.0 + x * x);
            }
            return local;
        }, local => { lock (monitor) sum += local; });
        return stepSize * sum;
    }
}