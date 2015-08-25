using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchiffeVersenken.Klassen
{
    /// <summary>
    /// Verwaltet die Felder in einem Spiel
    /// </summary>
    class Spielfeld
    {
        Feld[,] felder;

        public Spielfeld(int reihen, int spalten)
        {
            felder = new Feld[reihen,spalten];//] { new Feld[reihen], new Feld[spalten] }; 
            for (int r=0; r<reihen; r++)
                for (int s = 0; s < spalten; s++)
                {
                    felder[r,s] = new Feld();
                }
        }

        public bool setFeldStatus(int reihe, int spalte, Schussergebnis status)
        {
            // Falls zu wenig Reihen
            if (felder.GetLength(0) <= reihe) return false;
            // Falls zu wenig Spalten
            if (felder.GetLength(1) <= spalte) return false;

            felder[reihe,spalte].status = status;

            return true;
        }

        public Schussergebnis getFeldStatus(int reihe, int spalte)
        {
            // Falls zu wenig Reihen
            if (felder.GetLength(0) <= reihe) return Schussergebnis.unbekannt;
            // Falls zu wenig Spalten
            if (felder.GetLength(1) <= spalte) return Schussergebnis.unbekannt;

            return felder[reihe,spalte].status;
        }

        public int getAnzReihen()
        {
            return felder.GetLength(0);
        }

        public int getAnzSpalten()
        {
            return felder.GetLength(1);
        }
    }
}
