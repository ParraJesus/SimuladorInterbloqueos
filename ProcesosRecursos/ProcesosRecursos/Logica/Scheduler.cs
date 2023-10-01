using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosRecursos.Logica
{
    internal class Scheduler
    {
        #region Attributes

        private List<Resource> resources = new List<Resource>(); // Lista de procesadores con los que se van a trabajar
        private List<Process> processes = new List<Process>(); // Lista de procesos que se van a manejar
        //private List<int> processesIndex = new List<int>(); // Lista de índices que relacionan los procesadores con los procesos
        Dictionary<int, List<int>> processesIndex = new Dictionary<int, List<int>>();
        #endregion

        #region Constructors

        //Constructor para cuando se quieren asignar los procesos de manera automática
        public Scheduler(List<Resource> resources, List<Process> processes)
        {
            this.resources = resources;
            this.processes = processes;

            assignProcessesAutomatically();
        }

        //Constructor para cuando se quieren asignar los procesos de manera manual
        public Scheduler(List<Resource> resources, List<Process> processes, Dictionary<int, List<int>> processesIndex)
        {
            this.resources = resources;
            this.processes = processes;
            this.processesIndex = processesIndex;

            assignProcessesManually();
        }

        #endregion

        //Distribuir para cada procesador un número igual de procesos
        public void assignProcessesAutomatically()
        {
            int totalProcessors = resources.Count;                         //Total de procesadores
            int processesPerProcessor = processes.Count / totalProcessors;  //Total de Procesos para cada procesador
            int remainingProcesses = processes.Count % totalProcessors;     //Residuo, si lo hay

            int startIndex = 0;

            foreach (var resource in resources) //Para cada procesador dentro de la lista
            {
                int numProcesses = processesPerProcessor;

                if (remainingProcesses > 0)
                {
                    numProcesses++;
                    remainingProcesses--;   //Se deshace del residuo cuando el número de procesos es impar
                }

                List<Process> processesForProcessor = processes.GetRange(startIndex, numProcesses);
                resource.Processes = processesForProcessor;
                startIndex += numProcesses;
            }
        }

        //El usuario puede escoger a qué procesador va cada proceso
        /*public void assignProcessesManually()
        {
            for (int i = 0; i < processes.Count; i++)
            {
                int index = processesIndex[i];

                if (index >= 0 && index < resources.Count)
                {
                    if (processes[index].Resources == null)
                    {
                        processes[index].Resources = new List<Resource>();
                    }

                    resources[index].Processes.Add(processes[i]);
                }
                else
                {
                    Console.WriteLine("Error: El índice de procesador está fuera de rango para el proceso en la posición " + i);
                }
            }
        }*/

        public void assignProcessesManually()
        {
            foreach (var kvp in processesIndex)
            {
                int resourceIndex = kvp.Key;
                List<int> processIndices = kvp.Value;

                if (resourceIndex >= 0 && resourceIndex < resources.Count)
                {
                    if (processes[resourceIndex].Resources == null)
                    {
                        processes[resourceIndex].Resources = new List<Resource>();
                    }

                    foreach (int processIndex in processIndices)
                    {
                        if (processIndex >= 0 && processIndex < processes.Count)
                        {
                            resources[resourceIndex].Processes.Add(processes[processIndex]);
                        }
                        else
                        {
                            Console.WriteLine("Error: El índice de proceso está fuera de rango para el recurso en la posición " + resourceIndex);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error: El índice de recurso está fuera de rango en el diccionario de índices.");
                }
            }

            // Imprimir los procesos asignados a cada recurso
            foreach (var resource in resources)
            {
                Debug.WriteLine("Recurso " + resource.Name + ": " + string.Join(", ", resource.Processes.Select(p => p.Name)));
            }
        }


        //Imprime todos los procesos dentro de un procesador
        public void showProcesses(int resource)
        {
            if (resource < resources.Count)
            {
                Debug.WriteLine("Procesos emparejados al recurso " + resources[resource].Name + ": ");

                for (int i = 0; i < resources[resource].Processes.Count; i++)
                {
                    Debug.WriteLine(resources[resource].Processes[i].Name);
                }
            }
            else Debug.WriteLine("No existe tal recurso");
        }

        #region GettersSetters
        public Dictionary<int, List<int>> ProcessesIndex { get => processesIndex; set => processesIndex = value; }
        public List<Process> Processes { get => processes; set => processes = value; }
        public List<Resource> Resources { get => resources; set => resources = value; }

        #endregion
    }
}
