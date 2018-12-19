using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace hostel_management
{
    public partial class Form1 : Form
    {
        private string connectionstring;
        private MySqlConnection connection;
        
         
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            connectionstring = "server=localhost;database=hosteldb;Uid=root;pwd=0787879540";
            connection = new MySqlConnection(connectionstring);
            connection.Open();
        }

            private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
          

        private void login_Click_1(object sender, EventArgs e)
        {
            var usernameText = username.Text;
            var passwordText = password.Text;

            var selectCommand = new MySqlCommand();
            selectCommand.CommandText = "select * from users where username=@username AND password =@password";
            selectCommand.Parameters.AddWithValue("@username",usernameText);
            selectCommand.Parameters.AddWithValue("@password",passwordText);

            selectCommand.Connection = connection;
            MySqlDataReader dataReader = selectCommand.ExecuteReader();
            if (dataReader.Read())
            {
                MessageBox.Show("login successful");
            }

            else
            {
                MessageBox.Show("Invalid Username or password");
            }




        }

        


        }
    }

