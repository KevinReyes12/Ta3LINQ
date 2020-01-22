using System;
using LinqTA3.Clases;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTA3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numeros = new List<int>();
            GenerarNumeros();
            
            foreach (var item in numeros)
            {
                Console.WriteLine(item);
            }
            //Mostrar por consola todos los números primos
            var primo = from num in numeros
                        where num!=0 && num%1 ==0 && num%num == 0
                      select num;
            foreach (var item in primo)
            {
                Console.WriteLine("Número primo: {0}",item);
            }

            //Mostrar por consola la suma de todos los elementos
            var suma = (from num in numeros
                        select num).Sum();
            Console.WriteLine("La suma de todos los elementos es: {0}",suma);

            //Generar una nueva lista con el cuadrado de los números.
            var cuadrados = (from num in numeros
                             select num*num).ToList();
            foreach (var item in cuadrados)
            {
                Console.WriteLine("Cuadrado del número: {0}", item);
            }

            //Generar una nueva lista con los números que no son primos.
            IEnumerable<int> noprimos = (from num in numeros
                                         where num != 0 && num % 1 != 0 && num % num != 0
                                         select num).ToList();

            //Obtener el promedio de todos los números mayores a 50.
            var promedio = (from num in numeros
                            where num>50
                            select num).Average();
            Console.WriteLine("Promedio: {0}",promedio);

            //Contar en la lista la cantidad de números pares e impares. Este problema debe
            //resolverse en una sentencia o en una sola consulta.
            var paresimpares = from num in numeros
                               where num%2==0 || num%2!=0
                               select num;
            Console.WriteLine("Numeros pares e impares {0}",paresimpares.Count());
            
            

            //Mostrar por consola cada elemento y la cantidad de veces que se repite en la lista
            var repite = from num in numeros
                         where num.Equals(num) 
                         select num;
            foreach (var item in numeros)
            {
                Console.WriteLine("Número: {0} y cantidad de veces repetido: {1}", item, repite.Count());
            }
            
            //Mostrar en consola los elementos de forma descendente.
            var descendente = from num in numeros
                              orderby num descending
                              select num;
            foreach (var item in descendente)
            {
                Console.WriteLine("Elementos en forma descendente: {0}",item);
            }

            //Mostrar en consola los números únicos (no se repiten)
            var unico = (from num in numeros
                          select num).Distinct();
            foreach (var item in unico)
            {
                Console.WriteLine("Numero único {0}", item);
            }
            //Sumar todos los números únicos de la lista.
            var sumaunico = (from num in numeros
                             select num).Distinct();
            Console.WriteLine("Suma de números únicos: {0}",sumaunico.Sum());

            

                void GenerarNumeros()//Metodo que genera los numros aleatorios en la lista
            {
                Random aleatorio = new Random();

                for (int i = 1; i <= 50; i++)
                {
                    int n = aleatorio.Next(99);
                    numeros.Add(n);
                }
            
            }
           
            //Insertar 10 instancias por cada una de las clases expuestas
            List<Factura> facturas = new List<Factura>()
            {
                new Factura(){Observacion="Plato",IDcliente=1,Fecha=DateTime.Parse("10/01/2009"),Total=1 },
                new Factura(){Observacion="Cuchara",IDcliente=2,Fecha=DateTime.Parse("10/05/2018") ,Total=5 },
                new Factura(){Observacion="Vaso",IDcliente=3,Fecha=DateTime.Parse("15/02/2012") ,Total=1 },
                new Factura(){Observacion="Plato",IDcliente=4,Fecha=DateTime.Parse("02/02/2019") ,Total=3 },
                new Factura(){Observacion="Plato",IDcliente=5,Fecha=DateTime.Parse("10/03/2019") ,Total=2 },
                new Factura(){Observacion="Mantel",IDcliente=5,Fecha=DateTime.Parse("22/04/2019") ,Total=7 },
                new Factura(){Observacion="Tenedor",IDcliente=1,Fecha=DateTime.Parse("10/05/2019") ,Total=8 },
                new Factura(){Observacion="Vaso",IDcliente=10,Fecha=DateTime.Parse("10/06/2019") ,Total=1 },
                new Factura(){Observacion="Plato",IDcliente=9,Fecha=DateTime.Parse("15/07/2019") ,Total=2 },
                new Factura(){Observacion="Plato",IDcliente=6,Fecha=DateTime.Parse("11/08/2019") ,Total=4 }
            };

            List<Cliente> clientes = new List<Cliente>() 
            {
                new Cliente(){ID=1,Nombre="Cliente 1"},
                new Cliente(){ID=2,Nombre="Cliente 2"},
                new Cliente(){ID=3,Nombre="Cliente 3"},
                new Cliente(){ID=4,Nombre="Cliente 4"},
                new Cliente(){ID=5,Nombre="Cliente 5"},
                new Cliente(){ID=6,Nombre="Cliente 6"},
                new Cliente(){ID=7,Nombre="Cliente 7"},
                new Cliente(){ID=8,Nombre="Cliente 8"},
                new Cliente(){ID=9,Nombre="Cliente 9"},
                new Cliente(){ID=10,Nombre="Cliente 10"}
            };
            Console.WriteLine("----------------------------------------");
            //consultas
            //Los 3 clientes con mayor monto de ventas.
            

            var resultado = from cli in clientes
                            join fac in facturas
                            on cli.ID equals fac.IDcliente
                            where fac.Total>fac.Total
                            select new
                            {
                                MayorVentas = fac.Total
                            };
            foreach (var item in resultado.ToList())
            {
                Console.WriteLine(item.MayorVentas);
            }

            //Los 3 clientes con menor monto en ventas.
            var resultado2 = from cli in clientes
                            join fac in facturas
                            on cli.ID equals fac.IDcliente
                            where fac.Total < fac.Total
                            select new
                            {
                                MenorVentas = fac.Total
                            };
            foreach (var item in resultado2.ToList())
            {
                Console.WriteLine(item.MenorVentas);
            }

            //El cliente con más ventas realizadas.
            var masventas = (from fac in facturas
                            join cli in clientes on
                            fac.IDcliente equals cli.ID
                            select fac.Total).Max();

            Console.WriteLine( masventas);
           

            //Cada cliente y su cantidad de ventas realizadas
            var consulta = from fac in facturas
                           join cli in clientes on
                           fac.IDcliente equals cli.ID
                           select new { nombre=cli.Nombre,tventas=fac.Total};
            foreach (var item in consulta)
            {
                Console.WriteLine("{0}",item.nombre+" Cantidad de ventas realizadas: "+ item.tventas);
            }

            //Las ventas realizadas en el año 2019
            var ventas = (from fac in facturas
                          where fac.Fecha.ToLongDateString().Contains("2019")
                         select fac.Total).Sum();

            Console.WriteLine("Ventas realizadas en 2019: {0}", ventas);
            

            //La venta más antigua
            var ventaAntigua = (from fac in facturas
                                select fac.Fecha).Min();
            Console.WriteLine("La venta mas antigua es: {0}",ventaAntigua);

            //Los clientes que tengan una venta cuya observación comience con "Plato"
            var ventaplato = from cli in clientes
                             join fac in facturas on
                             cli.ID equals fac.IDcliente
                             where fac.Observacion =="Plato"
                             select new 
                             {
                                 nombre=cli.Nombre, observacion=fac.Observacion
                             };
            foreach (var item in ventaplato)
            {
                Console.WriteLine("{0}",item.nombre," {1}",item.observacion);
            }

            Console.ReadKey();
        }
    }
}
