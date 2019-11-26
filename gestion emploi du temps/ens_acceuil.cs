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
    public partial class ens_acceuil : Form
    {
        connection cn;
        int ida;
        string nom, prenom, username;
        public ens_acceuil(int id)
        {
            InitializeComponent();
            InitializeComponent();
            cn = new connection();
            this.ida = id;
            DataTable dt = cn.query("select * from Enseignant where id_enseignant='" + ida + "'");
            nom = (string)dt.Rows[0]["Nom_enseignant"];
            prenom = (string)dt.Rows[0]["Prenom_enseignant"];
            username = (string)dt.Rows[0]["enseignant_username"];
        }

        private void ens_acceuil_Load(object sender, EventArgs e)
        {

        }
    }
}
