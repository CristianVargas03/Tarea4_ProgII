using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_CSharp
{
    public interface IObjeto
    {
        void Request(); 

    class RealObjeto : IObjeto
        {
            public void Request()
            {
                Console.WriteLine("RealObjeto: Esperando La Respuesta...");
            }
        }

        class Proxy : IObjeto
        {
            private RealObjeto _realObjeto;

            public Proxy(RealObjeto realObjeto)
            {
                this._realObjeto = realObjeto;
            }


            public void Request()
            {
                if (this.CheckAccess())
                {
                    this._realObjeto.Request();

                    this.LogAccess();
                }
            }

            public bool CheckAccess()
            {

                Console.WriteLine("Proxy: Chequeando el Acceso.");

                return true;
            }

            public void LogAccess()
            {
                Console.WriteLine("Proxy: Logeando...");
            }
        }

        public class Client
        {
            public void ClientCode(IObjeto subject)
            {
                subject.Request();
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Client client = new Client();

                Console.WriteLine("----------------- Proxy --------------------");
                Console.WriteLine("Presiona Enter Para Continuar...");
                Console.ReadKey();

                Console.WriteLine("Client: Ejecutando el Codigo en el Objeto...");
                RealObjeto realObjeto = new RealObjeto();
                client.ClientCode(realObjeto);

                Console.WriteLine();

                Console.WriteLine("Client: Ejecutando el Codigo en el Proxy...");
                Proxy proxy = new Proxy(realObjeto);
                client.ClientCode(proxy);
            }
        }
    }
}