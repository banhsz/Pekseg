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

        static List<Pekaru> pekaruLista = new List<Pekaru>();
        static List<Pekseg> peksegLista = new List<Pekseg>();
        public Form1()
        {
            InitializeComponent();
            /*
            Pekaru p1 = new Pekaru("Pogácsa", 50, false);
            label1.Text = p1.ToString();

            Pekseg pk1 = new Pekseg("Kovács pékség",new List<Pekaru>(),DateTime.Now);
            label1.Text = pk1.ToString();
            */



        }

        private void buttonPekaruHozzaadas_Click(object sender, EventArgs e)
        {
            if ((textBoxPekaruNevInput.Text != "") && (numericUpDownPekaruArInput.Value > 0))
            {
                Pekaru p = new Pekaru(textBoxPekaruNevInput.Text, (int)numericUpDownPekaruArInput.Value, checkBoxLaktormentesInput.Checked);
                pekaruLista.Add(p);
                listBoxPekaruk.Items.Add(p.ToString());
                pekaruListaKiir();
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
                pekaruListaKiir();
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
                listBoxPeksegek.Items.Add(p.ToString());
                peksegListaKiir();
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
        }
    }
}
