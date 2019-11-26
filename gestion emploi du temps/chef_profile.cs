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
    public partial class chef_profile : UserControl
    {
        string nom, prenom, username, filiere, email, tele;
        chef_acceueil accueil;
        public chef_profile(chef_acceueil accueil, string prenom, string nom, string username, string filiere, string email, string tele)
        {
            InitializeComponent();
            this.accueil = accueil;
            this.nom = nom;
            this.prenom = prenom;
            this.username = username;
            this.filiere = filiere;
            this.email = email;
            this.tele = tele;
            nomlabel.Text = nom;
            prenomlabel.Text = prenom;
            userlabel.Text = username;
            filierelabel.Text = filiere;
            emaillabel.Text = email;
            telelabel.Text = tele;
        }
    }
}
