using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchiffeVersenken.Klassen
{
    /// <summary>
    /// Enthält Informationen über einen Spielzug
    /// </summary>
    public class Spielzug
    {
        private string _spieler = "";
        public string spieler { get{return _spieler;} }

        private string _spielID = "";
        public string spielID { get { return _spielID; } }

        private int _spielzugnummer;
        public int spielzugnummer
        {
            get
            {
                return _spielzugnummer;
            }
        }

        private int _reihe;
        public int reihe
        {
            get
            {
                return _reihe;
            }
        }

        private int _spalte;
        public int spalte
        {
            get
            {
                return _spalte;
            }
        }

        public Spielzug(string spieler, string spielID, int spielzugnummer, int  reihe, int spalte)
        {
            this._spieler = spieler;
            this._spielID = spielID;
            this._spielzugnummer = spielzugnummer;
            this._reihe = reihe;
            this._spalte = spalte;
        }
    }
}
