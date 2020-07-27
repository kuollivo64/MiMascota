using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgramacion
{
    //ejercicio 1
    class Empleado
    {
        private string codigo;
        private string nombre;
        private string apellidos;
        private DateTime fechaIngreso;
        private int aniosAntiguedad;
        private double salario;
        private string estado;

        public Empleado(string codigo, string nombre, string apellidos, DateTime fechaIngreso, double salario, string estado)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.FechaIngreso = fechaIngreso;
            this.AniosAntiguedad = calcularAntiguedad() ;
            this.Salario = salario;
            this.Estado = estado;
        }

        public int calcularAntiguedad()
        {
            return 2020 - fechaIngreso.Date.Year;
        }

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public int AniosAntiguedad { get => aniosAntiguedad; set => aniosAntiguedad = value; }
        public double Salario { get => salario; set => salario = value; }
        public string Estado { get => estado; set => estado = value; }

        public void Imprimir()
        {
            Console.WriteLine("codigo:"+codigo+"nombr:"+nombre+", apellido:"+apellidos+", fechaIngreso:"+fechaIngreso.Date.ToString("d")+"anios antiguedad:"+aniosAntiguedad+", salario:"+salario+", estado:"+estado);
        }
    }
}
