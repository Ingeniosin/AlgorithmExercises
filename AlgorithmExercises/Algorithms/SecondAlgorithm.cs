using System;

namespace AlgorithmExercises.Algorithms {
   public class SecondAlgorithm : Algorithm {
      public SecondAlgorithm() : base("Segundo algoritmo.", "Algoritmo que calcule y visualice las potencias de 2 entre 0 y 10.") {
      }

      protected override void Execute() {
         for (var i = 0; i <= 10; i++) {
            Console.WriteLine(" * 2 elevado a {0} es {1}.", i, Math.Pow(2, i));
         }
      }
   }
}