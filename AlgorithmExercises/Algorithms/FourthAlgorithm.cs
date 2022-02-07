using System;

namespace AlgorithmExercises.Algorithms {
   public class FourthAlgorithm : Algorithm {
      public FourthAlgorithm() : base("Cuarto algoritmo.", "Algoritmo que permita calcular 'X' segun una referencia exponencial.") {
      }

      protected override void Execute() {
         var number = InputUtils.GetDouble("Ingresa el numero base: ", x => x != 0);
         var exponent = InputUtils.GetNumberNullable("Ingresa el exponente: ");
         if(exponent == null) exponent = 0;
         var result = Pow(number, exponent.Value);
         Console.WriteLine();
         Console.WriteLine($"El resultado de {number}^{exponent} es: {result}");
      }

      private static double Pow(double number, int exponent) {
         double result;
         if(exponent < 0) {
            exponent *= -1;
            result = 1 / number;
            for(var i = 1; i < exponent; i++) result /= number;
         } else {
            result = number;
            for(var i = 1; i < exponent; i++) result *= number;
         }
         return result;
      }
   }
}