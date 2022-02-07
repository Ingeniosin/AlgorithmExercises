using System;
using System.Collections.Generic;
using System.Threading;
using AlgorithmExercises.Algorithms;

namespace AlgorithmExercises {
   internal static class Program {

      private static readonly List<Algorithm> Algorithms = new List<Algorithm> {
         new FirstAlgorithm(), 
         new SecondAlgorithm(),
         new ThirdAlgorithm(),
         new FourthAlgorithm(),
         new FifthAlgorithm(),
         new SixthAlgorithm()
      };
      
      /*
       * Problem Statement: Ejercicios de algoritmia.
       * Author: Juan David Campiño T.
       * Date: 07/02/2022.
       * Github: https://github.com/Ingeniosin/AlgorithmExercises
      */
      
      public static void Main(string[] args) {
         Console.WriteLine("¡Bienvenido!");
         Console.WriteLine("¡Se cargaron {0} algoritmos correctamente!", Algorithms.Count);
         Thread.Sleep(1500);
         Console.Clear();
         while(true) {
            ExecuteMenu();
         }
      }

      private static void ExecuteMenu() {
         Console.WriteLine("=============== Menu ===============");
         Console.WriteLine("Seleccione el algoritmo que desea ejecutar:");
         Console.WriteLine();
         for(var i = 1; i <= Algorithms.Count; i++) {
            var algorithm = Algorithms[i - 1];
            Console.WriteLine("{0}: {1}", i, algorithm.Name);
            Console.WriteLine("\t * {0}", Algorithms[i - 1].Description);
         }
         Console.WriteLine($"{Algorithms.Count + 1}. Salir.");
         Console.WriteLine();
         var number = InputUtils.GetNumber("Seleccione una opción: ", x => x > 0 && x <= Algorithms.Count + 1);
         if(number == Algorithms.Count + 1) {
            Console.WriteLine("Adios!");
            Thread.Sleep(800);
            Environment.Exit(0);
         } else {
            Console.Clear();
            Algorithms[number - 1].Run();
            Console.Clear();
         }
      }
   }
}