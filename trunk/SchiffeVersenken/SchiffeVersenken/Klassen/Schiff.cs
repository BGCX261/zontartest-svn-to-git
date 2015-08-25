using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SchiffeVersenken.Klassen
{
    /// <summary>
    /// Verwaltet die Informationen über ein Schiff
    /// </summary>
    public abstract class Schiff
    {
        protected Schiffelement[] elemente;

        public virtual Color schifffarbe () {
         return Color.Black;
        }

        public int sizeInElements()
        {
            return elemente.Count();
        }

        public bool versenkt()
        {
            int anzahlVersenkterElemente = 0;
            // Zählen
            for (int i = 0; i < elemente.Count(); i++)
                if (elemente[i].getroffen) anzahlVersenkterElemente++;
            if (anzahlVersenkterElemente == elemente.Count()) return true;
            return false; // nicht alle Elemente wurden versenkt
        }        

        public virtual Schussergebnis schussVersuch(int reihe, int spalte)
        {
            bool neuGetroffen = false;
            int trefferAnzahl = 0;

            for (int i = 0; i < elemente.Count(); i++)
            {
                // "Versuchen das Schiff zu treffen"
                if (elemente[i].schussversuch(reihe, spalte) == Schussergebnis.getroffen) neuGetroffen = true;

                // Anzahl der Treffer zählen
                if (elemente[i].getroffen == true) trefferAnzahl++;
            }

            // Wenn alle Elemente getroffen, sind wir zerstört
            if ((elemente.Count() == trefferAnzahl) && (neuGetroffen)) return Schussergebnis.versenkt;

            // Ansonsten, sind wir getroffen?
            if (neuGetroffen == true) return Schussergebnis.getroffen;

            // Ansonsten, verfehlt
            return Schussergebnis.verfehlt;
        }

        public delegate void SchiffZeichnen(int reihe, int spalte, Color farbe);

        public SchiffZeichnen zeichnen;

        /// <summary>
        /// Zeichnet das Schiff neu, Delegaten müssen angemeldet sein
        /// </summary>
        public void update()
        {
            if (zeichnen == null) return;
            for (int i = 0; i < elemente.Length; i++)
            {
                zeichnen(elemente[i].reihe, elemente[i].spalte, schifffarbe());
            }
        }
    }
}
