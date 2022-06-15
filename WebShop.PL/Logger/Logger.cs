namespace WebShop.PL.Logger
{
    using System.IO;
    public class Logger
    {
        public static object Write(string path, string message, bool reWrite = false, bool withDate = true)
        {
            using(var sw = new StreamWriter(path, reWrite))
            {
                if (withDate)
                    sw.WriteLine($"{System.DateTime.Now} => {message}");
                else
                    sw.WriteLine(message);
                return "Succes!";
            }
        }
    }
}