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
    public partial class chef_gestion_salle : UserControl
    {
        connection cn;
        SqlCommandBuilder sqlCommand = null;
        SqlDataAdapter sqlAdapter = null;
        DataSet dataset = null;
        public chef_gestion_salle()
        {
            InitializeComponent();
            cn = new connection();
        }
        private void refresh()
        {
            try

            {
                sqlAdapter = new SqlDataAdapter("SELECT id_salle as Id,nom_salle as [Nom de salle],capacite as Capacité,type_salle as Type FROM Salle", cn.conn);
                sqlCommand = new SqlCommandBuilder(sqlAdapter);
                sqlAdapter.InsertCommand = sqlCommand.GetInsertCommand();
                sqlAdapter.UpdateCommand = sqlCommand.GetUpdateCommand();
                sqlAdapter.DeleteCommand = sqlCommand.GetDeleteCommand();
                dataset = new DataSet();
                sqlAdapter.Fill(dataset, "Salle");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataset.Tables["Salle"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)

                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[3, i] = linkCell;
                }
            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }
        }

        private void chef_gestion_salle_Load(object sender, EventArgs e)
        {
            refresh();
            idbox.Enabled = false;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cn.execute_query("insert into Salle values('" + nombox.Text + "', '" + capacitebox.Text + "', '" + typebox.Text.ToString() + "')"))
            {
                MessageBox.Show("salle bien ajouter");
                refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cn.execute_query("Update Salle set nom_salle='" + nombox.Text + "',capacite='" + capacitebox.Text + "',type_salle='" + typebox.Text.ToString() + "' where id_salle='" + idbox.Text + "'"))
            {
                MessageBox.Show("salle bien modifier");
                refresh();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Etes-vous sûr de vouloir supprimer ? ", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (cn.execute_query("Delete Salle where id_salle='" + idbox.Text + "'"))
                    {
                        MessageBox.Show("salle bien supprimer");
                        refresh();
                    }
             }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            idbox.Clear();
            nombox.Clear();
            capacitebox.Clear();
            typebox.Items.Clear();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;// get the Row Index
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            idbox.Text = selectedRow.Cells[0].Value.ToString();
            nombox.Text = selectedRow.Cells[1].Value.ToString();
            capacitebox.Text = selectedRow.Cells[2].Value.ToString();
            typebox.Text = selectedRow.Cells[3].Value.ToString();
        }
    }



}
