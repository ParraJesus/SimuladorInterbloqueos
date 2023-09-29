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

        private bool canRequest = true;

        private int currentResourceIndex = 0;

        #endregion

        #region Constructors

        public Process() { }

        public Process(string nombre, List<Resource> recursos)
        {
            this.name = nombre;
            this.resources = recursos;

            requestCycle();
        }

        #endregion

        public void requestCycle() 
        {

            while (canRequest)
            {

                requestResource();

                Thread.Sleep(2000);
            }
        }

        public void requestResource()
        {
            Resource resource = resources[currentResourceIndex];

            Debug.WriteLine("proceso " + name + " conectando al recurso:" + currentResourceIndex + 1);
        }


        #region GettersSetters

        public string Name { get => name; set => name = value; }
        public List<Resource> Resources { get => resources; set => resources = value; }
        public DateTime InitialTime { get => initialTime; set => initialTime = value; }
        public DateTime FinalTime { get => finalTime; set => finalTime = value; }

        #endregion
    }
}
