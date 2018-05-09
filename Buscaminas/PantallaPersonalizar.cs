using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buscaminas
{
    public partial class PantallaPersonalizar : Form
    {
        public PantallaPersonalizar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetData(ref int width, ref int height, ref int bombs)
        {
            try
            {
                width = Convert.ToInt32(txtWidth.Text);
                height = Convert.ToInt32(txtHeight.Text);
                bombs = Convert.ToInt32(txtBombs.Text);
            }
            catch (Exception)
            {
                width = Convert.ToInt32(width);
                height = Convert.ToInt32(height);
                bombs = Convert.ToInt32(bombs);
            }
        }
    }
}
