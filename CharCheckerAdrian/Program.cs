using System;
using System.IO;
using System.Collections.Generic;
using CharCheckerAdrian.logic;

namespace CharCheckerAdrian
{
    class Program
    {

        static void Main(string[] args)
        {
         
            Console.WriteLine(args);

            string input_file_name = args[0];
            string output_file_name = args[1];

            //string input_file_name = "2.txt";
            //string output_file_name = "wyn.txt";


            string config_file_name = "config.txt";

            if (args.Length == 3)
            {
                config_file_name = args[2];
            }

            if (File.Exists(output_file_name))
            {
                File.Delete(output_file_name);
            }


            StreamReader file_input;
            StreamWriter file_output;
            StreamReader file_config;

            try
            {
                file_input = new StreamReader(input_file_name);
                file_output = new StreamWriter(output_file_name);
                file_config = new StreamReader(config_file_name);

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found exit");
                return ;
            }
            analizator analiza = new analizator(/*file_input, file_output,*/ file_config);

            string line;
            //zczytanie pierwszej linii i przetworzenie do listy nazw i regexow
            line = file_input.ReadLine();
            analiza.InitTab(line);
            file_output.WriteLine(line);

            //droga linie idzie w calosci do wynikowego, bez zmian (nazwy po polskiemu)
            line = file_input.ReadLine();
            file_output.WriteLine(line);

            while ((line = file_input.ReadLine()) != null)
            {
                file_output.WriteLine( analiza.Analyze(line));
            }
			file_output.Flush();
			file_output.Close();

            return;
        }
    }
}
