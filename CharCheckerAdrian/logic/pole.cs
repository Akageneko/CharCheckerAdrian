using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;



namespace CharCheckerAdrian.logic
{
    class Pole
    {
        private string name;
        private Regex reg;
        private bool empty = false;

        public Pole(string name, string formula)
        {
            this.name = name;
            if(formula.CompareTo(string.Empty) == 0)
            {
                empty = true;
            }
            else
            {
                reg = new Regex(formula);
            }
           
        }


        public string GetName()
        {
            return name;
        }

        public bool IfEmpty()
        {
            return empty;
        }


        public bool Compare(string s)
        {
            if (empty)
            {
                return (s.CompareTo(string.Empty) == 0);
            }
            else
            {
                return reg.IsMatch(s);
            }
        }

    }
}
