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

    internal class Resource
    {
        #region Attributes

        private string name;
        private bool isExpropiable;      // Si es verdadero, el recurso es expropiable
        private bool isAvailable = true;       // Si es verdadero, el recurso está libre para ser usado
        private DateTime conexionTime;

        #endregion

        #region Constructors

        public Resource() { }

        public Resource(string name, bool isExpropiable)
        {
            this.name = name;
            this.isExpropiable = isExpropiable;
        }

        #endregion

        #region GettersSetters
        public string Name { get => name; set => name = value; }
        public bool IsExpropiable { get => isExpropiable; set => isExpropiable = value; }
        public bool IsAvailable { get => isAvailable; set => isAvailable = value; }
        public DateTime ConexionTime { get => conexionTime; set => conexionTime = value; }

        #endregion
    }
}
