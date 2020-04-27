using System;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.QuantumBasics.Superposition
{
    class Driver
    {
        static void Main(string[] args)
        {
            int ones = 0;
            int zeros = 0;

            // Show statistical propability of Superposition
            using (var qsim = new QuantumSimulator())
            {
                for (int k = 0; k < 1000; k++)
                {
                    var result =   Superposition.Run(qsim).Result;

                    if (result == Result.One)
                        ones++;
                    else
                        zeros++;
                }
            }

            Console.WriteLine("==============================================");
            Console.WriteLine("======== Superposition Calculations ==========");
            Console.WriteLine("==============================================");
            Console.WriteLine();
            Console.WriteLine($"Number of ONES: {ones}, Number of ZEROS: {zeros}");
            Console.WriteLine($"With a 50% propability they should have a simular distribution");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}