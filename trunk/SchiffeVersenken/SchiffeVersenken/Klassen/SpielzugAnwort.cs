using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchiffeVersenken.Klassen
{
    /// <summary>
    /// Enthält die Informationen über die Antwort zu einem Spielzug
    /// </summary>
    public class SpielzugAnwort
    {
        private string _spieler = "";
        public string spieler { get{return _spieler;} }

        private string _spielID = "";
        public string spielID { get { return _spielID; } }

        private int _spielzugnummer = 0;
        public int spielzugnummer
        {
            get
            {
                return _spielzugnummer;
            }
        }

        private Schussergebnis _schussergebnis = Schussergebnis.verfehlt;
        public Schussergebnis schussergebnis
        {
            get
            {
                return _schussergebnis;
            }
        }

        public SpielzugAnwort (string spieler, string spielID, int spielzugnummer, Schussergebnis schussergebnis)
        {
            this._spieler = spieler;
            this._spielID = spielID;
            this._spielzugnummer = spielzugnummer;
            this._schussergebnis = schussergebnis;
        }
    }
}
