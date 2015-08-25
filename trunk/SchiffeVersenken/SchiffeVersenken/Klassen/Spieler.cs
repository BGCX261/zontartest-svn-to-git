using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchiffeVersenken.Klassen
{
    /// <summary>
    /// Verwaltet Informationen über einen Spieler
    /// </summary>
    abstract class Spieler
    {
        #region Variablen und Accessoren

        public string name { get; set; }

        protected bool spielVerloren = false;

        /// <summary>
        /// Enthält das aktuelle Spiel, welches der Spieler spielt
        /// </summary>
        public string spielID { get; set; }

        #endregion

        #region Prozeduren

        public abstract void verarbeiteSpielzug(Spielzug zuVerarbeitenderSpielzug);

        public delegate void SpielzugBeendetEvent(SpielzugAnwort antwort);
        public event SpielzugBeendetEvent spielzugBeendet;
        protected void raiseSpielzugBeendet(int spielzugnummer, Schussergebnis ergebnis)
        {
            SpielzugAnwort antwort = new SpielzugAnwort(this.name, this.spielID, spielzugnummer, ergebnis);
            if (spielzugBeendet == null) return;
            spielzugBeendet(antwort);
        }

        public bool isGameOver()
        {
            return spielVerloren;
        }

        

        #endregion
    }
}
