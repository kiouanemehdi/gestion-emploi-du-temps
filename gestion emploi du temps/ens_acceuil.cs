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
    public partial class ens_acceuil : Form
    {
        private connection cn;
        private string nom;
        public string Nom { get => nom; set => nom = value; }
        private string prenom;
        public string Prenom { get => prenom; set => prenom = value; }
        private string email;
        private string tele;
        private string username;
        public string Username { get => username; set => username = value; }
        private int idAdmin;
        public int IdEnseignant { get => idAdmin; set => idAdmin = value; }
        public ens_acceuil(int id)
        {
            InitializeComponent();
            InitializeComponent();
            cn = new connection();
            this.IdEnseignant = id;
            DataTable dt = cn.query("select * from Enseignant where id_enseignant='" + IdEnseignant + "'");
            nom = (string)dt.Rows[0]["nom_enseignant"];
            prenom = (string)dt.Rows[0]["prenom_enseignant"];
            username = (string)dt.Rows[0]["ens_username"];
            tele = (string)dt.Rows[0]["portable"];
            email = (string)dt.Rows[0]["email"];
        }

        private void ens_acceuil_Load(object sender, EventArgs e)
        {
            ens_profile p = new ens_profile(this, prenom, nom, username, email, tele);
            afficher_milieu(p);
        }
        private void afficher_milieu(Control c)
        {
            if (!milieu.Controls.Contains(c))
            {
                milieu.Controls.Add(c);
                //c.Dock = DockStyle.Fill;
                c.BringToFront();
            }
            else
            {
                c.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ens_profile p = new ens_profile(this, prenom, nom, username, email, tele);
            afficher_milieu(p);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            emploi_salle es = new emploi_salle();
            es.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ens_mon_emploi me = new ens_mon_emploi(IdEnseignant);
            me.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            admin_enseignant_emploi_filiere ef = new admin_enseignant_emploi_filiere();
            ef.Show();
        }
    }
}
