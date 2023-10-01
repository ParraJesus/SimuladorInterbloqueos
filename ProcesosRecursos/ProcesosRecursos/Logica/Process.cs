using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProcesosRecursos.Logica
{

    /*
     * Hecho por 
     * Elkin Ariel Morillo Quenguan
     * Jesus Gabriel Parra Dugarte
     */

    internal class Process
    {
        #region Attributes

        private string name;

        private DateTime initialTime;
        private DateTime finalTime;

        private List<Resource> resources = new List<Resource>();

        private int currentResourceIndex = 0;

        #endregion

        #region Constructors

        public Process() { }

        public Process(string nombre)
        {
            this.name = nombre;
        }

        #endregion

        public void requestResource(Resource resource)
        {
            initialTime = DateTime.Now;

            Debug.WriteLine("Proceso " + Name + " intenta conectar al recurso: " + resource.Name + " en tiempo: " + initialTime);
            lock (resource)
            {
                Thread.Sleep(5000); // Simula el uso del recurso
                finalTime = DateTime.Now;
                Debug.WriteLine("Proceso " + Name + " ha terminado de usar el recurso: " + resource.Name + " en tiempo: " + finalTime);
            }
            Thread.Sleep(1000);
        }


        #region GettersSetters

        public string Name { get => name; set => name = value; }
        public List<Resource> Resources { get => resources; set => resources = value; }
        public DateTime InitialTime { get => initialTime; set => initialTime = value; }
        public DateTime FinalTime { get => finalTime; set => finalTime = value; }

        #endregion
    }
}
