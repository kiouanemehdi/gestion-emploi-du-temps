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
    public partial class admin_gestion_chef : UserControl
    {
        connection cn;
        SqlCommandBuilder sqlCommand = null;
        SqlDataAdapter sqlAdapter = null;
        DataSet dataset = null;
        public admin_gestion_chef()
        {
            cn = new connection();
            InitializeComponent();
        }

        private void refresh()
        {

            try

            {
                sqlAdapter = new SqlDataAdapter("SELECT id_chef as Id,nom as [Nom],prenom as Prénom,chef_username as [Nom d'utilisateur],chef_password as [Mot de passe],email as [email],portable as [portable], nom_filiere as Filière FROM ChefDpt C,Filiere F where C.id_filiere=F.id_filiere", cn.conn);
                sqlCommand = new SqlCommandBuilder(sqlAdapter);

                dataset = new DataSet();
                sqlAdapter.Fill(dataset, "ChefDepartement");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataset.Tables["ChefDepartement"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)

                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[5, i] = linkCell;
                }
            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

            string query1 = "select id_filiere,nom_filiere from Filiere";
            SqlCommand cmd1 = new SqlCommand(query1, cn.conn);
            cmd1.CommandText = query1;
            cn.conn.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            filierebox.DataSource = dt1;
            filierebox.ValueMember = "id_filiere";
            filierebox.DisplayMember = "Nom_filiere";
            filierebox.Text = "";
            dr1.Close();
            cn.conn.Close();
        }

        private void admin_gestion_chef_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;// get the Row Index
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            idbox.Text = selectedRow.Cells[0].Value.ToString();
            nombox.Text = selectedRow.Cells[1].Value.ToString();
            prenombox.Text = selectedRow.Cells[2].Value.ToString();
            emailbox.Text = selectedRow.Cells[3].Value.ToString();
            portablebox.Text = selectedRow.Cells[4].Value.ToString();
            usernamebox.Text = selectedRow.Cells[5].Value.ToString();
            passwordbox.Text = selectedRow.Cells[6].Value.ToString();
            filierebox.Text = selectedRow.Cells[7].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Etes-vous sûr de vouloir supprimer ? ", MessageBoxButtons.YesNo);
            
                if(dialogResult == DialogResult.Yes)
                {
                    if (cn.execute_query("Delete ChefDpt where id_chef='" + idbox.Text + "'"))
                    {
                        MessageBox.Show("Bien supprimer");
                        refresh();
                    }
                }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cn.execute_query("Update ChefDpt set nom='" + nombox.Text + "',prenom='" + prenombox.Text + "',chef_username='" + usernamebox.Text + "',chef_password='" + passwordbox.Text + "',id_filiere='" + filierebox.SelectedValue + "' where id_chef='" + idbox.Text + "'"))
            {
                MessageBox.Show("Bien modifier");
                
               refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cn.execute_query("insert into ChefDpt values('" + nombox.Text + "', '" + prenombox.Text + "', '" + usernamebox.Text + "', '" + passwordbox.Text + "','" + filierebox.SelectedValue + "')"))
            {
                MessageBox.Show("Bien ajouter");
               
                refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            idbox.Clear();
            nombox.Clear();
            prenombox.Clear();
            emailbox.Clear();
            usernamebox.Clear();
            passwordbox.Clear();
            filierebox.Items.Clear();
            portablebox.Clear();
        }

        private void nombox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
