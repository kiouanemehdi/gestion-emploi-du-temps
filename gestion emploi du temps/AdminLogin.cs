using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace gestion_emploi_du_temps
{
    public partial class AdminLogin : UserControl
    {
       
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                connection conn = new connection();
                SqlCommand cmd = new SqlCommand("CheckLogin", conn.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserN", SqlDbType.VarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@PassW", SqlDbType.VarChar).Value = textBox2.Text;
                var returnParametre = cmd.Parameters.Add("@ReturnVal", SqlDbType.Bit);
                returnParametre.Direction = ParameterDirection.ReturnValue;
                conn.conn.Open();
                cmd.ExecuteNonQuery();
                var result = returnParametre.Value;
                int i = Convert.ToInt32(result);
                if(i!=0)
                {
                    MessageBox.Show("login successe");
                    LoginAcceuill obj = (LoginAcceuill)Application.OpenForms["LoginAcceuill"];
                    obj.Hide();
                    new admin_acceuil(i).Show();
                  
                }
                else
                {
                    MessageBox.Show("the user doesn't existe");
                }

                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
