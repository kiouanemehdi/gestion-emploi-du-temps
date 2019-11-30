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
    public partial class EseignantLogin : UserControl
    {
        public EseignantLogin()
        {
            InitializeComponent();
            textBox1.BackColor = Color.AliceBlue;
            textBox2.BackColor = Color.AliceBlue;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                connection conn = new connection();
                SqlCommand cmd = new SqlCommand("CheckLogin_E", conn.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserN", SqlDbType.VarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@PassW", SqlDbType.VarChar).Value = textBox2.Text;
                var returnParametre = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParametre.Direction = ParameterDirection.ReturnValue;
                conn.conn.Open();
                cmd.ExecuteNonQuery();
                var result = returnParametre.Value;
                int i = Convert.ToInt32(result);
                if (i!=0)

                {
                    MessageBox.Show("Login suuccesse");
LoginAcceuill obj = (LoginAcceuill)Application.OpenForms["LoginAcceuill"];
                    obj.Hide();
                    new ens_acceuil(i).Show();
                    

                }
                else
                {
                    MessageBox.Show("the user doesn't existe");
                }

                /*  cmd.Parameters.Add("@ens", SqlDbType.Int).Value = ensbox.SelectedValue;
                  cmd.Parameters.Add("@semestre", SqlDbType.Int).Value = semestrebox.SelectedValue;
                  cmd.Parameters.Add("@element", SqlDbType.Int).Value = elementbox.SelectedValue;
                  cmd.Parameters.Add("@module", SqlDbType.Int).Value = modulebox.SelectedValue;
                  cmd.Parameters.Add("@groupe", SqlDbType.Int).Value = groupebox.SelectedValue;
                  cmd.Parameters.Add("@salle", SqlDbType.Int).Value = sallebox.SelectedValue;
                  cmd.Parameters.Add("@filiere", SqlDbType.Int).Value = idf;
                  cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = typebox.Text;*/



                //  MessageBox.Show("Login successe");

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
