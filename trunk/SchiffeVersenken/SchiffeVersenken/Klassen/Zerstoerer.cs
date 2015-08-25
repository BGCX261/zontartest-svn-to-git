using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchiffeVersenken.Klassen
{
    class Zerstoerer : Schiff
    {
        public Zerstoerer(int reihe, int spalte, bool waagerecht)
        {
            elemente = new Schiffelement[4];
            platzieren(reihe, spalte, waagerecht);
        }

        /// <summary>
        /// Setzt die Positionen der einzelnen Elemente
        /// </summary>
        /// <param name="reihe"></param>
        /// <param name="spalte"></param>
        /// <param name="waagerecht">bei waagerecht ist wird die äußerst linke position angegeben, sonst das oberste Feld</param>
         private void platzieren (int reihe, int spalte, Boolean waagerecht)
         {
                 for (int i = 0; i < elemente.Length; i++)
                 {
                     elemente[i] = new Schiffelement(reihe,spalte);
                     if (waagerecht)
                         reihe++;
                     else
	                     spalte++;
                 }
         }       
    }
}
