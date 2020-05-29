using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulador
{
    //Clase para crear lista de objetos de Procesadores*********************************
    class Procesadores
    {
        public string nombre { get; set; }
        public string hilos { get; set; }
        public string estado { get; set;}
        public int vida { get; set; }
        public int EnCIclo { get; set; }//1= en el ciclo esperando que los demas terminen     0 = termine mi ciclo puedo incrementar cr

        public string ejecutandoProceso { get; set; }
    }
}
