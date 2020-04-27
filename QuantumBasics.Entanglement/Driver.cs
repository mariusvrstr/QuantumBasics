using System;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.QuantumBasics.Entanglement
{
    class Driver
    {
        static void Main(string[] args)
        {
            var numberOfSameState = 0;
            var numberOfDifferentStates = 0;
            var numberOfOnes = 0;
            var numberOfZeros = 0;

            using (var qsim = new QuantumSimulator())
            {
                for (int k = 0; k < 1000; k++)
                {
                    // Compare two Qubits colapsed state after entanglement
                    var (qubitOneResult, qubitTwoResult) = Entanglement.Run(qsim).Result;

                    if (qubitOneResult == qubitTwoResult)
                        numberOfSameState++;
                    else
                        numberOfDifferentStates++;

                    if (qubitOneResult == Result.One)
                        numberOfOnes++;
                    else
                        numberOfZeros++;

                    if (qubitTwoResult == Result.One)
                        numberOfOnes++;
                    else
                        numberOfZeros++;
                }
            }

            Console.WriteLine("==============================================");
            Console.WriteLine("========= Entanglement Calculations ==========");
            Console.WriteLine("==============================================");
            Console.WriteLine();
            Console.WriteLine($"Number of ONES: {numberOfOnes}, Number of ZEROS: {numberOfZeros}");
            Console.WriteLine($"Entangled matched: {numberOfSameState} Entangled mismatched: {numberOfDifferentStates}");

            Console.WriteLine($"Even though the value might be different we expect ALL entagled Qubits to match.");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}