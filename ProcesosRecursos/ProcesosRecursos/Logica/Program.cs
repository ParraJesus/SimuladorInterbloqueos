using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Threading;

namespace ProcesosRecursos.Logica
{

    /*
     * Hecho por 
     * Elkin Ariel Morillo Quenguan
     * Jesus Gabriel Parra Dugarte
     */

    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            List<Resource> resources = new List<Resource>
            {
                new Resource("A", true),
                new Resource("B", true),
                new Resource("C", true)
            };

            List<Process> processes = new List<Process>
            {
                new Process("P0"),
                new Process("P1"),
            };

            Dictionary<int, List<int>> processesIndex = new Dictionary<int, List<int>>
            {
                { 0, new List<int> { 0,1,2 } },
                { 1, new List<int> { 0,1,2 } }
            };

            Scheduler scheduler = new Scheduler(resources, processes, processesIndex);

            Thread thread = new Thread(() => 
            {
                foreach (Resource resource in processes[0].Resources)
                {
                    processes[0].requestResource(resource);
                }
            });


            Thread thread1 = new Thread(() => 
            {
                foreach (Resource resource in processes[1].Resources)
                {
                    processes[1].requestResource(resource);
                }
            });

            thread.Start();
            thread1.Start();

            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
        }
    }
}