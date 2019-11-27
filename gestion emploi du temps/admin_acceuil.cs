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
    public partial class admin_acceuil : Form
    {
        private connection cn;
        private int ida;
        private string nom;
        private string prenom;
        private string username;
        private string email;
        private string portable;

        public int get_ida()
        {
            return this.ida;
        }
        public void set_ida(int ida)
        {
            this.ida = ida;
        }
        public string get_nom()
        {
            return this.nom;
        }
        public void set_nom(string nom)
        {
            this.nom = nom;
        }
        public string get_prenom()
        {
            return this.prenom;
        }
        public void set_prenom(string prenom)
        {
            this.prenom = prenom;
        }
        public string get_username()
        {
            return this.username;
        }
        public void set_username(string username)
        {
            this.username = username;
        }
        public admin_acceuil(int id)
        {
            InitializeComponent();
          cn = new connection();
            this.ida = id;
            DataTable dt = cn.query("select * from Administrateur where id_admin='"+ida+"'");
            nom = (string)dt.Rows[0]["nom"];
            prenom = (string)dt.Rows[0]["prenom"];
            username = (string)dt.Rows[0]["admin_username"];
            email = (string)dt.Rows[0]["admin_username"];
            portable = (string)dt.Rows[0]["admin_username"];
        }
        // pour afficher user cotrle au milieu de panel//
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

        private void admin_acceuil_Load(object sender, EventArgs e)
        {
            
            admin_profile ap = new admin_profile(this, prenom, nom, username, email, portable);
            afficher_milieu(ap);
           // ap.Dock = DockStyle.Fill;
            //this.Controls.Add(ap);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin_profile ap1 = new admin_profile(this, prenom, nom, username, email, portable);
            afficher_milieu(ap1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin_gestion_chef gc = new admin_gestion_chef();
            afficher_milieu(gc);
            /*gc.Dock = DockStyle.Fill;
            this.Controls.Add(gc);
            milieu.Controls.Add(gc);*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            admin_gestion_filiere gf = new admin_gestion_filiere();
            afficher_milieu(gf);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            admin_choix_emploi ce = new admin_choix_emploi();
            afficher_milieu(ce);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void milieu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
