using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_CSharp
{
    public class Persona
    {
        public int Edad;
        public DateTime FechaN;
        public string Nombre;
        public IdInfo IdInfo;

        public Persona Copiar()
        {
            return (Persona)this.MemberwiseClone();
        }

        public Persona Clonar()
        {
            Persona clone = (Persona)this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Nombre = String.Copy(Nombre);
            return clone;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------- Prototype ------------------------");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadKey();

            Persona p1 = new Persona();
            p1.Edad = 19;
            p1.FechaN = Convert.ToDateTime("2001-04-03");
            p1.Nombre = "Isaac";
            p1.IdInfo = new IdInfo(666);

            
            Persona p2 = p1.Copiar();
            
            Persona p3 = p1.Clonar();

            
            Console.WriteLine("Valores Originales de p1, p2, p3:");
            Console.WriteLine("   p1: ");
            DisplayValues(p1);
            Console.WriteLine("   p2: ");
            DisplayValues(p2);
            Console.WriteLine("   p3: ");
            DisplayValues(p3);

            
            p1.Edad = 7;
            p1.FechaN = Convert.ToDateTime("2013-04-05");
            p1.Nombre = "Isaias";
            p1.IdInfo.IdNumber = 7878;

            Console.WriteLine("\nValores de p1, p2 and p3 despues de cambiar a p1:");
            Console.WriteLine("  Instancia de Valores p1: ");
            DisplayValues(p1);
            Console.WriteLine("   Instancia de Valores p2:");
            DisplayValues(p2);
            Console.WriteLine("   Instancia de Valores p3:");
            DisplayValues(p3);
        }

        public static void DisplayValues(Persona p)
        {
            
            Console.WriteLine("      Nombre: {0:s}, Edad: {1:d}, FechaNacimiento: {2:MM/dd/yy}",
                p.Nombre, p.Edad, p.FechaN);
            Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
        }
    }
}
