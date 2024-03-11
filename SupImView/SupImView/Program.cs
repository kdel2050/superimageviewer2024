using System.Diagnostics;
using System.Xml.Serialization;



namespace SupImView
{
    
    internal static class Program
    {
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            try
            { 
            string[] img = Environment.GetCommandLineArgs();


            if (img != null && img[1].Length > 0)
            {
                Globals.img_path = img[1];
            }
            else
            {
                Globals.img_path = "";
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }

        }
    }
}