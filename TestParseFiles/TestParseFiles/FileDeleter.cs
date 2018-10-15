using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestParseFiles
{
    class FileDeleter
    {
        string Filenamepath;

        public FileDeleter( string filepath)
        {

            Filenamepath = filepath;



        }


        public void DeleteFile()
        {

            if (System.IO.File.Exists(Filenamepath))
            { 
                System.IO.File.Delete(Filenamepath);

            }

        }
    }
}
