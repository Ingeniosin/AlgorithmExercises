using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmExercises.Algorithms {
   public class SixthAlgorithm : Algorithm{
      public SixthAlgorithm() : base("Sexto algoritmo.", "Algoritmo que lea dos polinomios con una unica variable o letra y los sume.") {
      }

      protected override void Execute() {
         var operation = SelectOperation();
         Console.WriteLine();
         var firstPolynomial = ReadPolynomial(1);
         var secondPolynomial = ReadPolynomial(2);
         Console.WriteLine();
         try {
            var result = firstPolynomial.Operate(secondPolynomial, operation);
            var resultString = string.Join("", result.Terms.Select(x => x.ToString()));
            if(resultString.StartsWith("+")) {
               resultString = resultString.Substring(1);
            }
            Console.WriteLine($"El resultado de la operacion {operation} es: {resultString}");   
         } catch(Exception e) {
            Console.WriteLine(e.Message);
         }
      }

      private static Polynomial ReadPolynomial(int id) {
         var readString = InputUtils.GetText($"Ingresa el polinomio [{id}] (Ej: 3x+2; 3x^3-2x^2+1; 3 o un formato similar): ", x => x != null).ToLower().Trim().Replace(" ", "").Replace("+", " +").Replace("-", " -").Split(' ').ToList();
         if(readString[0].Equals("")) readString.RemoveAt(0);
         List<Term> terms;
         try {
            terms = readString.Select(Term.GetInstance).ToList();
         } catch(Exception e) {
            Console.WriteLine($"El polinomio [{id}] no es valido. {e.Message}");
            return ReadPolynomial(id);
         }
         return new Polynomial(terms);
      }
      
      private Operation SelectOperation() {
         Console.WriteLine("Selector de operaciones.");
         Console.WriteLine("1. Sumar");
         Console.WriteLine("2. Restar");
         Console.WriteLine();
         return InputUtils.GetNumber("Ingresa la operacion que deseas realizar: ", x => x > 0 && x <=2)  == 1 ? Operation.Suma : Operation.Resta;
      }
   }
   
   public enum Operation {
      Suma = 1,
      Resta = -1,
   }

   public class Polynomial {
      public LinkedList<Term> Terms { get; }

      public Polynomial(List<Term> terms) {
         Terms = new LinkedList<Term>(terms.OrderByDescending(x => x.Exponent).ToList());
      }
      
      public override string ToString() {
         return string.Join(" + ", Terms.Select(x => x.ToString()));
      }

      public Polynomial Operate(Polynomial polynomial, Operation operation = Operation.Suma) {
         void AdjustPositions(Polynomial minor, Polynomial mayor) {
            var diff = mayor.Terms.Count - minor.Terms.Count;
            for(var i = 0; i < diff; i++) {
               var mayorItem = mayor.Terms.ElementAt(i);
               minor.Terms.AddFirst(new Term(0, mayorItem.Exponent, mayorItem.Variable));
            }
         }
         var mainIsMinor = Terms.Count < polynomial.Terms.Count;
         AdjustPositions(mainIsMinor ? this : polynomial, !mainIsMinor ? this : polynomial);
         var enumOne = Terms.GetEnumerator();
         var enumTwo = polynomial.Terms.GetEnumerator();
         var termsResult = new List<Term>();
         while(enumOne.MoveNext()) {
            enumTwo.MoveNext();
            var term1 = enumOne.Current;
            var term2 = enumTwo.Current;
            if(term1 == null || term2 == null || term1.Exponent != term2.Exponent || term1.Variable != term2.Variable) 
               throw new Exception("Los polinomios no tienen el mismo grado.");
            var i = (int) operation;
            var coeficient = term1.Coefficient + (i * term2.Coefficient);
            termsResult.Add(new Term(coeficient, term1.Exponent, term1.Variable != null || term2.Variable != null ? 'x' : (char?) null));
         }
         return new Polynomial(termsResult);
      }
   }

   public class Term {
      public int Coefficient { get; }
      public int Exponent { get; }
      public char? Variable { get; }

      public Term(int coefficient, int exponent, char? variable) {
         Coefficient = coefficient;
         Exponent = exponent;
         Variable = variable;
         if(Variable == null && exponent != 0 && coefficient != 0) {
            Coefficient = (int) Math.Pow(Coefficient, Exponent);
            Exponent = 0;
         }
      }

      public override string ToString() {
         var coef = Coefficient.ToString();
         return Coefficient == 0 ? "" : $"{(coef.StartsWith("-") ? "" : "+")}{coef}{Variable?.ToString() ?? ""}{(Exponent != 0 ? $"^{Exponent}" : "")}";
      }

      public static Term GetInstance(string term) { //FORMAT +5x^2 or +5x or +5 or +5^n
         var operation = term.Contains("-") ? -1 : 1;
         term = term.ToLower().Replace("-", "").Replace("+", "");
         var existsVariable = term.Contains("x");
         var existsPow = term.Contains("^");
         var existsCoefficient = !term.StartsWith("x");
         var splittedPow = term.Split('^');
         var pow = existsPow ? Convert.ToInt32(splittedPow[1]) : 0;
         var coefficient = existsCoefficient ? (existsPow ? Convert.ToInt32(splittedPow[0].Replace("x", "")) : Convert.ToInt32(term.Replace("x", ""))) : 1;
         return new Term(operation * coefficient, pow,existsVariable ? 'x' : (char?) null);
      }
   }

}