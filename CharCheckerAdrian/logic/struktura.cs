using System;
using System.Collections.Generic;
using System.Text;

namespace CharCheckerAdrian.logic
{
    
    class struktura
    {

        private List<Pole> lista;

        public int ListaLength { 
            get{
                return lista.Count;
            }
        }


        public struktura()
        {
            lista = new List<Pole>();

        }
        public void AddPole(string name, string formula)
        {
            Pole pole = new Pole(name, formula);
            lista.Add(pole);
        }

        public void AddPole(Pole pole)
        {
            lista.Add(pole);
        }
        
        public bool CheckPole(string s, int index)
        {
            if (lista.Count > index)
                return lista[index].Compare(s);
            else
                return false;
        }

        public Pole Find(string name)
        {
            foreach(Pole pole in lista)
            {
                if (pole.GetName().CompareTo(name) == 0)
                {
                    return pole;
                }
            }
            return null;
        }

        public int GetLength()
        {
            return lista.Count;
        }

        public int FindLastNotEmpty()
        {
            int last_not_empty = 0;
            int i = 0;
            foreach (Pole pole in lista)
            {
                if (!pole.IfEmpty())
                {
                    last_not_empty = i;
                }
                i++;
            }

            return last_not_empty;
        }
    }
}
