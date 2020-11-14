using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pekseg
{
    public partial class Form1 : Form
    {
        /*
        public void pekaruListaKiir()
        {
            label1.Text = "";
            for (int i = 0; i < pekaruLista.Count; i++)
            {
                label1.Text += pekaruLista[i].ToString();
                label1.Text += "\n";
            }
        }
        public void peksegListaKiir()
        {
            label1.Text = "";
            for (int i = 0; i < peksegLista.Count; i++)
            {
                label1.Text += peksegLista[i].ToString();
                label1.Text += "\n";
            }
        }
        */
        static List<Pekaru> pekaruLista = new List<Pekaru>();
        static List<Pekseg> peksegLista = new List<Pekseg>();
        public Form1()
        {
            InitializeComponent();
        }

        //Adatok tab
        private void buttonPekaruHozzaadas_Click(object sender, EventArgs e)
        {
            if ((textBoxPekaruNevInput.Text != "") && (numericUpDownPekaruArInput.Value > 0))
            {
                Pekaru p = new Pekaru(textBoxPekaruNevInput.Text, (int)numericUpDownPekaruArInput.Value, checkBoxLaktormentesInput.Checked);
                pekaruLista.Add(p);
                listBoxPekaruk.Items.Add(p.ToString());
                //pekaruListaKiir();
            }
        }
        private void buttonPekaruTorles_Click(object sender, EventArgs e)
        {
            if (listBoxPekaruk.SelectedIndex >= 0)
            {
                pekaruLista.RemoveAt(listBoxPekaruk.SelectedIndex);
                listBoxPekaruk.Items.RemoveAt(listBoxPekaruk.SelectedIndex);
                textBoxPekaruNevInput.Text = "";
                numericUpDownPekaruArInput.Value = 0;
                checkBoxLaktormentesInput.Checked = false;
                //pekaruListaKiir();
            }
        }
        private void listBoxPekaruk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPekaruk.SelectedIndex >= 0)
            {
                textBoxPekaruNevInput.Text = pekaruLista[listBoxPekaruk.SelectedIndex].Nev;
                numericUpDownPekaruArInput.Value = pekaruLista[listBoxPekaruk.SelectedIndex].Ar;
                checkBoxLaktormentesInput.Checked = pekaruLista[listBoxPekaruk.SelectedIndex].Laktozmentes;
            }

        }

        private void buttonPeksegHozzaadas_Click(object sender, EventArgs e)
        {
            if ((textBoxPeksegNevInput.Text != ""))
            {
                Pekseg p = new Pekseg(textBoxPeksegNevInput.Text, new List<Pekaru>(), DateTime.Now);
                peksegLista.Add(p);
                listBoxPeksegekStatisztika.Items.Add(p.ToString());
                listBoxPeksegek.Items.Add(p.ToString());
                //peksegListaKiir();
            }
        }
        private void listBoxPeksegek_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxPeksegPekaruk.Items.Clear();
            if (listBoxPeksegek.SelectedIndex >= 0)
            {
                for (int i = 0; i < peksegLista[listBoxPeksegek.SelectedIndex].Termekek.Count; i++)
                {
                    listBoxPeksegPekaruk.Items.Add(peksegLista[listBoxPeksegek.SelectedIndex].Termekek[i].ToString());
                }
            }
        }
        private void buttonPekaruPekseghezFelvetele_Click(object sender, EventArgs e)
        {
            if (listBoxPekaruk.SelectedIndex >= 0 && listBoxPeksegek.SelectedIndex >= 0)
            {
                peksegLista[listBoxPeksegek.SelectedIndex].Termekek.Add(pekaruLista[listBoxPekaruk.SelectedIndex]);
            }
            //Meghívom ezt az eventet, hogy frissüljön a listBoxPeksegPekaruk
            listBoxPeksegek_SelectedIndexChanged(this,e);
            //És ezt is hogy frissüljön a labelStatisztika
            listBoxPeksegekStatisztika_SelectedIndexChanged(this,e);
        }

        //Statisztika tab
        private void listBoxPeksegekStatisztika_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelStatisztika.Text = "";
            if (listBoxPeksegekStatisztika.SelectedIndex>=0)
            {
                int peksegIndexe = listBoxPeksegekStatisztika.SelectedIndex;
                String seged = "";
                seged += String.Format(peksegLista[peksegIndexe].Nev + "\n");
                seged += String.Format("Alapítva: " + peksegLista[peksegIndexe].Alapitva.ToString("yyyy. MM. dd")+"\n\n");
                seged += String.Format("Pékáruk: " + peksegLista[peksegIndexe].Termekek.Count()+" db\n");
                if (peksegLista[peksegIndexe].Termekek.Count>0)
                {
                    seged += String.Format("Átlagos ár: " + Math.Round(peksegLista[peksegIndexe].PekarukAtlagosAra(), 2) + " Ft\n");
                    seged += String.Format("Legolcsóbb termék: " + peksegLista[peksegIndexe].Termekek[peksegLista[peksegIndexe].LegolcsobbTermek()].ToString() + "\n");
                    seged += String.Format("Legdrágább termék: " + peksegLista[peksegIndexe].Termekek[peksegLista[peksegIndexe].LegdragabbTermek()].ToString() + "\n");
                    seged += String.Format("Laktózmentes termék: " + peksegLista[peksegIndexe].LaktozmentesPekaruk() + "db, " + Math.Round(((double)peksegLista[peksegIndexe].LaktozmentesPekaruk() / (double)peksegLista[peksegIndexe].Termekek.Count * 100.00), 2) + "%\n");
                }
                labelStatisztika.Text = seged;
            }
        }

    }
}
