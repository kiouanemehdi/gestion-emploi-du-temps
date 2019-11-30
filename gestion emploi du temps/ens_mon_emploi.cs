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
    public partial class ens_mon_emploi: Form
    {
        SqlConnection cn;
        int idEnseignant;
        public ens_mon_emploi(int idEnseignant)
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-OTRDL55\SQLEXPRESS; Initial Catalog=gestion_emploi; Integrated Security=true ; MultipleActiveResultSets=true;");
            try
            {
                cn.Open();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            InitializeComponent();
            this.idEnseignant = idEnseignant;
        }

        private void ens_mon_emploi_Load(object sender, EventArgs e)
        {
            SqlCommand sc1 = new SqlCommand("select * from Semestre", cn);
            SqlDataAdapter sda = new SqlDataAdapter(sc1);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            semestrebox.DataSource = tb;
            semestrebox.DisplayMember = "nom_semestre";
            semestrebox.ValueMember = "id_semestre";
        }
        private void seance(string jour, string hdebut, string hfin, Label label1, Label label2, Label label3)
        {
            String query = "select * from Seance S ,Element M,Module MO,semestre Se,Filiere F ,Salle SA ,Groupe G ,Enseignant E where E.id_enseignant=S.id_enseignant and G.id_groupe=S.id_groupe and SA.id_salle=S.id_salle and  S.id_element=M.id_element and MO.id_semestre=SE.id_semestre and MO.id_module=S.id_module and S.heure_debut='" + hdebut + "' and S.heure_fin='" + hfin + "' and MO.id_Filiere=F.id_filiere and jour='" + jour + "' and nom_semestre='" + semestrebox.Text + "' and E.Id_enseignant='" + idEnseignant + "'";
            SqlCommand smd = new SqlCommand(query, cn);
            SqlDataReader dr1 = smd.ExecuteReader();


            if (dr1.Read())
            {
                label1.Text = (dr1["nom_module"].ToString());
                label2.Text = (dr1["nom_enseignant"].ToString());
                label3.Text = (dr1["nom_salle"].ToString());
            }
            else
            {
                label1.Text = "";
                label2.Text = "";
                label3.Text = "";
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

        private void semestrebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
