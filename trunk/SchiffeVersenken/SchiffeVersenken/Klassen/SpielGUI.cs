using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SchiffeVersenken.Klassen
{
    public partial class SpielGUI : UserControl
    {
        private FeldGUI[,] felder;

        private int _reihe;
        public int reihe { get { return _reihe; } }

        private int _spalte;
        public int spalte { get { return _spalte; } }

        public SpielGUI()
        {
            InitializeComponent();
            felder = new FeldGUI[5, 5];
            for (int r=0; r<felder.GetLength(0); r++)
                for (int s = 0; s < felder.GetLength(1); s++)
                {
                    felder[r, s] = new FeldGUI();
                }
        }

        public void neuesFeld(int reihen, int spalten)
        {
            this.Visible = false;
            // FeldGUI platzieren
            felder = new FeldGUI[reihen, spalten];
            for (int r=0; r < reihen; r++)
                for (int s = 0; s < spalten; s++)
                {
                    felder[r,s] = new FeldGUI(r,s);
                    felder[r, s].Location = new Point(r * felder[r, s].Width, s * felder[r, s].Height);
                    this.Controls.Add(felder[r, s]);
                }
            this.Visible = true;

            feldLoeschen();

            aktiviereSpielfeld();
        }

        public void feldLoeschen()
        {
            for (int r = 0; r < felder.GetLength(0); r++)
                for (int s = 0; s < felder.GetLength(1); s++)
                {
                    felder[r, s].setStatus(Schussergebnis.unbekannt);
                }
        }

        public void aktiviereSpielfeld()
        {
            foreach (FeldGUI feld in felder)
            {
                feld.spielfeldAuswahl -= clickOnFeld;
                feld.spielfeldAuswahl += clickOnFeld;
            }
        }

        public void deaktivierSpielfeldeingabe()
        {
            foreach (FeldGUI feld in felder)
            {
                feld.spielfeldAuswahl -= clickOnFeld;
            }
        }

        public delegate void FeldauswahlEvent(int reihe, int spalte);
        public event FeldauswahlEvent feldauswahlGetroffen;

        private void clickOnFeld(FeldGUI feld)
        {
            _reihe = feld.reihe;
            _spalte = feld.spalte;
            if (feldauswahlGetroffen == null) 
                return;
            feldauswahlGetroffen(_reihe, _spalte);
        }

        public void feldEinfaerben(int reihe, int spalte, Color farbe)
        {
            felder[reihe, spalte].einfaerben(farbe);
        }

        public void feldUpdate(int reihe, int spalte, Schussergebnis status)
        {
            felder[reihe, spalte].setStatus(status);
        }
    }
}
