using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private List<Resource> resources = new List<Resource>();

        #endregion

        #region Constructors

        public Process() {}

        public Process(string nombre, List<Resource> recursos)
        {
            this.name = nombre;
            this.resources = recursos;
        }

        #endregion

        #region GettersSetters

        public string Name { get => name; set => name = value; }
        public List<Resource> Resources { get => resources; set => resources = value; }

        #endregion
    }
}
