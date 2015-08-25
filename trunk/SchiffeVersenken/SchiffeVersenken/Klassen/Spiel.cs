using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchiffeVersenken.Klassen
{
    /// <summary>
    /// "Hauptklasse"
    /// </summary>
    public class Spiel
    {
        #region Variablen

        public int ICH = 0;
        public int DU = 1;

        private string spielID = "";

        private Spielfeld[] spielfeld;
        private Spielprotokoll spielprotokoll = new Spielprotokoll();
        private Spieler[] spieler;
       
        #endregion

        #region Prozeduren

        public Spiel()
        {
            // Objekte erstellen
            spieler = new Spieler[2] { new SpielerIch(), new SpielerDu() };        // Speicher über Superklasse Spieler     
            spielfeld = new Spielfeld[2] {new Spielfeld(5,5), new Spielfeld(5,5)};

        }


        public void neuesSpiel(int reihen, int spalten, string spielID, string ich, string du)
        {

            this.spielID = spielID;

            this.spielfeld = new Spielfeld[2] {new Spielfeld(reihen, spalten), new Spielfeld(reihen, spalten)};

            spielprotokoll = new Spielprotokoll();

            spieler[ICH] = new SpielerIch();
            spieler[DU] = new SpielerDu();

            spieler[ICH].spielID = this.spielID;
            spieler[DU].spielID = this.spielID;
            spieler[ICH].name = ich;
            spieler[DU].name = du;

            // Spielerevents mit Spiel verbinden
            spieler[ICH].spielzugBeendet += this.verarbeiteSpielzugAntwort;
            spieler[DU].spielzugBeendet += this.verarbeiteSpielzugAntwort;

            if (neuesSpielGestartet == null) return;
                neuesSpielGestartet();

            return;
        }

        public delegate void SpielzugBeendetEvent (SpielzugAnwort antwort);
        public event SpielzugBeendetEvent SpielzugBeendet;

        public delegate void GameOverEvent(bool verloren);
        public event GameOverEvent gameOver;

        public delegate void NeuesSpielEvent();
        public event NeuesSpielEvent neuesSpielGestartet;

        public delegate void FeldStatusGeaendert(int reihe, int spalte, Schussergebnis status);
        public event FeldStatusGeaendert feldStatusGeaendert;

        public void verarbeiteSpielzug(Spielzug neuerSpielzug)
        {
            // Spielzug muss zum laufenden Spiel passen
            if (!(neuerSpielzug.spielID == this.spielID)) return;

            // Spielzug muss der nächste sein
            if (!(neuerSpielzug.spielzugnummer == spielprotokoll.naechsteSpielzugnummer())) return;

            spielprotokoll.speicherSpielzug(neuerSpielzug);

            // Spielzug an den jeweils anderen übergeben
            if (spieler[ICH].name == neuerSpielzug.spieler)
                spieler[DU].verarbeiteSpielzug(neuerSpielzug);
            else
            {
                spieler[ICH].verarbeiteSpielzug(neuerSpielzug);
            }

            return;
        }

        private void verarbeiteSpielzugAntwort(SpielzugAnwort antwort)
        {
            spielprotokoll.speicherAntwort(antwort);
            spielfeldUpdaten(antwort);
            SpielzugBeendet ( antwort );
            if (spieler[ICH].isGameOver())
                gameOver(true);
            else if (spieler[DU].isGameOver())
                gameOver(false);
        }

        private void spielfeldUpdaten(SpielzugAnwort antwort)
        {
            int index = -1;

            // Richtiges Spielfeld wählen
            if (antwort.spieler == spieler[ICH].name)
                index = DU; // Antwort komm von DU, Eintrag in meine Karte
            else
                index = ICH; // und umgekehrt


            int reihe, spalte;

            // Reihe und Spalte sind im Protokoll gespeichert
            reihe = spielprotokoll.getReiheZuSpielzug(antwort.spielzugnummer);
            if (reihe < 0) return;
            spalte = spielprotokoll.getSpalteZuSpielzug(antwort.spielzugnummer);
            if (spalte < 0) return;

            spielfeld[index].setFeldStatus(reihe, spalte, antwort.schussergebnis);

            // Ereignis auslösen, damit Oberfläche sich anpassen kann
            feldStatusGeaendert(reihe, spalte, antwort.schussergebnis);
        }

        public int naechsteSpielzugNummer()
        {
            return spielprotokoll.naechsteSpielzugnummer();
        }

        public Schussergebnis getSpielfeldStatus(int reihe, int spalte, string spielername)
        {
            int index = DU;
            if (spielername == spieler[ICH].name)
                index = ICH; // Antwort komm von DU, Eintrag in meine Karte
            return spielfeld[index].getFeldStatus(reihe, spalte);
        }

        public int getAnzReihen()
        {
            return spielfeld[0].getAnzReihen();
        }

        public int getAnzSpalten()
        {
            return spielfeld[0].getAnzSpalten();
        }

        public int getSchiffeAnzahl()
        {
            return (spieler[ICH] as SpielerIch).getSchiffeAnzahl();
        }

        public void setSchiffeBelegung(Schiff[] schiffeBelegung)
        {
            (spieler[ICH] as SpielerIch).schiffeFestlegen(schiffeBelegung);
        }

        public void setSchiffeBelegungP2(Schiff[] schiffeBelegung)
        {
            (spieler[DU] as SpielerDu).schiffeFestlegen(schiffeBelegung);
        }

        public void speichern(string filename)
        {
            // ...
            return;
        }

        public void laden(string filename)
        {
            // ...
            return;
        }
        
        

        #endregion

    }
}
