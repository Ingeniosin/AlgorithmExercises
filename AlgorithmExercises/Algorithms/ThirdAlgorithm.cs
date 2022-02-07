using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmExercises.Algorithms {
   public class ThirdAlgorithm : Algorithm {
      public const int Iva = 12;

      //Corrección: el precio bruto es su valor real. En dicha cantidad, no se incluyen ni impuestos ni deducciones o descuentos; El valor + IVA seria tomado como el precio neto.
      public ThirdAlgorithm() : base("Tercer algoritmo.", "Algoritmo que permita emitir la factura correspondiente a la compra de un articulo determinado del que se adquieren una o varias unidades, el IVA a aplicar es del 12% y si el precio (_¿bruto?_) neto (precio de venta + IVA) es mayor de 50.000 pesetas, se aplica un descuento del 5%.") {
      }

      protected override void Execute() {
         var cantidadProductos = InputUtils.GetNumber("Ingrese la cantidad de productos: ", x => x > 0);
         var productos = new List<Producto>();
         for(var i = 0; i < cantidadProductos; i++) {
            Console.WriteLine();
            var nombre = InputUtils.GetText($"Ingresa el nombre del producto [{i+1}]: ", x => x != null);
            productos.Add(new Producto(nombre, InputUtils.GetNumber($"Ingresa el precio del '{nombre}': ", x => x > 0), InputUtils.GetNumber($"Ingresa la cantidad de '{nombre}': ", x => x > 0)));
         }
         Console.WriteLine();
         var totalNeto = productos.Sum(x => x.GetPrecioNeto());
         var totalBruto = productos.Sum(x => x.GetPrecioBruto());
         var existeDescuento = totalNeto > 50000;
         var valorFinal = existeDescuento ? totalNeto * 0.95 : totalNeto;
         Console.WriteLine();                                          
         Console.WriteLine("=================================================================================");
         Console.WriteLine("                                   MINI MARKET                                   ");
         Console.WriteLine();
         Console.WriteLine(" * UUID: {0}", Guid.NewGuid());
         Console.WriteLine(" * Fecha: {0}", DateTime.Now);
         Console.WriteLine(" * Sucursal: {0}", "PASTO");
         Console.WriteLine(" * Cliente: {0}", "Anonimo");
         Console.WriteLine(" * Cajero: {0}", "Automatico");
         Console.WriteLine(" * IVA: {0}%", Iva);
         Console.WriteLine();
         Console.WriteLine("{0} {1} {2} {3} {4}", "PRODUCTO".PadRight(15), "CANTIDAD".PadRight(10), "PRECIO UNITARIO".PadRight(15), "PRECIO BRUTO".PadRight(15), "PRECIO NETO (Con IVA)".PadRight(15));
         productos.ForEach(x => Console.WriteLine("{0} {1} {2} {3} {4}", x.Nombre.PadRight(15), x.Cantidad.ToString().PadRight(10), $"{x.Valor:C}".PadRight(15), $"{x.GetPrecioBruto():C}".PadRight(15), $"{x.GetPrecioNeto():C}".PadRight(15)));
         Console.WriteLine("{0} {1} {2}", "".PadRight(42), $"{totalBruto:C}".PadRight(15), $"{totalNeto:C}");
         if(existeDescuento) {
            Console.WriteLine("!Tu descuento fue del 5%¡");
            Console.WriteLine("PRECIO SIN DESCUENTO: " + $"{totalNeto:C}");
         }
         Console.WriteLine();
         Console.WriteLine("TOTAL: " + $"{valorFinal:C}");
         Console.WriteLine("=================================================================================");
      }
   }

   public class Producto {
      public readonly string Nombre;
      public readonly long Valor;
      public readonly int Cantidad;
      
      public Producto(string nombre, long valor, int cantidad) {
         Nombre = nombre;
         Valor = valor;
         Cantidad = cantidad;
      }

      public long GetPrecioBruto() => Valor * Cantidad;
      public long GetPrecioNeto() => GetPrecioBruto() * (100 + ThirdAlgorithm.Iva) / 100;
   }
   
}