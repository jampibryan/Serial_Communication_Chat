using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using windLaboratorio001;

namespace windLaboratorio001
{
    public partial class Form2 : Form
    {
        miClase puertoC;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1(cmbCOM.Text, Convert.ToInt32(txtBaudios.Text),
                                        cmbPariedad.Text, cmbStop.Text);
            form1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
