using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_emploi_du_temps
{
    public partial class admin_profile : UserControl
    {
        string nom, prenom, username, email, portable;
        admin_acceuil accueil;
        public admin_profile(admin_acceuil accueil, string prenom, string nom, string username, string email, string portable)
        {
            InitializeComponent();
            this.accueil = accueil;
            this.nom = nom;
            this.prenom = prenom;
            this.username = username;
            this.email = email;
            this.portable = portable;
            label10.Text = nom;
            label9.Text = prenom;
            label8.Text = username;
            label7.Text = email;
            label6.Text = portable;
        }
    }
}
