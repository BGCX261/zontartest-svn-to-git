using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SchiffeVersenken.Klassen;
using System.Threading;

namespace SchiffeVersenken
{
    public partial class Form1 : Form
    {
        #region Variablen

        private Spiel spiel = new Spiel();

        private string aktuellerSpieler;

        #endregion

        public Form1()
        {
            InitializeComponent();

            spiel.gameOver += this.GameOver;
            spiel.SpielzugBeendet += SpielzugVerarbeitet;

            spielfeld.feldauswahlGetroffen += this.SpielzugErstellen;
            spiel.feldStatusGeaendert += spielfeld.feldUpdate;
        }

        private void SpielzugErstellen(int reihe, int spalte)
        {
            // Spielzug einstellen
            Spielzug tmp = new Spielzug(aktuellerSpieler, "testSpiel", spiel.naechsteSpielzugNummer(), reihe, spalte);

            // An Spiel übergeben
            spiel.verarbeiteSpielzug(tmp);
        }

        private void SpielzugVerarbeitet(SpielzugAnwort antwort)
        {
            logLine(antwort.spielID + " - " + antwort.spieler + " - " + antwort.spielzugnummer.ToString() + " - " + antwort.schussergebnis.ToString());
            aktuellenSpielerBestimmen();
        }

        private void GameOver(bool verloren)
        {
            if (verloren)
                MessageBox.Show("Du hast verloren");
            else
                MessageBox.Show("Du hast gewonnen");

            spieler.Enabled = true;
        }

        private void aktuellenSpielerBestimmen()
        {
            int spielzug = spiel.naechsteSpielzugNummer();
            spielzug = spielzug % 2;
            if (spielzug == 0) // Gerade
                spieler.SelectedIndex = 0;
            else // Ungerade
                spieler.SelectedIndex = 1;

            this.aktuellerSpieler = spieler.Items[spieler.SelectedIndex].ToString();

            this.Update();

            Thread.Sleep(1000);

            aktuelleKarteAnzeigen();
        
        }

        private void aktuelleKarteAnzeigen()
        {
            int reihen = spiel.getAnzReihen();
            int spalten = spiel.getAnzSpalten();

            for (int r=0; r < reihen; r++)
                for (int s = 0; s < spalten; s++)
                {
                    spielfeld.feldUpdate(r,s,spiel.getSpielfeldStatus(r,s,aktuellerSpieler));
                }
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void neuesSpielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spieler.Enabled = false;

            spiel.neuesSpiel(25, 15, "testSpiel", spieler.Items[0].ToString(), spieler.Items[1].ToString());

            spielfeld.neuesFeld(spiel.getAnzReihen(), spiel.getAnzSpalten());
            

            logLine("Neues Spiel gestartet");

            NeuesSchiff dialog = new NeuesSchiff();
            dialog.setzeFeldgroeße(spiel.getAnzReihen(), spiel.getAnzSpalten());
            // Spieler 1
            Schiff[] tmpSchiffe = new Schiff[5];
            for (int i = 0; i < tmpSchiffe.Length; i++)
            {
                for (int x = 0; x < i; x++)
                    tmpSchiffe[x].update();
                dialog.titel = "Schiff " + i.ToString() + " platzieren";                
                dialog.ShowDialog();
                if (dialog.DialogResult == System.Windows.Forms.DialogResult.Cancel) return;
                tmpSchiffe[i] = new Zerstoerer(dialog.reihe, dialog.spalte, dialog.waagerecht);
                tmpSchiffe[i].zeichnen += dialog.feldBelegen;
                dialog.feldLoeschen();
            }
            spiel.setSchiffeBelegung(tmpSchiffe);
            for (int x = 0; x < tmpSchiffe.Length; x++)
                tmpSchiffe[x].zeichnen -= spielfeld.feldEinfaerben;


            tmpSchiffe = new Schiff[5];
            for (int i = 0; i < tmpSchiffe.Length; i++)
            {
                for (int x = 0; x < i; x++)
                    tmpSchiffe[x].update();
                dialog.titel = "Schiff " + i.ToString() + " platzieren";
                dialog.ShowDialog();
                if (dialog.DialogResult == System.Windows.Forms.DialogResult.Cancel) return;
                tmpSchiffe[i] = new Zerstoerer(dialog.reihe, dialog.spalte, dialog.waagerecht);
                tmpSchiffe[i].zeichnen += dialog.feldBelegen;
                dialog.feldLoeschen();
            }
            spiel.setSchiffeBelegungP2(tmpSchiffe);
            for (int x = 0; x < tmpSchiffe.Length; x++)
                tmpSchiffe[x].zeichnen -= spielfeld.feldEinfaerben;

            aktuellenSpielerBestimmen();
        }

        private void logLine(string text)
        {
            log.AppendText(Environment.NewLine + text);
            log.Select(log.Text.Length, 1);
            log.ScrollToCaret();
        }

        private void spieler_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.aktuellerSpieler = spieler.Items[spieler.SelectedIndex].ToString();

            this.Update();

            aktuelleKarteAnzeigen();
        }

       
    }
}
