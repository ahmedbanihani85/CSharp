using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace TestParseFiles
{
    class FileReader:IDisposable
    {
        private StreamReader Sr;


        public FileReader(string filepath)
        {
            if (filepath.Length < 1)
                throw new Exception("Use must specify the file path"); 
            Sr = new StreamReader(filepath);
        }

        public string ReadFile()
        {
            
            string temp = Sr.ReadToEnd();
            Sr.Close();
            return temp;
        }

        public string Readline()
        {
            string temp= Sr.ReadLine();
            Sr.Close();
            return temp;
        }

        public void Dispose()
        {
            Sr.Close();
        }
    }
}
