//Método para deletar um arquivo local
private static void DeleteFile(string path)
{
    try
    {
        //Se existe o arquivo no local informado, deleta
        if(File.Exists(path))
        {
            File.Delete(path);
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
        }
    }
    catch (Exception ex)
    {        
        throw ex;
        //Sempre que possivel é bom no catch criar um log do erro e salvar o mesmo.
        Log.Error($"Erro ao deletar o arquivo, erro: {ex}");
    }
}