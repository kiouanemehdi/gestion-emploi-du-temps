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

    public partial class admin_gestion_filiere : UserControl
    {
        connection cn;
        SqlCommandBuilder sqlCommand = null;
        SqlDataAdapter sqlAdapter = null;
        DataSet dataset = null;

        public admin_gestion_filiere()
        {
            cn = new connection();
            InitializeComponent();
        }
        private void refresh()
        {
            try

            {
                sqlAdapter = new SqlDataAdapter("SELECT id_filiere as Id,nom_filiere as [Nom de filiere] FROM Filiere ", cn.conn);
                sqlCommand = new SqlCommandBuilder(sqlAdapter);

                dataset = new DataSet();
                sqlAdapter.Fill(dataset, "Filiere");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataset.Tables["Filiere"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)

                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[1, i] = linkCell;
                }
            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            idbox.Text = selectedRow.Cells[0].Value.ToString();
            filierebox.Text = selectedRow.Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cn.execute_query("insert into Filiere values('" + filierebox.Text + "')"))
            {
                MessageBox.Show("Bien ajouter");
                refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cn.execute_query("Update Filiere set nom_filiere='" + filierebox.Text + "' where id_filiere='" + idbox.Text + "'"))
            {
                MessageBox.Show("Bien modifier");
                refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Etes-vous sûr de vouloir supprimer ? ", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (cn.execute_query("Delete Filiere where id_filiere='" + idbox.Text + "'"))
                {
                    MessageBox.Show("Bien supprimer");
                    refresh();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            idbox.Clear();
            filierebox.Clear();
        }

        private void admin_gestion_filiere_Load(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
