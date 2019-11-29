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
    public partial class chef_gestion_element : UserControl
    {
        private connection conn;
        SqlCommandBuilder sqlCommand = null;
        SqlDataAdapter sqlAdapter = null;
        DataSet dataset = null;
        private int index;
        public chef_gestion_element()
        {
            conn = new connection();
            conn.conn.Open();
            InitializeComponent();
            sqlAdapter = new SqlDataAdapter("SELECT id_element as IdlElement,nom_element as Nom,M.nom_module as ModuleId,email as email,es.nom_enseignant as EnseignantId FROM Element E ,Module M,Enseignant es where E.id_enseignant=es.id_enseignant and E.id_module=m.id_module", conn.conn);
            sqlCommand = new SqlCommandBuilder(sqlAdapter);

            dataset = new DataSet();
            sqlAdapter.Fill(dataset, "Element");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dataset.Tables["Element"];

            for (int i = 0; i < dataGridView1.Rows.Count; i++)

            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[0, i] = linkCell;
            }

        }

        private void chef_gestion_element_Load(object sender, EventArgs e)
        {
            remplir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new connection();
                SqlCommand cmd = new SqlCommand("ajt_element", conn.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@element_N", SqlDbType.VarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@module_N", SqlDbType.VarChar).Value = comboBox1.Text;
                cmd.Parameters.Add("@enseignat_N", SqlDbType.VarChar).Value = comboBox2.Text;
               conn.conn.Open();
                cmd.ExecuteNonQuery();
               sqlAdapter = new SqlDataAdapter("SELECT id_element as IdlElement,nom_element as Nom,M.nom_module as ModuleId,email as email,es.nom_enseignant as EnseignantId FROM Element E ,Module M,Enseignant es where E.id_enseignant=es.id_enseignant and E.id_module=m.id_module", conn.conn);
                sqlCommand = new SqlCommandBuilder(sqlAdapter);

                dataset = new DataSet();
                sqlAdapter.Fill(dataset, "Element");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataset.Tables["Element"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)

                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[0, i] = linkCell;
                }

            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           



        }

        private void button4_Click(object sender, EventArgs e)
        {
            string elemntN, moduleN, enseignantN;
            elemntN = textBox1.Text;
            enseignantN = comboBox2.Text;
            moduleN = comboBox1.Text;

           DataTable dt1 = new DataTable(); 
           dt1 = conn.query("select  m.id_module,es.id_enseignant  from  Module m ,Enseignant es where  m.nom_module='"+moduleN+"'   and es.nom_enseignant='"+enseignantN+"'");
              
            int n= (Int32)dt1.Rows[0]["id_module"];
      
            int b= (Int32)dt1.Rows[0]["id_enseignant"];
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
           string vv = "update Element set nom_element='"+elemntN+"',id_module='"+n+"',id_enseignant='"+b+"' where id_element='" + selectedRow.Cells[0].Value.ToString()+"'";
            /* MessageBox.Show(vv);*/
            conn = new connection();
            conn.conn.Open();
            SqlCommand re = new SqlCommand(vv, conn.conn);
            re.ExecuteNonQuery();
           // conn.execute_query("update Element set nom_element ='"+elemntN+"' where id_element ='"+vv+"'");
            
                MessageBox.Show("Bien modifier");

               // refresh();
            
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Etes-vous sûr de vouloir supprimer ? ", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[index];
                    string vv = "delete from  Element where id_element='" + selectedRow.Cells[0].Value.ToString() + "'";
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
        private void refreshGrid()
        {
            sqlAdapter = new SqlDataAdapter("SELECT id_element as IdlElement,nom_element as Nom,M.nom_module as ModuleId,email as email,es.nom_enseignant as EnseignantId FROM Element E ,Module M,Enseignant es where E.id_enseignant=es.id_enseignant and E.id_module=m.id_module", conn.conn);
            sqlCommand = new SqlCommandBuilder(sqlAdapter);

            dataset = new DataSet();
            sqlAdapter.Fill(dataset, "Element");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dataset.Tables["Element"];

            for (int i = 0; i < dataGridView1.Rows.Count; i++)

            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[0, i] = linkCell;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }
        private void remplir()
        {
            SqlCommand sc = new SqlCommand("select * from Module", conn.conn);
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            comboBox1.DataSource = tb;
            comboBox1.DisplayMember = "nom_module";
            comboBox1.ValueMember = "id_module";

            ///semestre
            sc = new SqlCommand("select * from Enseignant", conn.conn);
            sda = new SqlDataAdapter(sc);
            tb = new DataTable();
            sda.Fill(tb);
            comboBox2.DataSource = tb;
            comboBox2.DisplayMember = "nom_enseignant";
            comboBox2.ValueMember = "id_enseignant";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;

            DataGridViewRow selectedRow = dataGridView1.Rows[index];


            textBox1.Text = selectedRow.Cells[1].Value.ToString();
            comboBox1.Text = selectedRow.Cells[2].Value.ToString();
            comboBox2.Text = selectedRow.Cells[4].Value.ToString();
        }
    }
}
