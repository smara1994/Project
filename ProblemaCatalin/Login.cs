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

namespace ProblemaCatalin
{
    public partial class Login : Form
    {
        public Login()
        {            
            InitializeComponent();            
            textBox1.PasswordChar = '*';
        }
        private void Login_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(200, 100);
            this.MaximumSize = new Size(500, 300);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {           
            SqlConnection con = new SqlConnection(@"Data Source=SMARA\SQLEXPRESS;Initial Catalog=Register;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");           
            SqlDataAdapter da = new SqlDataAdapter("Select Role from Register Where Username= '" +textBox2.Text +"' and Password='" + textBox1.Text + "'   " , con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 1 )
            {
                Form1 ss = new Form1();
                ss.Show();
                MessageBox.Show(" Bine ai venit " + textBox2.Text);
                textBox1.Clear();
                textBox2.Clear();
               
                
            }
           else if(textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show(" Te rog adauga userul si parola ");
            }
            else
            {
                MessageBox.Show("Date introduse nu sunt corecte te rog incearca din nou");
                textBox1.Clear();
                textBox2.Clear();
                
            }
                    
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
