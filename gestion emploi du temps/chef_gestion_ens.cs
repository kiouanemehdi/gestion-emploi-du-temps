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
    public partial class chef_gestion_ens : UserControl
    {
        connection cn;
        SqlCommandBuilder sqlCommand = null;
        SqlDataAdapter sqlAdapter = null;
        DataSet dataset = null;
        public chef_gestion_ens()
        {
            InitializeComponent();
            cn = new connection();
        }

        private void refresh()
        {
            try

            {
                sqlAdapter = new SqlDataAdapter("SELECT id_enseignant as Id,nom_enseignant as [Nom],Prenom_enseignant as Prénom,ens_username as [Nom d'utilisateur],ens_password as [Mot de passe],email as [Email],portable as [Numero] FROM Enseignant ", cn.conn);
                sqlCommand = new SqlCommandBuilder(sqlAdapter);

                dataset = new DataSet();
                sqlAdapter.Fill(dataset, "Enseignant");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataset.Tables["Enseignant"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)

                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[4, i] = linkCell;
                }
            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }
        }

        private void chef_gestion_ens_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("valid_email_tele", cn.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = emailbox.Text;
            cmd.Parameters.Add("@tele", SqlDbType.VarChar).Value = telebox.Text;
            cmd.Parameters.Add("@resultat", SqlDbType.Int).Direction = ParameterDirection.Output;

            cn.conn.Open();
            cmd.ExecuteNonQuery();

            int resultat = int.Parse(cmd.Parameters["@resultat"].Value.ToString());
            cn.conn.Close();
            if (resultat == 1)
                MessageBox.Show("email format invalid");
            else if (resultat == 2)
                MessageBox.Show("numero de telephone format invalid");
            else
            {
                if (cn.execute_query("Update Enseignant set nom_enseignant='" + nombox.Text + "',prenom_enseignant='" + prenombox.Text + "',ens_username='" + userbox.Text + "',ens_password='" + passbox.Text + "',email='" + emailbox.Text + "',portable='" + telebox.Text + "' where id_enseignant='" + idbox.Text + "'"))
                {
                    MessageBox.Show("Bien modifier");

                    refresh();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("valid_email_tele", cn.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = emailbox.Text;
            cmd.Parameters.Add("@tele", SqlDbType.VarChar).Value = telebox.Text;
            cmd.Parameters.Add("@resultat", SqlDbType.Int).Direction = ParameterDirection.Output;

            cn.conn.Open();
            cmd.ExecuteNonQuery();

            int resultat = int.Parse(cmd.Parameters["@resultat"].Value.ToString());
            cn.conn.Close();
            if (resultat == 1)
                MessageBox.Show("email format invalid");
            else if (resultat == 2)
                MessageBox.Show("numero de telephone format invalid");
            else
            {
                try
                {
                    if (cn.execute_query("insert into Enseignant values('" + nombox.Text + "', '" + prenombox.Text + "', '" + userbox.Text + "', '" + passbox.Text + "', '" + emailbox.Text + "', '" + telebox.Text + "')"))
                    {
                        MessageBox.Show("Bien ajouter");
                        refresh();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Etes-vous sûr de vouloir supprimer ? ", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (cn.execute_query("Delete Enseignant where id_enseignant='" + idbox.Text + "'"))
                {
                    MessageBox.Show("Bien supprimer");
                    refresh();
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;// get the Row Index
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            idbox.Text = selectedRow.Cells[0].Value.ToString();
            nombox.Text = selectedRow.Cells[1].Value.ToString();
            prenombox.Text = selectedRow.Cells[2].Value.ToString();
            userbox.Text = selectedRow.Cells[3].Value.ToString();
            passbox.Text = selectedRow.Cells[4].Value.ToString();
            emailbox.Text = selectedRow.Cells[5].Value.ToString();
            telebox.Text = selectedRow.Cells[6].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            idbox.Clear();
            nombox.Clear();
            prenombox.Clear();
            userbox.Clear();
            passbox.Clear();
            emailbox.Clear();
            telebox.Clear();
        }
        //bare de recherche
        /*private void recherchebox_TextChanged(object sender, EventArgs e)
        {

            //cn.conn.Open();
            //"SELECT id_enseignant as Id, nom_enseignant as [Nom], Prenom_enseignant as Prénom, ens_username as [Nom d'utilisateur],ens_password as [Mot de passe],email as [Email],portable as [Numero] FROM Enseignant where prenom_enseignant LIKE '" + recherchebox.Text + " %'"
            try

            {
                sqlAdapter = new SqlDataAdapter("SELECT id_enseignant as Id, nom_enseignant as [Nom], Prenom_enseignant as Prénom, ens_username as [Nom d'utilisateur],ens_password as [Mot de passe],email as [Email],portable as [Numero] FROM Enseignant where prenom_enseignant LIKE '" + recherchebox.Text + " %'", cn.conn);
                sqlCommand = new SqlCommandBuilder(sqlAdapter);

                dataset = new DataSet();
                sqlAdapter.Fill(dataset, "Enseignant");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataset.Tables["Enseignant"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)

                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[4, i] = linkCell;
                }
            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }
        }*/
    }
}
