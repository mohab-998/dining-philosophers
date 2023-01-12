//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;

class Program
{
    const int numberOfSteps = 1000_000;

    /// <summary>Main method to time various implementations of computing PI.</summary>
    static void Main()
    {
        Console.WriteLine("Function\t | Elapsed Time\t\t | Estimated Pi");
        Console.WriteLine(new string('-', 60));

        Misc.Time(PiCalculators.SerialLinqPi, "S-Linq".PadRight(10), numberOfSteps);
        Misc.Time(PiCalculators.ParallelLinqPi, "P-Linq".PadRight(10), numberOfSteps);
        Misc.Time(PiCalculators.SerialPi, "S-For Loop", numberOfSteps);
        Misc.Time(PiCalculators.ParallelPi, "P-For Loop", numberOfSteps);
        Misc.Time(PiCalculators.ParallelPartitionerPi, "P-Partitioners", numberOfSteps);
    }


}