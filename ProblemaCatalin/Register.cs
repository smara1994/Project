using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProblemaCatalin
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox3.Enabled = false;
           
        }

        private void Register_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(200, 100);
            this.MaximumSize = new Size(500, 300);
            
            
            


        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=SMARA\SQLEXPRESS;Initial Catalog=Register;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            if (textBox1.Text == string.Empty || textBox2.Text.Trim() == string.Empty )
            {
                MessageBox.Show("Te rog completeaza toate campurile"); 
                return;
            }

            bool exist = false;
            using (SqlCommand cmdd = new SqlCommand("select count(*) from [dbo].[Register] where Username = @Username", con))
            {
                cmdd.Parameters.AddWithValue("Username", textBox1.Text);
                exist = (int)cmdd.ExecuteScalar() > 0;
            }
            if (exist)
                MessageBox.Show(textBox1.Text, " Aces user este folosit te rog alege alt nume ");
            else
            {
                SqlCommand cmd;
                cmd = new SqlCommand("insert into [dbo].[Register] ( Username, Password, Role) VALUES(@Username, @Password, @Role )", con);
                cmd.Parameters.Add("@Username", textBox1.Text);
                cmd.Parameters.Add("@Password", textBox2.Text);
                cmd.Parameters.Add("@Role", textBox3.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Login lo = new Login();
                lo.ShowDialog();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                con.Close();
                this.Close();
            }
            
          
            
        }

        private void button2_Click(object sender, EventArgs e)
        {          
            Login sh = new Login();
            sh.Show();            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
