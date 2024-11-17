using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Factura
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Clientes editar = new Clientes();
            editar.TopLevel = false;
            editar.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(editar);
            editar.Show();
        }

    }
}
