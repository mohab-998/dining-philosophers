using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

static class Misc
{
    /// <summary>Times the execution of a function and outputs both the elapsed time and the function's result.</summary>
    public static void Time(
        Func<int, double> estimatePi,
        string function, int numberOfSteps)
    {
        var sw = Stopwatch.StartNew();
        var pi = estimatePi(numberOfSteps);
        Console.WriteLine($"{function}\t\t\t | {sw.Elapsed}\t | {pi}");
    }
}