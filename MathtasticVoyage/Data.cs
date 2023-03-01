using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathtasticVoyage
{
    public class Data
    {
        public static Queue<string> GetDataQueue()
        {
            string fileData = ReadFileText(@"C:\Users\POBOYINSAMSARA\Desktop\Coding\mathproblems.txt");

            string[] problems = fileData.Split("\r\n");
            Queue<string> problemsQueue = new Queue<string>();

            foreach (string problem in problems)
            {
                if (!string.IsNullOrWhiteSpace(problem))
                {
                    problemsQueue.Enqueue(problem);
                }
            }
            return problemsQueue;

        }//end function
        public static string[] GetData()
        {
            string fileData = ReadFileText(@"C:\Users\POBOYINSAMSARA\Desktop\Coding\mathproblems.txt");

            string[] problems = fileData.Split("\r\n");
            return problems;

        }//end function

        static string ReadFileText(string path)
        {
            string newString = "";

            //DECLARE STREAM READER
            StreamReader infile = new StreamReader($"{path}");

            //LOOP UNTIL END OF DATA IS REACHED
            while (infile.EndOfStream == false)
            {
                //READ A BYTE FROM THE FILE CAST TO A CHAR
                char data = (char)infile.Read();

                newString += data;
            }//end while

            //CLOSE THE FILE WHEN DONE
            infile.Close();

            return newString;

        }
    }
}

