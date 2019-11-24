using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_emploi_du_temps
{
    public partial class UserControl2 : UserControl
    {
        Form2 fr;  
        public UserControl2()
        {
            InitializeComponent();
       
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fr = new Form2();
            fr.checkLogin("chef");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public String Username
        {
            get
            {
                return textBox1.Text;
            }
        }
        public String Password
        {
            get
            {
                return textBox2.Text;
            }
        }
    }
}
