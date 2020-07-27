using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgramacion
{
    class Program
    {
        //ejercicio 2
        static List<Empleado> empleados = new List<Empleado> { };
        //ejercicio 4
        public delegate void objetoDelegado(List<Empleado> empleados);
        static objetoDelegado delegado;
        
        static public void OrdenarAscAntiguedad(List<Empleado> empleados)
        {
            var e = (from i in empleados
                     orderby i.AniosAntiguedad ascending
                     select i.AniosAntiguedad);
            foreach (var item in e)
            {
                Console.WriteLine(item);
            }
        }
        static public void OrdenarAscSalario(List<Empleado> empleados)
        {
            var e = (from i in empleados
                     orderby i.Salario ascending
                     select i.AniosAntiguedad);
            foreach (var item in e)
            {
                Console.WriteLine(item);
            }
        }
        static public void OrdenarAscapellidos(List<Empleado> empleados)
        {
            var e = (from i in empleados
                     orderby i.Apellidos ascending
                     select i.AniosAntiguedad);
            foreach (var item in e)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {

            //ejercicio 2
            empleados.Add(new Empleado("0", "Alvaro", "Gonzales", new DateTime(2015, 12, 31), 2100, "H"));
            empleados.Add(new Empleado("1", "Juan", "Gonzales", new DateTime(2018, 12, 31), 1100, "D"));
            empleados.Add(new Empleado("2", "Xiomara", "Gonzales", new DateTime(2019, 12, 31), 200, "H"));
            empleados.Add(new Empleado("3", "Leticia", "Gonzales", new DateTime(2013, 12, 31), 1400, "H"));
            empleados.Add(new Empleado("4", "Ruben", "Gonzales", new DateTime(2016, 12, 31), 2990, "H"));

            //ejercicio 3
            comparar = new Comparar(DelegadoOrdenarAscAntiguedad);
            comparar = new Comparar(DelegadoOrdenarAscapellidos);
            comparar = new Comparar(DelegadoOrdenarAscSalario);
            //ejercicio4
            delegado = new objetoDelegado(OrdenarAscAntiguedad);
            delegado = new objetoDelegado(OrdenarAscapellidos);
            delegado = new objetoDelegado(OrdenarAscSalario);

            //ejercicio5

            int opc, n;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu");
                Console.WriteLine("1. Adicionar Empleado");
                Console.WriteLine("2. Ordenar por antiguedad");
                Console.WriteLine("3. Ordenar por salario");
                Console.WriteLine("4. Ordenar por apellidos");
                Console.WriteLine("5. Imprimir lista de empleados");
                Console.WriteLine("0. Salir");
                Console.WriteLine("ELIJA UNA OPCION");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.WriteLine("codigo: ");
                        string codigo = Console.ReadLine();
                        Console.WriteLine("nombre: ");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("apellido: ");
                        string apellido = Console.ReadLine();
                        Console.WriteLine("fechaIngreso: ");
                        DateTime fechaingreso = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("salario: ");
                        double salario = Double.Parse(Console.ReadLine());
                        Console.WriteLine("estado: ");
                        string estado = Console.ReadLine();
                        empleados.Add(new Empleado(codigo, nombre, apellido, fechaingreso, salario, estado));
                        Console.WriteLine("Listo!");
                        break;
                    case 2:
                        delegado = new objetoDelegado(OrdenarAscAntiguedad);

                        break;
                    case 3:
                        delegado = new objetoDelegado(OrdenarAscapellidos);

                        break;
                    case 4:
                        delegado = new objetoDelegado(OrdenarAscSalario);

                        break;
                    case 5:
                        Console.WriteLine("Empleados....");
                        empleados.ForEach(s => s.Imprimir());
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Debe escojer una opcion");
                        break;
                }
            } while (opc != 0);

            //ejercicio 6
            var empleadosAntiguedadSup5 = empleados.Where(s => s.AniosAntiguedad > 5).Count();
            Console.WriteLine("cantidad de empleados antiguedad mayor a 5 años: " + empleadosAntiguedadSup5);
            var empleadoSueldoMayor = empleados.Max(s => s.Salario);
            Console.WriteLine("sueldo mayor: " + empleadoSueldoMayor);
            var empleadoSueldoMenor = empleados.Min(s => s.Salario);
            Console.WriteLine("sueldo mayor: " + empleadoSueldoMenor);
            Console.WriteLine("Empleados con antiguedad entre 10 y 15 anios...");
            var antiguedad10y15 = empleados.Where(s => s.AniosAntiguedad >= 10 && s.AniosAntiguedad <= 15).ToList();
            antiguedad10y15.ForEach(s => s.Imprimir());
            Console.WriteLine("Empleados ordenados por apellido desc...");
            var ordenarDescApellidos = from i in empleados
                                       orderby i.Apellidos descending
                                       select i.Apellidos;
            foreach (var item in ordenarDescApellidos)
            {
                Console.WriteLine(item);
            }

            //ejercicio 7
            Console.WriteLine();
            List<int> numeros = new List<int> { 1, 3, 6, 2, 7, 8, 11, 121 };
            var rango = numeros.Where(s => s >= 10 && s <= 100).ToList();
            rango.ForEach(s => Console.Write(s + " "));
            var mayora7 = numeros.Where(s => s > 7).ToList();
            mayora7.ForEach(s => Console.Write(s + " "));
            var distinto7y11 = numeros.Where(s => s != 7 && s != 11).ToList();
            distinto7y11.ForEach(s => Console.Write(s + " "));
            var primos = numeros.Where(s => s % 2 != 0 && s == 2 && s != Math.Sqrt(s) * Math.Sqrt(s)).ToList();
            primos.ForEach(s => Console.Write(s + " "));
        }
        ///ejercicio 3 completado
        public static void Ordenar(List<Empleado> A, Comparar c)
        {
            List < Empleado > empleados= c(A);
            empleados.ForEach(s => Console.WriteLine(s.AniosAntiguedad));
            
        }

        public delegate List<Empleado> Comparar(List<Empleado> x);
        static Comparar comparar;

        static public List<Empleado> DelegadoOrdenarAscAntiguedad(List<Empleado> empleados)
        {
            var empl = empleados.OrderBy(s => s.AniosAntiguedad).ToList();
            
            return empl;
        }
        static public List<Empleado>  DelegadoOrdenarAscSalario(List<Empleado> empleados)
        {
            var empl = empleados.OrderBy(s => s.Salario).ToList();

            return empl;
        }
        static public List<Empleado> DelegadoOrdenarAscapellidos(List<Empleado> empleados)
        {
            var empl = empleados.OrderBy(s => s.Apellidos).ToList();

            return empl;
        }
    }
}
