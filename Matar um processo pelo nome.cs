private static void FinalizarProcesso()
{
    Process[] listProcesso = Process.GetProcesses();
    foreach (Process process in Process.GetProcessesByName("wkhtmltopdf"))
    {
        process.Kill();
    }
    System.Threading.Thread.Sleep(500);
}