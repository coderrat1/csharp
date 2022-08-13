using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Serialization_IO
{
    class File_IO
    {
        public static void Main()
        {
            //Reading data file from location 
            string path = @"C:\Users\Admin\Documents\ASP.Net Examples\TestFolder\TestFile.txt";

            //Reading Data from files -----

            //reading text file or data
            string data = File.ReadAllText(path);
            Console.WriteLine(data);

            //reads all contents of file line by line and stores in Array
            //string[] dataline = File.ReadAllLines(path);
            //Console.WriteLine(dataline[2]);

            //Writing data to files
            //string dataentered = "System.IO namespace is used for reading and" +
            //    " writing data to files and manipulate folders";
            //File.WriteAllText(path, dataentered);
            //Console.WriteLine("Updates text file : \n " + data);

            //Write all lines writes contents of string array line by line
            string[] writeline = { "C#", "ASP.Net", "Java", "ADO.Net", "HTML", "CSS", "JS" };
            File.WriteAllLines(path, writeline);
            //Console.WriteLine("Updates text file : \n " + data);

            //Appending data to existing text file in string variable
            string append_data = "Updating the text file using Append method";
            File.AppendAllText(path, append_data);

            //Appending data to existing text file in string array
            string[] stringdata = { "String Array", "Collections", "Genereic Non Generic" };
            File.AppendAllLines(path, stringdata);

            //MAnipulating Files using File class

            //Copy existing file to diffrent directory location file 

            string soursefilepath = @"C:\Users\Admin\Documents\ASP.Net Examples\TestFolder\TestFile.txt";
            string destination = @"C:\Users\Admin\Documents\ASP.Net Examples\CopyTestFolder\NewFileTest.txt";
            bool overwrite = true;
            File.Copy(soursefilepath, destination, overwrite);

            //Deleting file 
            File.Delete(soursefilepath);
            bool doesfileexists = File.Exists(soursefilepath);

            //GetCreationTime shows the time file was created
            DateTime filecreatedOn = File.GetCreationTime(path);

            //Using FileInfo classes functionalities

            //Instantiating FileInfo 
            string filepath = @"C:\Users\Admin\Documents\ASP.Net Examples\TestFolder\TestFileInfo.txt";
            FileInfo fileInfo = new FileInfo(filepath);

            //once the instance is created we can use properties and method to manipulate file
            string destinationfile = @"C:\Users\Admin\Documents\ASP.Net Examples\CopyTestFolder\NewFileInfo.txt";
            File.Copy(filepath, destinationfile);

            string fileExt = fileInfo.Extension;

            long length = fileInfo.Length;


            Console.ReadLine();
        }
    }
}