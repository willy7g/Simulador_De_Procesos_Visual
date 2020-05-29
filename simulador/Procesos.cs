using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulador
{
    //Clase para crear lista de objetos de Procesos*********************************
    class Procesos
    {        
        public string nombre { get; set; }
        public string estado { get; set; }
        public string prioridad { get; set; }
        public string recurso { get; set; }
        public string tamaño { get; set; }
        public int tamañoProcesado { get; set; }//contar los mb terminados en marcos de pagina
        public int tamañoEnMemoria { get; set; }
        public string ProcesadorEnUso { get; set; }
        //Tamaño de Pagina = tamaño 
    }
}

/*
 foreach (string color in ListaColores)
{
Console.WriteLine ( color );
}
 *  ListaColores.Insert(2, "Blanco");
    Ordenar: ListaColores.Sort();
 *  Buscar:  Console.WriteLine(ListaColores.IndexOf("Amarillo"));
reemplazar:  ListaColores[ListaColores.IndexOf("Amarillo")] = "Negro";
 * 
 * ultimo:  LastIndexOf()
 *
 * Count
 * 
 * borrar:  ListaColores.Clear();
 * borrar:  TrimExcess()

 * 
 */