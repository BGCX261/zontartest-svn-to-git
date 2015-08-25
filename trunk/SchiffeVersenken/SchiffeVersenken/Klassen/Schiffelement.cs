using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchiffeVersenken.Klassen
{
    /// <summary>
    /// Verwaltet die Informationen eines Teil des Schiffes
    /// </summary>
    public class Schiffelement
    {
        private int _spalte;
        public int spalte { get { return _spalte; } }

        private int _reihe;
        public int reihe { get{return _reihe;} }

        private bool _getroffen = false;
        public bool getroffen 
        {
            get
            {
                return _getroffen;
            }
         }


        #region Funktionen

        public Schiffelement(int reihe, int spalte)
        {
            _reihe = reihe;
            _spalte = spalte;
        }

        public Schussergebnis schussversuch(int reihe, int spalte)
        {
            if ((this.reihe == reihe) && (this.spalte == spalte))
            {
                _getroffen = true;
                return Schussergebnis.getroffen;
            }
            else
                return Schussergebnis.verfehlt;
        }

        #endregion
    }
}
