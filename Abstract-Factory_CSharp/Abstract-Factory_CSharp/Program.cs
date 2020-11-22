using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_CSharp
{
    public interface IAbstractFactory
    {
        IAbstractProductoA CrearArticuloA();

        IAbstractProductoB CrearArticuloB();
    }

    
    class Fabricar1 : IAbstractFactory
    {
        public IAbstractProductoA CrearArticuloA()
        {
            return new FabricarArticuloA1();
        }

        public IAbstractProductoB CrearArticuloB()
        {
            return new FabricarArticuloB1();
        }
    }

    class Fabricar2 : IAbstractFactory
    {
        public IAbstractProductoA CrearArticuloA()
        {
            return new FabricarArticuloA2();
        }

        public IAbstractProductoB CrearArticuloB()
        {
            return new FabricarArticuloB2();
        }
    }

    public interface IAbstractProductoA
    {
        string MetodoArticuloA1();
    }

    
    class FabricarArticuloA1 : IAbstractProductoA
    {
        public string MetodoArticuloA1()
        {
            return "Este es un Metodo del Articulo  A1.";
        }
    }

    class FabricarArticuloA2 : IAbstractProductoA
    {
        public string MetodoArticuloA1()
        {
            return "Este es un Metodo del Articulo A2.";
        }
    }

    public interface IAbstractProductoB
    {
        
        string MetodoArticuloB();

       
        string OtroMetodoB(IAbstractProductoA collaborator);
    }

    class FabricarArticuloB1 : IAbstractProductoB
    {
        public string MetodoArticuloB()
        {
            return "Este es un Metodo del Articulo B1.";
        }

        
        public string OtroMetodoB(IAbstractProductoA collaborator)
        {
            var result = collaborator.MetodoArticuloA1();

            return $"Este es otro metodo del Articulo B1.";
        }
    }

    class FabricarArticuloB2 : IAbstractProductoB
    {
        public string MetodoArticuloB()
        {
            return "Este es un Metodo del Articulo B2.";
        }

        public string OtroMetodoB(IAbstractProductoA collaborator)
        {
            var result = collaborator.MetodoArticuloA1();

            return $"Este es otro metodo del Articulo B1.";
        }
    }

    class Client
    {
        public void Main()
        {
            
            Console.WriteLine("Cliente: Probando los Articulos A...");
            ClientMethod(new Fabricar1());
            Console.WriteLine();

            Console.WriteLine("Cliente: Probando los Articulos B...");
            ClientMethod(new Fabricar2());
        }

        public void ClientMethod(IAbstractFactory factory)
        {
            var ArticuloA = factory.CrearArticuloA();
            var ArticuloB = factory.CrearArticuloB();

            Console.WriteLine(ArticuloB.MetodoArticuloB());
            Console.WriteLine(ArticuloB.OtroMetodoB(ArticuloA));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------ Patron Abstract Factory --------------------------");
            Console.WriteLine("Presione Enter Para Continuar.....");
            Console.ReadKey();
            
            new Client().Main();

            Console.ReadKey();
        }
    }
}
