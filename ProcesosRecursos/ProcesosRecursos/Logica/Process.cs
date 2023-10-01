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
            Debug.WriteLine("Proceso " + Name + " intenta conectar al recurso: " + resource.Name);
            lock (resource)
            {
                Thread.Sleep(2000); // Simula el uso del recurso
                Debug.WriteLine("Proceso " + Name + " ha terminado de usar el recurso: " + resource.Name);
                
            }
            Thread.Sleep(2000);
        }


        #region GettersSetters

        public string Name { get => name; set => name = value; }
        public List<Resource> Resources { get => resources; set => resources = value; }
        public DateTime InitialTime { get => initialTime; set => initialTime = value; }
        public DateTime FinalTime { get => finalTime; set => finalTime = value; }

        #endregion
    }
}
