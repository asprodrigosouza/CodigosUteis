//Método para matar um processo pelo nome
private static void FinalizarProcesso()
{
    //Lista os processos existentes
    Process[] listProcesso = Process.GetProcesses();
    foreach (Process process in Process.GetProcessesByName("wkhtmltopdf"))
    {
        //E a partir do nome selecionado no foreach, mata o mesmo.
        process.Kill();
    }
    //Aguarda um tempo determinado para executar novamente.
    System.Threading.Thread.Sleep(500);
}