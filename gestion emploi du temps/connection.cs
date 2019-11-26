using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace gestion_emploi_du_temps
{
    
    class connection
    {
        public SqlConnection conn;
        public connection()
        {
            this.conn = new SqlConnection(@"Data Source=DESKTOP-NK0LUDA\KIOUANE; Initial Catalog=gestion_emploi; Integrated Security=true;MultipleActiveResultSets=true;");
        }
        //select * dans une table entree//
        public DataTable select_table(string table)
        {
            DataTable dt = new DataTable();
            using(conn)
            {
                using(SqlCommand cmd=new SqlCommand("select * from "+table,conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            return dt;
        }
        // lire une requete//
        public DataTable query(string requete)
        {
            DataTable dt = new DataTable();
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(requete, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            return dt;
        }

        public bool execute_query(string requete)
        {
            try 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(requete, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            
            }
            catch
            {
                return false;
            }
        }
    }
}
