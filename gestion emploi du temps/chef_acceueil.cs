using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_emploi_du_temps
{
    public partial class chef_acceueil : Form
    {
        private connection cn;
        private string filiere;
        public string Filiere { get => filiere; set => filiere = value; }
      
        private string nom;
        public static int filierecef;
        public string Nom { get => nom; set => nom = value; }
        private string prenom;
        public string Prenom { get => prenom; set => prenom = value; }
        private string email;
        private string tele;
        private string username;
        public string Username { get => username; set => username = value; }
        private int idFiliere;
        public int IdFiliere { get => idFiliere; set => idFiliere = value; }
        private int id;
        public int Id { get => id; set => id = value; }
        public chef_acceueil(int id)
        {
            InitializeComponent();
            cn = new connection();
            this.id = id;
            DataTable dt = cn.query("select * from ChefDpt C,Filiere F where F.id_Filiere=C.id_Filiere and C.id_Chef='" + id + "'");
            idFiliere = (int)dt.Rows[0]["id_filiere"];
            filiere = (string)dt.Rows[0]["nom_filiere"];
            filierecef = idFiliere;
            nom = (string)dt.Rows[0]["nom"];
            prenom = (string)dt.Rows[0]["prenom"];
             email = (string)dt.Rows[0]["email"];
            username = (string)dt.Rows[0]["chef_username"];
              tele = (string)dt.Rows[0]["portable"];
            label1.Text = prenom + " " + nom;
            label3.Text = "" + filiere;

        }
        private void afficher_milieu(Control c)
        {
            if (!milieu.Controls.Contains(c))
            {
                milieu.Controls.Add(c);
              //  c.Dock = DockStyle.Fill;
                c.BringToFront();
                // c.Actualiser();
            }
            else
            {
                c.BringToFront();
                //  c.Actualiser();
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chef_acceueil_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(""+IdFiliere);
            chef_profile cp = new chef_profile(this, prenom, nom, username, filiere, email, tele);
            afficher_milieu(cp);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chef_gestion_ens ge = new chef_gestion_ens();
            afficher_milieu(ge);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chef_gestion_salle gs = new chef_gestion_salle();
            afficher_milieu(gs);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chef_gestion_module gm = new chef_gestion_module();
            afficher_milieu(gm);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            chef_gestion_element gs = new chef_gestion_element();
            afficher_milieu(gs);
        }
        /*private void Gest_Click(object sender, EventArgs e)
        {
            chef_gestion_element gs = new chef_gestion_element();
            afficher_milieu(gs);
        }*/
        private void button5_Click(object sender, EventArgs e)
        {
            chef_choix_emploi ce = new chef_choix_emploi(idFiliere);
            afficher_milieu(ce);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chef_profile cp = new chef_profile(this,prenom,nom,username,filiere,email,tele);
            afficher_milieu(cp);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public static int getfilere() { return filierecef; }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoginAcceuill login = new LoginAcceuill();
            login.Show();
            this.Close();
        }
    }
}
