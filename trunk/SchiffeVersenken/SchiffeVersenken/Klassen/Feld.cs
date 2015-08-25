using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchiffeVersenken.Klassen
{
   

    /// <summary>
    /// Enthält Informationen über ein Feld auf dem Spielfeld
    /// </summary>
    public class Feld
    {
        public Schussergebnis status { get; set; }

        public Feld()
        {
            status = Schussergebnis.unbekannt;
        }
    }
}
