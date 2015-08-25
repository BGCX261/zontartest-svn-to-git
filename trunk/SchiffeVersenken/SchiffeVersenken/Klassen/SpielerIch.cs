using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchiffeVersenken.Klassen
{
    class SpielerIch : Spieler
    {
        #region Variablen

        Schiff[] schiffe = new Schiff[5];

        #endregion

        #region Funktionen

        public override void verarbeiteSpielzug(Spielzug zuVerarbeitenderSpielzug)
        {
            int anzahlVersenkterSchiffe = 0;
            Schussergebnis neuerTreffer = Schussergebnis.verfehlt;

            // Schiffe abprüfen
            for (int i = 0; i < schiffe.Count(); i++)
            {
                // Schussversuch abgeben
                Schussergebnis tmp = schiffe[i].schussVersuch(zuVerarbeitenderSpielzug.reihe, zuVerarbeitenderSpielzug.spalte);
                
                // Falls getroffen oder versenkt
                if ( !( tmp == Schussergebnis.verfehlt )) neuerTreffer = tmp;

                if (schiffe[i].versenkt() == true) anzahlVersenkterSchiffe++;
              }

            if (schiffe.Count() == anzahlVersenkterSchiffe) neuerTreffer = Schussergebnis.gameOver;

            if (neuerTreffer == Schussergebnis.gameOver) this.spielVerloren = true;

            // Spielzugbeendet auslösen
            raiseSpielzugBeendet(zuVerarbeitenderSpielzug.spielzugnummer, neuerTreffer);
        }

        public bool schiffeFestlegen (Schiff[] schiffebelegung)
        {
            // Die neue Schiffebelegung muss von der Größe her passen, sonst übernehmen wir sie nicht
            if (!(schiffebelegung.Count() == this.schiffe.Count())) return false;
           
             // Belegung übernehmen
            this.schiffe = schiffebelegung;

            return true;
        }

        public int getSchiffeAnzahl()
        {
            return this.schiffe.Length;
        }

        #endregion
    }
}
