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
    public partial class admin_choix_emploi : UserControl
    {
        public admin_choix_emploi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            emploi_salle es = new emploi_salle();
            es.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin_enseignant_emploi_filiere ef = new admin_enseignant_emploi_filiere();
            ef.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chef_emploi_ens ee = new chef_emploi_ens();
            ee.Show();
        }
    }
}
