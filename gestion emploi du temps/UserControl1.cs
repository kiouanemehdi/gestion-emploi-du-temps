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
    public partial class UserControl1 : UserControl
    {
        Form2 form2;
        public UserControl1()
        {
            InitializeComponent();
          
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



        private void button1_Click(object sender, EventArgs e)
        {
            //the function 'checkLogin' existe in Form2.cs but the variable form2 is an istance of the FORM2 class it was declared in the first line of this class
            form2 = new Form2();
            form2.checkLogin("Admin");
            //I call this methode to avoid request another connection you know ;
                
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
