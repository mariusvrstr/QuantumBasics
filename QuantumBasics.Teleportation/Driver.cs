using System;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.QuantumBasics.Teleportation
{
    class Driver
    {
        static void Main(string[] args)
        {
            var trues = 0;
            var falses = 0;
            var equals = 0;
            var random = new Random();

            using (var qsim = new QuantumSimulator())
            {
                for (int k = 0; k < 1000; k++)
                {
                    var sentMessage = random.Next(2) == 0;

                    // What Jane received
                    var receivedMessage = Teleportation.Run(qsim, sentMessage).Result;

                    if (receivedMessage)
                        trues++;
                    else
                        falses++;

                    if (sentMessage == receivedMessage)
                        equals++;
                }
            }

            Console.WriteLine("==============================================");
            Console.WriteLine("========= Transportation Calculations ==========");
            Console.WriteLine("==============================================");
            Console.WriteLine();
            Console.WriteLine($"Number of TRUEs: {trues} Number of FALSEs: {falses}");
            Console.WriteLine($"How many received messages matched the sent: {equals}");

            Console.WriteLine($"Different values are sent and the same values are received.");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}