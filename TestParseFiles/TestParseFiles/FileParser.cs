using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TestParseFiles
{
    class FileParser:IDisposable
    {
        string origionalfilecontent;
        string cleanfilecontent;
        FileReader rd;
        FileWriter Wr;
        string filepath;
        string filename;
        string filepathname;

        public FileParser(string filenmpath)
        {
            this.filepathname = filenmpath;
           
            rd = new FileReader(filepathname);
            Wr = new FileWriter(GetNameOfFileToWrite());
        }

        
        private string ParseFile(string ofc)
        {
            //ofc.Replace("([^\r])\n", "\1");
            string pattern = "([^\r])\n";
            string replacement = "";

            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(ofc, replacement);
            result = rgx.Replace(result, replacement);
            //string result=ofc.Replace("\n", "\r\n");


            return result;
        }


        public void CleanFile()
        {
            origionalfilecontent = rd.ReadFile();

            if (origionalfilecontent.Length > 0)
                cleanfilecontent = ParseFile(origionalfilecontent);
            else throw new Exception("The file is empty...");

            Wr.SaveFile(cleanfilecontent);
        }
        private string GetNameOfFileToWrite()
        {
            filename = GetFileName();
            filepath = GetFilePath();
            return filepath +"\\Cleaned_"+ filename;

        }
        private string GetFileName()
        {
            string temp = "";
            for (int i = filepathname.LastIndexOf('\\') + 1; i < filepathname.Length; i++)
            {
                temp += filepathname[i];
            }


            return temp;
        }

        private string GetFilePath()
        {
            string temp = "";

            int lios = filepathname.LastIndexOf('\\');
            for (int i =0; i < lios ; i++)
            {
                temp += filepathname[i];
            }


            return temp;
        }

        public void Dispose()
        {
            rd.Dispose();
            Wr.Dispose();


        }

    }
}
