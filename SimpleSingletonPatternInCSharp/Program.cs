using System;
using System.IO;

namespace SimpleSingletonPatternInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciado");

            //Independente da quantidade de chamada sempre os arquivos terão mesmo inicio pois é o ID da Instancia singleton
            FileCreator.GetInstance().CreateFile(string.Concat(@"C:\temp\", Guid.NewGuid().ToString()));
            FileCreator.GetInstance().CreateFile(string.Concat(@"C:\temp\", Guid.NewGuid().ToString()));
            FileCreator.GetInstance().CreateFile(string.Concat(@"C:\temp\", Guid.NewGuid().ToString()));
            FileCreator.GetInstance().CreateFile(string.Concat(@"C:\temp\", Guid.NewGuid().ToString()));
            FileCreator.GetInstance().CreateFile(string.Concat(@"C:\temp\", Guid.NewGuid().ToString()));
            FileCreator.GetInstance().CreateFile(string.Concat(@"C:\temp\", Guid.NewGuid().ToString()));
            FileCreator.GetInstance().CreateFile(string.Concat(@"C:\temp\", Guid.NewGuid().ToString()));

            Console.WriteLine("Processamento finalizado");
            Console.ReadKey();
        }
    }

    public sealed class FileCreator
    {
        private static FileCreator _instance = null;
        private static string instanceId = string.Empty;
        private FileCreator(){}
        public static FileCreator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FileCreator();
                instanceId = Guid.NewGuid().ToString();
            }
            return _instance;
        }        
        public void CreateFile(string fullPath)
        {         
           File.Create(fullPath+"-------"+ instanceId);
        }
    }
}
