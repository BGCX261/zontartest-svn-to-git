using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchiffeVersenken.Klassen
{
    public partial class NeuesSchiff : Form
    {
        public bool waagerecht
        {
            get { if (rbVertikal.Checked) return false; else return true; }
        }

        public string Schifftyp
        {
            get { return "Zerstörer"; } 
        }

        public string titel
        {
            get { return this.Text; }
            set { this.Text = value; } 
        }

        public int reihe { get{ return spielfeld.reihe; }}
        public int spalte { get { return spielfeld.spalte; } }

        public NeuesSchiff()
        {
            InitializeComponent();
            spielfeld.feldauswahlGetroffen += feldauswahl;
        }

        private void feldauswahl (int reihe, int spalte)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        public void setzeFeldgroeße(int reihen, int spalten)
        {
            spielfeld.neuesFeld(reihen, spalten);
        }

        public void feldBelegen(int reihe, int spalte, Color farbe)
        {
            spielfeld.feldEinfaerben(reihe, spalte, farbe);
        }

        public void feldLoeschen()
        {
            spielfeld.feldLoeschen();
        }
    }
}
