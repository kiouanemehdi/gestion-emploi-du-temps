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
    public partial class chef_gestion_module : UserControl
    {
        private connection conn;
        SqlCommandBuilder sqlCommand = null;
        SqlDataAdapter sqlAdapter = null;
        DataSet dataset = null;
        private int index;
        public chef_gestion_module()
        {
            InitializeComponent();
            conn = new connection();
            conn.conn.Open();
            refreshGrid();


        }

        private void chef_gestion_module_Load(object sender, EventArgs e)
        {
            remplir();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string moduleN, semestre,requete;
            moduleN = textBox1.Text;
            semestre = comboBox1.Text;
            int filiere = chef_acceueil.getfilere();
            requete = "insert into Module values('"+moduleN+"','" + filiere + "','"+semestre+ "')";
            SqlCommand cmd = new SqlCommand(requete,conn.conn);//conn.conn.Open();
            cmd.ExecuteNonQuery();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn = new connection();
            string moduleN;
            moduleN = textBox1.Text;
            int semestre;
            semestre = Convert.ToInt32(comboBox1.Text);
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
           string idmodule=selectedRow.Cells[0].Value.ToString();
            int i = Convert.ToInt32(idmodule);
            string vv = "update Module set nom_module='"+moduleN+ "' ,id_semestre='" + semestre+ "' where id_module='"+i+"'";
            conn.conn.Open();
           SqlCommand  cmd = new SqlCommand(vv, conn.conn);
            cmd.ExecuteNonQuery();
            refreshGrid();
        }
        private void refreshGrid()
        {
            int filiere = chef_acceueil.getfilere();
            sqlAdapter = new SqlDataAdapter("select  id_module,nom_module,id_semestre from Module where id_filiere="+ filiere, conn.conn);
            sqlCommand = new SqlCommandBuilder(sqlAdapter);

            dataset = new DataSet();
            sqlAdapter.Fill(dataset, "Module");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dataset.Tables["Module"];

            for (int i = 0; i < dataGridView1.Rows.Count; i++)

            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[0, i] = linkCell;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           /* index = e.RowIndex;

            DataGridViewRow selectedRow = dataGridView1.Rows[index];


            textBox1.Text = selectedRow.Cells[1].Value.ToString();
            comboBox1.Text = selectedRow.Cells[2].Value.ToString();*/
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Etes-vous sûr de vouloir supprimer ? ", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    /* conn = new connection();
                     conn.conn.Open();*/
                    DataGridViewRow selectedRow = dataGridView1.Rows[index];
                    string idmodule = selectedRow.Cells[0].Value.ToString();
                    // int i = Convert.ToInt32(idmodule);
                    string vv = "delete from  Module where id_module='" + idmodule + "'";
                    SqlCommand cmd = new SqlCommand(vv, conn.conn);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            refreshGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
        }
        private void remplir()
        {
            SqlCommand sc = new SqlCommand("select * from Semestre", conn.conn);
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            comboBox1.DataSource = tb;
            comboBox1.DisplayMember = "nom_semestre";
            comboBox1.ValueMember = "id_semestre";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;

            DataGridViewRow selectedRow = dataGridView1.Rows[index];


            textBox1.Text = selectedRow.Cells[1].Value.ToString();
            comboBox1.Text = selectedRow.Cells[2].Value.ToString();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
