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
	public partial class EnseignantHour : UserControl
	{
		SqlConnection cn;
		int nombreheureenseigne;
		public EnseignantHour()
		{
			cn = new SqlConnection(@"Data Source=DESKTOP-OTRDL55\SQLEXPRESS; Initial Catalog=gestion_emploi; Integrated Security=true ; MultipleActiveResultSets=true;");
			cn.Open();
			InitializeComponent();
			int ide;
			ide = ens_acceuil.getEndeignantid();
			SqlCommand cmd = new SqlCommand("heureEnseigne", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@idE", SqlDbType.Int).Value = ide;
			cmd.Parameters.Add("@a", SqlDbType.Int).Direction = ParameterDirection.Output;
			cmd.ExecuteNonQuery();
			nombreheureenseigne = int.Parse(cmd.Parameters["@a"].Value.ToString());
			nombreheureenseigne /= 3600;
			textBox1.Text = nombreheureenseigne.ToString();
			//	SqlCommand cmd=new SqlCommand("")
		}

		private void EnseignantHour_Load(object sender, EventArgs e)
		{
			 
		}
		
	}
}
