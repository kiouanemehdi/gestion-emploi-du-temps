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
        connection cn;
        int ida;
        string nom, prenom, username;
        public chef_acceueil(int id)
        {
            InitializeComponent();
            cn = new connection();
            this.ida = id;
            DataTable dt = cn.query("select * from Enseignant where id_enseignant='" + ida + "'");
            nom = (string)dt.Rows[0]["Nom"];
            prenom = (string)dt.Rows[0]["Prenom"];
            username = (string)dt.Rows[0]["chef_username"];
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chef_acceueil_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
