using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace CharCheckerAdrian.logic
{
    class analizator
    {
    //    StreamReader f_input;
    //    StreamWriter f_output;
        StreamReader f_config;
        struktura strukt;

        struktura configuracyjna;
        
        private void ReadConfig()
        {
            configuracyjna = new struktura();
            string line;
            string[] line_elements;
            
            while((line = f_config.ReadLine()) != null)
            {
                line_elements = line.Split("\t");
                Console.WriteLine("{0} : {1}",line_elements[0], line_elements[1]);
                configuracyjna.AddPole(line_elements[0], line_elements[1]);
            }

        }
        
        
        public analizator(/*StreamReader f_input, StreamWriter f_output,*/ StreamReader f_config)
        {
           // this.f_input = f_input;
           // this.f_output = f_output;
            this.f_config = f_config;

            ReadConfig();
        }

        public void InitTab(string line)
        {
            strukt = new struktura();
            string[] line_elements;
            Pole pole;

            line_elements = line.Split("\t");
            foreach (string s in line_elements)
            {
                pole = configuracyjna.Find(s);
                strukt.AddPole(pole);
            }

        }

        public string Analyze(string line)
        {
            string output = string.Empty;
            List<string> line_elements = line.Split("\t").ToList();
            int last_not_empty = strukt.FindLastNotEmpty();
            int i = 0;
            while(i<line_elements.Count)
            {
                if (!strukt.CheckPole(line_elements[i],i))
                {
                    int j = i + 1;
                    while(j < line_elements.Count && !strukt.CheckPole(line_elements[j],i))
                    {
                        j++;
                    }
                    if(j == line_elements.Count)
                    {
                        //co w przypadku jak nie znaleziono do konca linii tego co mialo byc tu
                        if (j > strukt.GetLength())
                        {
                            i = last_not_empty + 1;
                        }
                         
                    }
                    //znaleznono pasujący element
                    for(int k = i; k < j; k++)
                    {
                        line_elements[i - 1] += " " + line_elements[k];
                    }
                    for (int k = i; k < j; k++)
                    {
                        line_elements.RemoveAt(i);
                    }

                }
                i++;
            }

            for(i = 0; i < strukt.GetLength(); i++)
            {
                if(i < line_elements.Count)
                {
                    output +="\t" + line_elements[i];
                }
                else
                {
                    output += "\t" + string.Empty;
                }
            }

            output = output.Substring(1);

            return output;
        }


    }
}
