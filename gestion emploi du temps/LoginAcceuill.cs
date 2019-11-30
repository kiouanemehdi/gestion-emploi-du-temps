using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace gestion_emploi_du_temps
{
    public partial class LoginAcceuill : Form
    {
        public LoginAcceuill()
        {
            InitializeComponent();
           
            chefLogincs1.Hide();
            eseignantLogin1.Hide();
        }

        private void adminLogin1_Load(object sender, EventArgs e)
        {

        }

        private void chefLogincs2_Load(object sender, EventArgs e)
        {

        }

        private void LoginAcceuill_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            chefLogincs1.Hide();
            eseignantLogin1.Hide();
            adminLogin1.Show();
          
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            eseignantLogin1.Hide();
            adminLogin1.Hide();
            chefLogincs1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adminLogin1.Hide();
            chefLogincs1.Hide();
            eseignantLogin1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
        }

        private void eseignantLogin1_Load(object sender, EventArgs e)
        {

        }

        private void adminLogin1_Load_1(object sender, EventArgs e)
        {
           

        }public void hideloginform()
        {
          
        }

        private void adminLogin1_Load_2(object sender, EventArgs e)
        {

        }
    }
    }

