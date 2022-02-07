using System;

namespace AlgorithmExercises {
   public static class InputUtils {
      public static string GetText(string text, Func<string, bool> condition = null) {
         while(true) {
            Console.Write(text);
            var result = Console.ReadLine();
            if(condition == null || condition(result)) return result;
            Console.Write("Invalid input. Please try again.");
         }
      }

      public static int GetNumber(string text, Func<int, bool> condition = null) {
         while(true) {
            Console.Write(text);
            if(int.TryParse(Console.ReadLine(), out var number) && (condition == null || condition(number))) return number;
            Console.WriteLine("Invalid input. Try again.");
         }
      }

      public static double GetDouble(string text, Func<double, bool> condition = null) {
         while(true) {
            Console.Write(text);
            if(double.TryParse(Console.ReadLine(), out var number) && (condition == null || condition(number))) return number;
            Console.WriteLine("Invalid input. Try again.");
         }
      }

      public static double? GetDoubleNullable(string text, Func<double, bool> condition = null) {
         while(true) {
            Console.Write(text);
            var readLine = Console.ReadLine();
            if(readLine == null || readLine.Trim() == "") return null;
            if(double.TryParse(readLine, out var number) && (condition == null || condition(number))) return number;
            Console.WriteLine("Invalid input. Try again.");
         }
      }


      public static int? GetNumberNullable(string text, Func<int, bool> condition = null) {
         while(true) {
            Console.Write(text);
            var readLine = Console.ReadLine();
            if(readLine == null || readLine.Trim() == "") return null;
            if(int.TryParse(readLine, out var number) && (condition == null || condition(number))) return number;
            Console.WriteLine("Invalid input. Try again.");
         }
      }
   }
}