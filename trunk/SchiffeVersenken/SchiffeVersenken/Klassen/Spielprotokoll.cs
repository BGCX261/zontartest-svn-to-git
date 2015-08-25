using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchiffeVersenken.Klassen
{
    /// <summary>
    ///  Verwaltet alle Spielzüge
    /// </summary>
    class Spielprotokoll
    {
       private List<Spielzug> spielzuege = new List<Spielzug>();
       private List<SpielzugAnwort> antworten = new List<SpielzugAnwort>();

        #region Funktionen

        public void speicherSpielzug ( Spielzug zuSpeichernderSpielzug )
        {
            spielzuege.Add(zuSpeichernderSpielzug);
        }

        public bool speicherAntwort(SpielzugAnwort antwort)
        {
            antworten.Add(antwort);
            // Nach einem passenden Spielzug suchen
            for (int i = 0; i < spielzuege.Count(); i++)
                if ((spielzuege[i].spielzugnummer == antwort.spielzugnummer))
                    return true;
            return false;
        }

        public int getReiheZuSpielzug(int spielzugnummer)
        {
            for (int i = spielzuege.Count - 1; i >= 0; i--)
            {
                if (spielzuege[i].spielzugnummer == spielzugnummer)
                    return spielzuege[i].reihe;
            }
            return -1;
        }

        public int getSpalteZuSpielzug(int spielzugnummer)
        {
            for (int i = spielzuege.Count - 1; i >= 0; i--)
            {
                if (spielzuege[i].spielzugnummer == spielzugnummer)
                    return spielzuege[i].spalte;
            }
            return -1;
        }

        public int naechsteSpielzugnummer()
        { 
            if (spielzuege.Count <= 0) return 0;
            return spielzuege[spielzuege.Count-1].spielzugnummer + 1;
        }

        #endregion



    }
}
