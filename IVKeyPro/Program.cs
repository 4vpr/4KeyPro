namespace IVKeyPro;

static class Program
{
    [STAThread]
    public static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Window());
    }    
}