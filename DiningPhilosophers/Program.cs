//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;

class Program
{
    const int numberOfSteps = 1000_000_000;

    /// <summary>Main method to time various implementations of computing PI.</summary>
    static void Main()
    {
        Console.WriteLine("Function\t\t\t | Elapsed Time\t | Estimated Pi");
        Console.WriteLine("-----------------------------------------------------------------");

        Misc.Time(PiCalculators.SerialLinqPi, "Series Linq", numberOfSteps);
        Misc.Time(PiCalculators.ParallelLinqPi, "Parallel Linq", numberOfSteps);
        Misc.Time(PiCalculators.SerialPi, "Series For Loop", numberOfSteps);
        Misc.Time(PiCalculators.ParallelPi, "Parallel For Loop", numberOfSteps);
        Misc.Time(PiCalculators.ParallelPartitionerPi, "Parallel Partitioners", numberOfSteps);
    }


}