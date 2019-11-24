using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace gestion_emploi_du_temps
{
  
    public partial class Form2 : Form
    {
       SqlConnection cnn;
        public Form2()
        {
            InitializeComponent();
            //Sql serever Connection
          string connectionString;
           //  string sql = null;
           // SqlCommand command;
          //   SqlDataReader reader;
            connectionString = @"Data Source=DESKTOP-OTRDL55;Initial Catalog=gestion_emploi;User ID=simo;Password=@simo123";
            cnn = new SqlConnection(connectionString);
          /*  try
            {
                cnn.Open();
                MessageBox.Show("connect to  the database successefuly");
                 command = new SqlCommand(sql, cnn);
                 reader = command.ExecuteReader();
                 while(reader.Read())
                 {
                     MessageBox.Show(reader.GetValue(0) + "-");
                 }
                 reader.Close();
                command.Dispose();
                cnn.Close();
            }
            catch(Exception ex)
            {
              MessageBox.Show("can not connect to  the database");
                
            }*/
        }
        
       //This Function are called by every (Login button )in the 3 user controll forms (Bdel smiya d la BD ou password)
        public  void checkLogin(string userType)
        {
           
                string userName;
                string password;
                string sql;
                int rowsNumber;
                bool found = false;
                SqlCommand command;
                cnn.Open();//Oppening the connection 
                if (userType=="Admin")
                {
                   userName = userControl11.Username;
                    password = userControl11.Password;
                    sql = "select Nom , Prenom from  ChefDepartement where admin_username=username and admin_password=password "; 
                    command = new SqlCommand(sql, cnn);
                    command.ExecuteNonQuery();
                    rowsNumber = (int)command.ExecuteScalar();
                    if(rowsNumber>=1)
                       found = true;
              
                }else if(userType=="chef")
                {
                    userName =userControl21.Username;
                    password = userControl21.Password;
                    sql = "select Nom , Prenom from ChefDepartement where chef_username=username and chef_password=password ";
                    command = new SqlCommand(sql, cnn);
                    command.ExecuteNonQuery();
                    rowsNumber = (int)command.ExecuteScalar();
                     if ( rowsNumber >= 1)
                        found = true;
                }
                else if (userType == "Enseignant")
              
                {
                    userName = userControl31.Username;
                    password = userControl31.Password;
                    sql = "select Nom_enseignant, Penom_enseignat from  Admini where enseignat_username=username and enseignat_password=password ";
                    command = new SqlCommand(sql, cnn);
                   command.ExecuteNonQuery();
                    rowsNumber = (int)command.ExecuteScalar();
                  if (rowsNumber >= 1)
                      found = true;
                }

            if (found)
                MessageBox.Show("Connect successful");
            else
                MessageBox.Show("Username or password Wrong !! ");
           

        }
        //the 3 function bellow reffer to the 3 button in Form2
        private void button1_Click(object sender, EventArgs e)
        {
            userControl21.Hide();
            userControl31.Hide();
            userControl11.Show();
            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl31.Hide();
            userControl21.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl21.Hide();
            userControl31.Show();
        }
        private void userControl21_Load(object sender, EventArgs e)
        {

        }

        private void userControl31_Load(object sender, EventArgs e)
        {

        }
    }
}
