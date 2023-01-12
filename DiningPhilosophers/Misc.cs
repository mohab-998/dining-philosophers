using System;
using System.Diagnostics;

static class Misc
{
    /// <summary>Times the execution of a function and outputs both the elapsed time and the function's result.</summary>
    public static void Time(
        Func<int, double> piCalculator,
        string functionName, int numberOfSteps)
    {
        var stopWatch = Stopwatch.StartNew();
        var pi = piCalculator(numberOfSteps);
        Console.WriteLine($"{functionName}\t | {stopWatch.Elapsed}\t | {pi}");
    }
}