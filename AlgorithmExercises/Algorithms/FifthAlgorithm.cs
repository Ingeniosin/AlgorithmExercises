using System;

namespace AlgorithmExercises.Algorithms {
   public class FifthAlgorithm : Algorithm{
      public FifthAlgorithm() : base("Quinto algoritmo.", "Algoritmo que permite calculcar el cuadrado de los primeros 100 numeros enteros.") {
      }

      protected override void Execute() {
         Console.WriteLine("{0} {1} {2}", "ENTERO".PadRight(15), "OPERACION".PadRight(15), "RESULTADO");
         for (var i = 1; i <= 100; i++) {
            Console.WriteLine("{0} {1} {2}", i.ToString().PadRight(15), (i+"^2").PadRight(15), i * i);
         }
      }
   }
}