using System;

namespace AlgorithmExercises.Algorithms {
   public class FirstAlgorithm : Algorithm {
      public FirstAlgorithm() : base("Primer algoritmo.", "Algoritmo que lee un valor entero, lo dobla, lo multiplica por 25 y muestra el resultado.") {
      }

      protected override void Execute() {
         var number = InputUtils.GetNumber("Ingresa un numero entero: ");
         var result = number * 2 * 25;
         Console.WriteLine($"Ejecución: {number} * 2 * 25 = {result}");
      }
   }
}