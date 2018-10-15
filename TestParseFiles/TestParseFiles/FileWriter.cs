using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace TestParseFiles
{
    class FileWriter:IDisposable
    {

        private StreamWriter Sw;
        private string Filepathname;

        public FileWriter(string filepath)
        {
            if (filepath.Length < 1)
                throw new Exception("Use must specify the file path");
            else { 
                Sw = new StreamWriter(filepath);
                Filepathname = filepath;
            }
        }

        public void  SaveFile(string data)
        {
            
            Sw.Write(data);
            Sw.Flush();
            Sw.Close();
            Sw = null;

            
        }

        public  void  Dispose()
        {
            if(Sw != null )
            { 
                Sw.Close();

                FileDeleter delete = new FileDeleter(Filepathname);
                delete.DeleteFile();
               
                    
            }

        }

    }
}
