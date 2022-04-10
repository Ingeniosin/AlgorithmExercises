using System.Collections.Generic;

namespace AlgorithmExercises.Algorithms {
   public class Cajero {
      public string Modelo { get; set; }
      public string Marca { get; set; }
      public string NumeroSerie { get; set; }
      public bool Disponible { get; set; }
      public List<string> Transacciones { get; set; }
      public Dictionary<int, int> CantidadBilletes { get; set; }
      public string Localizacion { get; set; }

      public Cajero(string modelo, string marca, string numeroSerie, bool disponible, List<string> transacciones, Dictionary<int, int> cantidadBilletes, string localizacion) {
         Modelo = modelo;
         Marca = marca;
         NumeroSerie = numeroSerie;
         Disponible = disponible;
         Transacciones = transacciones;
         CantidadBilletes = cantidadBilletes;
         Localizacion = localizacion;
      }
   }
}