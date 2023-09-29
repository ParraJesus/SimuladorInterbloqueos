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
            List<Resource> resources = new List<Resource>();

            resources.Add(new Resource("a", true));
            resources.Add(new Resource("b", true));

            Process process = new Process("maquina", resources);

            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
        }
    }
}