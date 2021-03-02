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
    public partial class ens_profile : UserControl
    {
        
        string nom, prenom, username, email, tele;
       

        ens_acceuil accueil;
        public ens_profile(ens_acceuil accueil, string prenom, string nom, string username, string email, string tele)
        {
            InitializeComponent();
            this.accueil = accueil;
            this.nom = nom;
            this.prenom = prenom;
            this.username = username;
            this.email = email;
            this.tele = tele;
            nombox.Text = nom;
            prenombox.Text = prenom;
            userbox.Text = username;
            emailbox.Text = email;
            telebox.Text = tele;
        }
    }
}
