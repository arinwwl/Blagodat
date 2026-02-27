using Blagodat.Views;

namespace Blagodat;

internal static class Program
{
    public static string ConnectionString { get; private set; } = "Server=(localdb)\\MSSQLLocalDB;Database=demotest1;Trusted_Connection=True;";

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new LoginForm());
    }
}