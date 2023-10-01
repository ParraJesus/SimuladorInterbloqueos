using System.Diagnostics;

namespace ProcesosRecursos.Logica
{
    internal class Scheduler
    {
        #region Attributes

        private List<Resource> resources = new List<Resource>(); // Lista de recursos con los que se van a trabajar
        private List<Process> processes = new List<Process>(); // Lista de procesos que se van a manejar
        Dictionary<int, List<int>> processesIndex = new Dictionary<int, List<int>>(); // Mapeo de índices que relacionan los recursos con los procesos
        #endregion

        #region Constructors

        //Constructor para cuando se quieren asignar los procesos de manera automática
        public Scheduler(List<Resource> resources, List<Process> processes)
        {
            this.resources = resources;
            this.processes = processes;

            assignResourcessAutomatically();
        }

        //Constructor para cuando se quieren asignar los procesos de manera manual
        public Scheduler(List<Resource> resources, List<Process> processes, Dictionary<int, List<int>> processesIndex)
        {
            this.resources = resources;
            this.processes = processes;
            this.processesIndex = processesIndex;

            assignResourcesManually();
        }

        #endregion

        //Distribuir para cada recurso un número igual de procesos
        public void assignResourcessAutomatically()
        {
            int totalProcesses = processes.Count;
            int resourcesPerProcess = processes.Count/totalProcesses;
            int remainingResources = processes.Count % totalProcesses;

            int startIndex = 0;

            foreach (Process process in processes) 
            {
                int numResources = resourcesPerProcess;

                if (remainingResources > 0) 
                {
                    numResources++;
                    remainingResources--;
                }

                List<Resource> resourcesForProcess = resources.GetRange(startIndex, numResources);
                process.Resources = resourcesForProcess;
                startIndex += numResources;
            }

            // Imprimir los recursos asignados a cada proceso
            foreach (var process in processes)
            {
                Debug.WriteLine("El proceso " + process.Name + " está relacionado con los recursos: " + string.Join(", ", process.Resources.Select(r => r.Name)));
            }
        }

        //El usuario puede escoger a qué proceso va cada recurso
        public void assignResourcesManually()
        {
            foreach (var kvp in processesIndex)
            {
                int processIndex = kvp.Key;
                List<int> resourceIndexes = kvp.Value;

                if (processIndex >= 0 && processIndex < processes.Count)
                {
                    if (processes[processIndex].Resources == null)
                    {
                        processes[processIndex].Resources = new List<Resource>();
                    }

                    foreach (int resourceIndex in resourceIndexes)
                    {
                        if (resourceIndex >= 0 && resourceIndex < resources.Count)
                        {
                            processes[processIndex].Resources.Add(resources[resourceIndex]);
                        }
                        else
                        {
                            Console.WriteLine("Error: El índice del recurso está fuera de rango para el proceso en la posición " + processIndex);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error: El índice de proceso está fuera de rango en el diccionario de índices.");
                }
            }

            // Imprimir los recursos asignados a cada proceso
            foreach (var process in processes)
            {
                Debug.WriteLine("El proceso " + process.Name + " está relacionado con los recursos: " + string.Join(", ", process.Resources.Select(r => r.Name)));
            }
        }

        #region GettersSetters
        public Dictionary<int, List<int>> ProcessesIndex { get => processesIndex; set => processesIndex = value; }
        public List<Process> Processes { get => processes; set => processes = value; }
        public List<Resource> Resources { get => resources; set => resources = value; }

        #endregion
    }
}
