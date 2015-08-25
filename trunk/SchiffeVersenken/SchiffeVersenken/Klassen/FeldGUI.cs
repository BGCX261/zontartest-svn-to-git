using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchiffeVersenken.Klassen
{
    public partial class FeldGUI : UserControl
    {
        private Schussergebnis status;

        private int _reihe;
        public int reihe { get { return _reihe; } }

        private int _spalte;
        public int spalte { get { return _spalte; } } 

        public FeldGUI()
        {
            InitializeComponent();
        }

        public FeldGUI(int reihe, int spalte)
            : this()
        {
            _reihe = reihe;
            _spalte = spalte;
        }

        public void setStatus (Schussergebnis neuerStatus)
        {
            status = neuerStatus;
            //this.label.Text = ((int)status).ToString();
            switch (status)
            {
                case Schussergebnis.unbekannt:
                    this.BackColor = Color.Snow;
                    //this.label.ForeColor = Color.Black;
                    break;
                case Schussergebnis.verfehlt:
                    this.BackColor = Color.Red;
                    //this.label.ForeColor = Color.White;
                    break;
                case Schussergebnis.getroffen:
                    this.BackColor = Color.Blue;
                   // this.label.ForeColor = Color.White;
                    break;
                case Schussergebnis.versenkt:
                    this.BackColor = Color.LawnGreen;
                    //this.label.ForeColor = Color.Black;
                    break;
                case Schussergebnis.gameOver:
                    this.BackColor = Color.Gold;
                    //this.label.ForeColor = Color.White;
                    break;
                default:
                    this.BackColor = Color.Gray;
                    //this.label.ForeColor = Color.White;
                    break;
            }
        }

        public void einfaerben(Color farbe)
        {
            this.BackColor = farbe;
        }

        private void FeldGUI_DoubleClick(object sender, EventArgs e)
        {
            spielfeldAuswahl(this);
        }

        public delegate void Spielfeldauswahl(FeldGUI feld);
        public event Spielfeldauswahl spielfeldAuswahl;
    }
}
