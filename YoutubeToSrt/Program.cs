using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var reg = new Regex("^(\\d+):(\\d+):(\\d+)");
            string[] lines = File.ReadAllLines(@"source.txt");
            using (StreamWriter fileWriter = new StreamWriter(@"target.txt"))
            {
                var lineNum = 1;
                fileWriter.WriteLine(Convert.ToString(lineNum));
                lineNum++; 

                for (var i = 0; i < lines.Length; i++)
                {
                    if (String.IsNullOrEmpty(lines[i])) 
                    {
                        fileWriter.WriteLine();
                        fileWriter.WriteLine(Convert.ToString(lineNum));
                        lineNum++; 
                    } 
                    else if(reg.IsMatch(lines[i])) // 0:00:18.980,0:00:21.460
                    {
                        fileWriter.WriteLine(lines[i].Replace(",", " --> "));
                    } 
                    else {
                        fileWriter.WriteLine(lines[i]);
                    }

                }
            }
        }
    }
}
