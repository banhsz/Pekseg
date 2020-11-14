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
        public Form1()
        {
            InitializeComponent();
            Pekaru p1 = new Pekaru("Pogácsa", 50, false);
            label1.Text = p1.ToString();

        }
    }
}
