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
    public partial class chef_gestion_emploi_filiere : Form
    {
        SqlConnection cn;
        int idf;
        public chef_gestion_emploi_filiere(int idf)
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=DESKTOP-NK0LUDA\KIOUANE; Initial Catalog=gestion_emploi; Integrated Security=true;MultipleActiveResultSets=true;");
            try
            {
                cn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            this.idf = idf;
        }

        private void ajouter()
        {
            //les groupes
            SqlCommand sc1 = new SqlCommand("select * from groupe", cn);
            SqlDataAdapter sda1 = new SqlDataAdapter(sc1);
            DataTable tb1 = new DataTable();
            sda1.Fill(tb1);
            groupebox.DataSource = tb1;
            groupebox.DisplayMember = "nom_groupe";
            groupebox.ValueMember = "id_groupe";


            // les jours
            jourbox.Items.Add("lundi");
            jourbox.Items.Add("mardi");
            jourbox.Items.Add("mercredi");
            jourbox.Items.Add("jeudi");
            jourbox.Items.Add("vendredi");
            
            // heure de debut
            hdbox.Items.Add("8:00");
            hdbox.Items.Add("9:45");
            hdbox.Items.Add("11:30");
            hdbox.Items.Add("14:00");
            hdbox.Items.Add("15:45");
            hdbox.Items.Add("17:30");
            // heure fin
            hfbox.Items.Add("9:30");
            hfbox.Items.Add("11:15");
            hfbox.Items.Add("13:00");
            hfbox.Items.Add("15:30");
            hfbox.Items.Add("17:15");
            hfbox.Items.Add("19:00");



            /// les salles
            SqlCommand sc = new SqlCommand("select * from Salle", cn);
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            sallebox.DataSource = tb;
            sallebox.DisplayMember = "nom_salle";
            sallebox.ValueMember = "id_salle";

            ///semestre
            sc = new SqlCommand("select * from Semestre", cn);
            sda = new SqlDataAdapter(sc);
            tb = new DataTable();
            sda.Fill(tb);
            semestrebox.DataSource = tb;
            semestrebox.DisplayMember = "nom_semestre";
            semestrebox.ValueMember = "id_semestre";
            //module
            sc = new SqlCommand("select * from Module M,Filiere F,ChefDpt CH,Semestre S where S.id_semestre= M.id_semestre and M.id_filiere=F.id_filiere and f.id_filiere=CH.id_filiere and F.id_filiere='" + idf + "' and S.Nom_semestre='" + semestrebox.Text + "'", cn);
            sda = new SqlDataAdapter(sc);
            tb = new DataTable();
            sda.Fill(tb);
            modulebox.DataSource = tb;
            modulebox.DisplayMember = "nom_module";
            modulebox.ValueMember = "id_module";
            ///element
            sc = new SqlCommand("select * from Module M,Element EL where M.id_module=EL.id_module and M.nom_module='" + modulebox.Text + "'", cn);
            sda = new SqlDataAdapter(sc);
            tb = new DataTable();
            sda.Fill(tb);
            elementbox.DataSource = tb;
            elementbox.DisplayMember = "nom_element";
            elementbox.ValueMember = "id_element";
            // enseinant
            sc = new SqlCommand("select * from Enseignant E , Element EL where  E.id_element=EL.id_enseignant and EL.id_enseignant='" + elementbox.Text + "'", cn);
            sda = new SqlDataAdapter(sc);
            tb = new DataTable();
            sda.Fill(tb);
            ensbox.DataSource = tb;
            ensbox.DisplayMember = "nom_enseignant";
            ensbox.ValueMember = "id_enseignant";
        }

        private void choix_emploi()
        {
            // pour groupe

            SqlCommand sc = new SqlCommand("select * from Groupe", cn);
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            groupebox.DataSource = tb;
            groupebox.DisplayMember = "nom_groupe";
            groupebox.ValueMember = "id_groupe";

            // pour semestre
            SqlCommand sc1 = new SqlCommand("select * from Semestre", cn);
            sda = new SqlDataAdapter(sc1);
            tb = new DataTable();
            sda.Fill(tb);
            semestrebox.DataSource = tb;
            semestrebox.DisplayMember = "nom_semestre";
            semestrebox.ValueMember = "id_semestre";

        }
        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chef_gestion_emploi_filiere_Load(object sender, EventArgs e)
        {
            choix_emploi();
            refresh();
        }

        private void seance(string jour, string hdebut, string hfin, Label label1, Label label2, Label label3)
        {
            String query = "select * from seance S ,Element M,module MO,semestre Se,Filiere F , Salle SA,Groupe G ,Enseignant E where E.id_enseignant=S.id_enseignant and G.id_groupe=S.id_groupe and SA.id_salle=S.id_salle and  S.id_element=M.id_element and MO.id_semestre=SE.id_semestre and MO.id_module=S.id_module and S.heure_debut='" + hdebut + "' and S.Heure_fine='" + hfin + "' and MO.id_filiere=F.id_filiere and jour='" + jour + "' and nom_semestre='" + semestrebox.Text + "'and F.id_filiere='" + idf + "' and G.nom_groupe = '" + groupebox.Text + "'";
            SqlCommand smd = new SqlCommand(query, cn);
            SqlDataReader dr1 = smd.ExecuteReader();


            if (dr1.Read())
            {
                //label1.Text = (dr1["nom_element"].ToString());
                label3.Text = (dr1["nom_salle"].ToString());
                label1.Text = (dr1["nom_module"].ToString());
                label2.Text = (dr1["nom_enseignant"].ToString());
            }
            else
            {
                label1.Text = "";
                label2.Text = "";
                label3.Text = "";
                //  label4.Text = "";
            }
        }
        private void seance_click(string jour, string hdebut, string hfin)
        {
            String q = "select * from seance S ,Element M,module MO,semestre Se,Filiere F , Salle SA,Groupe G ,Enseignant E where E.id_enseignant=S.id_enseignant and G.id_groupe=S.id_groupe and SA.id_salle=S.id_salle and  S.id_element=M.id_element and MO.id_semestre=SE.id_semestre and MO.id_module=S.id_module and S.heure_debut='" + hdebut + "' and S.heure_fin='" + hfin + "' and MO.id_filiere=F.id_filiere and jour='" + jour + "' and nom_semestre='" + semestrebox.Text + "'and F.id_filiere='" + idf + "' and G.nom_groupe = '" + groupebox.Text + "'";
            SqlCommand sc = new SqlCommand(q, cn);
            SqlDataReader dr1 = sc.ExecuteReader();


            if (dr1.Read())
            {
                idbox.Text = (dr1["id_seance"].ToString());
                elementbox.Text = (dr1["nom_element"].ToString());
                sallebox.Text = (dr1["nom_salle"].ToString());
                modulebox.Text = (dr1["nom_module"].ToString());
                ensbox.Text = (dr1["nom_enseignant"].ToString());
                hdbox.Text = (dr1["heure_debut"].ToString());
                hfbox.Text = (dr1["heure_fin"].ToString());
                jourbox.Text = (dr1["jour"].ToString());
                typebox.Text = (dr1["type_seance"].ToString());

            }
            else
            {
                idbox.Text = "";
                elementbox.Text = "";
                sallebox.Text = "";
                modulebox.Text = "";
                ensbox.Text = "";
                hdbox.Text = "";
                hfbox.Text = "";
                jourbox.Text = "";
                typebox.Text = "";
            }
        }
        private void refresh()
        {
            seance("lundi", "8:00", "9:30", label23, label11, label24);
            seance("lundi", "9:45", "11:15", label27, label26, label25);
            seance("lundi", "11:30", "13:00", label33, label32, label31);
            seance("lundi", "14:00", "15:30", label30, label29, label28);
            seance("lundi", "15:45", "17:15", label39, label38, label37);
            seance("lundi", "17:30", "19:00", label36, label35, label34);

            seance("mardi", "8:00", "9:30", label57, label56, label55);
            seance("mardi", "9:45", "11:15", label51, label50, label49);
            seance("mardi", "11:30", "13:00", label54, label53, label52);
            seance("mardi", "14:00", "15:30", label48, label47, label46);
            seance("mardi", "15:45", "17:15", label45, label44, label43);
            seance("mardi", "17:30", "19:00", label42, label41, label40);

            seance("mercredi", "8:00", "9:30", label93, label92, label91);
            seance("mercredi", "9:45", "11:15", label81, label80, label79);
            seance("mercredi", "11:30", "13:00", label87, label86, label85);
            seance("mercredi", "14:00", "15:30", label75, label74, label73);
            seance("mercredi", "15:45", "17:15", label69, label68, label67);
            seance("mercredi", "17:30", "19:00", label63, label62, label61);

            seance("jeudi", "8:00", "9:30", label90, label89, label88);
            seance("jeudi", "9:45", "11:15", label78, label77, label76);
            seance("jeudi", "11:30", "13:00", label84, label83, label82);
            seance("jeudi", "14:00", "15:30", label72, label71, label70);
            seance("jeudi", "15:45", "17:15", label66, label65, label64);
            seance("jeudi", "17:30", "19:00", label60, label59, label58);

            seance("vendredi", "8:00", "9:30", label111, label110, label109);
            seance("vendredi", "9:45", "11:15", label105, label104, label103);
            seance("vendredi", "11:30", "13:00", label108, label107, label106);
            seance("vendredi", "14:00", "15:30", label102, label101, label100);
            seance("vendredi", "15:45", "17:15", label99, label98, label97);
            seance("vendredi", "17:30", "19:00", label96, label95, label94);


        }
        private void changer_module()
        {
            SqlCommand sc = new SqlCommand("select * from Module M,Filiere F,ChefDpt CH,Semestre S where S.id_semestre= M.id_semestre and M.id_filiere=F.id_filiere and f.id_filiere=CH.id_filiere and F.id_filiere='" + idf + "' and S.nom_semestre='" + semestrebox.Text + "'", cn);
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            modulebox.DataSource = tb;
            modulebox.DisplayMember = "nom_module";
            modulebox.ValueMember = "id_module";
        }

        private void semestrebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh();
            modulebox.DataSource = null;
            changer_module();
        }

        private void semestrebox_SelectedValueChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void groupebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                try
                {
                    SqlCommand cmd = new SqlCommand("ajout_seance", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    TimeSpan time = TimeSpan.Parse(hdbox.Text);
                    TimeSpan time1 = TimeSpan.Parse(hfbox.Text);
                    cmd.Parameters.Add("@jour", SqlDbType.VarChar).Value = jourbox.Text;
                    cmd.Parameters.Add("@hd", SqlDbType.Time).Value = time;
                    cmd.Parameters.Add("@hf", SqlDbType.Time).Value = time1;
                    cmd.Parameters.Add("@ens", SqlDbType.Int).Value = ensbox.SelectedValue;
                    cmd.Parameters.Add("@semestre", SqlDbType.Int).Value = semestrebox.SelectedValue;
                    cmd.Parameters.Add("@element", SqlDbType.Int).Value = elementbox.SelectedValue;
                    cmd.Parameters.Add("@module", SqlDbType.Int).Value = modulebox.SelectedValue;
                    cmd.Parameters.Add("@groupe", SqlDbType.Int).Value = groupebox.SelectedValue;
                    cmd.Parameters.Add("@salle", SqlDbType.Int).Value = sallebox.SelectedValue;
                    cmd.Parameters.Add("@filiere", SqlDbType.Int).Value = idf;
                    cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = typebox.Text;
                cmd.Parameters.Add("@a", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int a = int.Parse(cmd.Parameters["@a"].Value.ToString());

                if (a == 0)
                {
                    MessageBox.Show("seance bien ajouter");
                    refresh();
                }
                else
                {
                    MessageBox.Show("Choisissez un temps disponible");
                    
                }
                }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void modulebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sc = new SqlCommand("select * from Module M,Element MA where M.id_module=MA.id_module and M.nom_module='" + modulebox.Text + "'", cn);
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            elementbox.DataSource = tb;
            elementbox.DisplayMember = "nom_element";
            elementbox.ValueMember = "id_element";
        }

        private void elementbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sc = new SqlCommand("select * from Enseignant E , Element M where  E.id_enseignant=M.id_enseignant and M.nom_element='" + elementbox.Text + "'", cn);
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            ensbox.DataSource = tb;
            ensbox.DisplayMember = "nom_enseignant";
            ensbox.ValueMember = "id_enseignant";
        }

        private void lundi8_Click(object sender, EventArgs e)
        {
            seance_click("Lundi", "8:00", "9:30");
        }

        private void lundi9_Click(object sender, EventArgs e)
        {
            seance_click("Lundi", "9:45", "11:15");
        }

        private void lundi11_Click(object sender, EventArgs e)
        {
            seance_click("Lundi", "11:30", "13:00");
        }

        private void lundi14_Click(object sender, EventArgs e)
        {
            seance_click("Lundi", "14:00", "15:30");
        }

        private void lundi15_Click(object sender, EventArgs e)
        {
            seance_click("Lundi", "15:45", "17:15");
        }

        private void lundi17_Click(object sender, EventArgs e)
        {
            seance_click("Lundi", "17:30", "19:00");
        }
        private void mardi8_Click(object sender, EventArgs e)
        {
            seance_click("mardi", "8:00", "9:30");
        }

        private void mardi9_Click(object sender, EventArgs e)
        {
            seance_click("mardi", "9:45", "11:15");
        }

        private void mardi11_Click(object sender, EventArgs e)
        {
            seance_click("mardi", "11:30", "13:00");
        }

        private void mardi14_Click(object sender, EventArgs e)
        {
            seance_click("mardi", "14:00", "15:30");
        }

        private void mardi15_Click(object sender, EventArgs e)
        {
            seance_click("mardi", "15:45", "17:15");
        }

        private void mardi17_Click(object sender, EventArgs e)
        {
            seance_click("mardi", "17:30", "19:00");
        }
        private void mercredi8_Click(object sender, EventArgs e)
        {
            seance_click("mercredi", "8:00", "9:30");
        }

        private void mercredi9_Click(object sender, EventArgs e)
        {
            seance_click("mercredi", "9:45", "11:15");
        }

        private void mercredi11_Click(object sender, EventArgs e)
        {
            seance_click("mercredi", "11:30", "13:00");
        }

        private void mercredi14_Click(object sender, EventArgs e)
        {
            seance_click("mercredi", "14:00", "15:30");
        }

        private void mercredi15_Click(object sender, EventArgs e)
        {
            seance_click("mercredi", "15:45", "17:15");
        }

        private void mercredi17_Click(object sender, EventArgs e)
        {
            seance_click("mercredi", "17:30", "19:00");
        }
        private void jeudi8_Click(object sender, EventArgs e)
        {
            seance_click("jeudi", "8:00", "9:30");
        }

        private void jeudi9_Click(object sender, EventArgs e)
        {
            seance_click("jeudi", "9:45", "11:15");
        }

        private void jeudi11_Click(object sender, EventArgs e)
        {
            seance_click("jeudi", "11:30", "13:00");
        }

        private void jeudi14_Click(object sender, EventArgs e)
        {
            seance_click("jeudi", "14:00", "15:30");
        }

        private void jeudi15_Click(object sender, EventArgs e)
        {
            seance_click("jeudi", "15:45", "17:15");
        }

        private void jeudi17_Click(object sender, EventArgs e)
        {
            seance_click("jeudi", "17:30", "19:00");
        }
        private void vendredi8_Click(object sender, EventArgs e)
        {
            seance_click("vendredi", "8:00", "9:30");
        }

        private void vendredi9_Click(object sender, EventArgs e)
        {
            seance_click("vendredi", "9:45", "11:15");
        }

        private void vendredi11_Click(object sender, EventArgs e)
        {
            seance_click("vendredi", "11:30", "13:00");
        }

        private void vendredi14_Click(object sender, EventArgs e)
        {
            seance_click("vendredi", "14:00", "15:30");
        }

        private void vendredi15_Click(object sender, EventArgs e)
        {
            seance_click("vendredi", "15:45", "17:15");
        }

        private void vendredi17_Click(object sender, EventArgs e)
        {
            seance_click("vendredi", "17:30", "19:00");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Etes-vous sûr de vouloir modifier cette salle ? ", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("modifie_seance", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    TimeSpan time = TimeSpan.Parse(hdbox.Text);
                    TimeSpan time1 = TimeSpan.Parse(hfbox.Text);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idbox.Text;
                    cmd.Parameters.Add("@jour", SqlDbType.VarChar).Value = jourbox.Text;
                    cmd.Parameters.Add("@hd", SqlDbType.Time).Value = time;
                    cmd.Parameters.Add("@hf", SqlDbType.Time).Value = time1;
                    cmd.Parameters.Add("@ens", SqlDbType.Int).Value = ensbox.SelectedValue;
                    cmd.Parameters.Add("@semestre", SqlDbType.Int).Value = semestrebox.SelectedValue;
                    cmd.Parameters.Add("@element", SqlDbType.Int).Value = elementbox.SelectedValue;
                    cmd.Parameters.Add("@module", SqlDbType.Int).Value = modulebox.SelectedValue;
                    cmd.Parameters.Add("@groupe", SqlDbType.Int).Value = groupebox.SelectedValue;
                    cmd.Parameters.Add("@salle", SqlDbType.Int).Value = sallebox.SelectedValue;
                    cmd.Parameters.Add("@filiere", SqlDbType.Int).Value = idf;
                    cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = typebox.Text;
                    cmd.Parameters.Add("@a", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int a = int.Parse(cmd.Parameters["@a"].Value.ToString());

                    if (a == 0)
                    {
                        MessageBox.Show("seance bien modifier");
                        refresh();
                    }
                    else
                    {
                        MessageBox.Show("Choisissez un temps disponible");

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
                SqlCommand cmd = new SqlCommand("Delete from Seance where id_seance='" + idbox.Text + "'", cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("seance bien supprimer");
                refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
