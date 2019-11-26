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

    public partial class chef_choix_emploi : UserControl
    {
        int idf;
        public chef_choix_emploi(int idf)
        {
            InitializeComponent();
            this.idf = idf;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            emploi_salle es = new emploi_salle();
            es.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chef_gestion_emploi_filiere ef = new chef_gestion_emploi_filiere(idf);
            ef.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chef_emploi_ens es = new chef_emploi_ens();
            es.Show();
        }
    }
}
