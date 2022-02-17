private static void DeleteFile(string path)
{
    try
    {
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
    }
}