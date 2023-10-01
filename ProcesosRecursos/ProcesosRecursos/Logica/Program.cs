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
                new Resource("a", true),
                new Resource("b", true),
                new Resource("c", true),
            };

            List<Process> processes = new List<Process>
            {
                new Process("1"),
                new Process("2"),
                new Process("3"),
                new Process("4"),
                new Process("5"),
                new Process("6"),
                new Process("7"),
                new Process("8")
            };

            Dictionary<int, List<int>> processesIndex = new Dictionary<int, List<int>>
            {
                { 0, new List<int> { 0,1 } },
                { 1, new List<int> { 0, 2, 3 } },
                { 2, new List<int> { 3, 4, 5 } }
            };

            Scheduler scheduler = new Scheduler(resources, processes, processesIndex);

            scheduler.showProcesses(0);
            scheduler.showProcesses(1);
            scheduler.showProcesses(2);

            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
        }
    }
}