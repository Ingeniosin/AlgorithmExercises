using System;
using System.Threading;

namespace AlgorithmExercises {
   public abstract class Algorithm {
      public string Name { get; }
      public string Description { get; }
      private DateTime _startTime;

      protected Algorithm(string name, string description) {
         Name = name;
         Description = description;
      }

      public void Run() {
         _startTime = DateTime.Now;
         Console.WriteLine("Running {0}...", Name);
         Console.WriteLine("Description: {0}", Description);
         Console.WriteLine("Started at {0}", _startTime);
         Console.WriteLine();
         Execute();
         var finishTime = DateTime.Now;
         Thread.Sleep(1000);
         Console.WriteLine();
         Console.WriteLine("Finished at {0}", finishTime);
         Console.WriteLine("Elapsed time: {0:HH:mm:ss}", new DateTime(finishTime.Ticks - _startTime.Ticks));
         Console.WriteLine();
         Console.Write("Press any key to continue...");
         Console.ReadKey();
         
      }

      protected abstract void Execute();

   }
}