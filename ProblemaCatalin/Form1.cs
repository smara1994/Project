using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;

namespace ProblemaCatalin
{
    public partial class Form1 : Form

    {
        int ID = 0;
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        DataTable dt;
        SqlCommandBuilder scb;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
           
            
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'problemaCatalinDataSet2.Table_1' table. You can move, or remove it, as needed.
            this.table_1TableAdapter1.Fill(this.problemaCatalinDataSet2.Table_1);
            // TODO: This line of code loads data into the 'problemaCatalinDataSet1.Table_1' table. You can move, or remove it, as needed.
            this.table_1TableAdapter.Fill(this.problemaCatalinDataSet1.Table_1);
            // TODO: This line of code loads data into the 'problemaCatalinDataSet.Table1' table. You can move, or remove it, as needed.
            this.table1TableAdapter.Fill(this.problemaCatalinDataSet.Table1);
            // TODO: This line of code loads data into the 'database2DataSet4.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter4.Fill(this.database2DataSet4.Table);
            DisplayData();




        }
        private void button1_Click(object sender, EventArgs e)

        {
            SqlConnection con = new SqlConnection();
            con = new SqlConnection(@"Data Source=SMARA\SQLEXPRESS;Initial Catalog=ProblemaCatalin;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("insert into [dbo].[Table_1] (studentId, Nume, Prenume,Localitatea,Strada,Bloc,Apartament,Tara,Facultatea, Varsta) VALUES(@studentId, @Nume, @Prenume, @Localitatea,@Strada,@Bloc,@Apartament,@Tara,@Facultatea,@Varsta )", con);
            if(textBox1.Text == string.Empty || textBox2.Text == string.Empty ||  textBox4.Text == string.Empty || textBox5.Text == string.Empty || textBox6.Text == string.Empty || textBox7.Text == string.Empty || textBox8.Text == string.Empty || textBox9.Text == string.Empty || textBox10.Text == string.Empty || textBox11.Text == string.Empty)
            {
                MessageBox.Show(" Va rog completati toate campurile ");
            }
            else
            {
                cmd.Parameters.Add("@studentId", textBox10.Text);
                cmd.Parameters.Add("@Nume", textBox1.Text);
                cmd.Parameters.Add("@Prenume", textBox2.Text);
                cmd.Parameters.Add("@Localitatea", textBox4.Text);
                cmd.Parameters.Add("@Strada", textBox5.Text);
                cmd.Parameters.Add("@Bloc", textBox6.Text);
                cmd.Parameters.Add("@Apartament", textBox7.Text);
                cmd.Parameters.Add("@Tara", textBox8.Text);
                cmd.Parameters.Add("@Facultatea", textBox9.Text);
                cmd.Parameters.Add("@Varsta", textBox11.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                MessageBox.Show("Insertul a fost initializat cu succes");
                textBox10.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox11.Clear();
            }
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            con = new SqlConnection(@"Data Source=SMARA\SQLEXPRESS;Initial Catalog=ProblemaCatalin;Integrated Security=True");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da = new SqlDataAdapter("SELECT * FROM  [dbo].[Table_1] ", con);
            BindingSource b1 = new BindingSource();
            da.Fill(dt);
            b1.DataSource = dt;
            dataGridView1.DataSource = b1;

           
        }
        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";

        }


        private void button4_Click(object sender, EventArgs e)
        {


            DialogResult dr = MessageBox.Show("Are you sure to save Changes", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {

                SqlConnection con = new SqlConnection();
                con = new SqlConnection(@"Data Source=SMARA\SQLEXPRESS;Initial Catalog=ProblemaCatalin;Integrated Security=True");
                SqlCommand cmddd = new SqlCommand();

                con.Open();
                cmddd = new SqlCommand("update [dbo].[Table_1] set studentId=@studentId, Nume=@Nume, Prenume=@Prenume,Localitatea=@Localitatea,Strada=@Strada,Bloc=Bloc,Apartament=@Apartament,Tara=@Tara,Facultatea=@Facultatea,Varsta=@Varsta where ID=@id)", con);
                
                cmddd.Parameters.AddWithValue("@studentId", textBox10.Text);
                cmddd.Parameters.AddWithValue("@Nume", textBox1.Text);
                cmddd.Parameters.AddWithValue("@Prenume", textBox2.Text);
                cmddd.Parameters.AddWithValue("@Localitatea", textBox4.Text);
                cmddd.Parameters.AddWithValue("@Strada", textBox5.Text);
                cmddd.Parameters.AddWithValue("@Bloc", textBox6.Text);
                cmddd.Parameters.AddWithValue("@Apartament", textBox7.Text);
                cmddd.Parameters.AddWithValue("@Tara", textBox8.Text);
                cmddd.Parameters.AddWithValue("@Facultatea", textBox9.Text);
                cmddd.Parameters.AddWithValue("@Varsta", textBox11.Text);
                cmddd.Parameters.AddWithValue("@id", ID);
               
                cmddd.ExecuteNonQuery();
                con.Close();
                DisplayData();
                ClearData();
                MessageBox.Show("Record Updated Successfully");






            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=SMARA\SQLEXPRESS;Initial Catalog=ProblemaCatalin;Integrated Security=True");
            da = new SqlDataAdapter(@"SELECT * FROM  [dbo].[Table_1] ", con);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            chart1.DataSource = dt;
            chart1.Show();
            MessageBox.Show("Acestea sunt toate datele din baza de date");

        }
        public void DisplayData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=SMARA\SQLEXPRESS;Initial Catalog=ProblemaCatalin;Integrated Security=True");
            da = new SqlDataAdapter(@"SELECT * FROM  [dbo].[Table_1] ", con);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            chart1.DataSource = dt;
            chart1.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esti sigur ca vrei sa stergi aceasta inregistrare?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=SMARA\SQLEXPRESS;Initial Catalog=ProblemaCatalin;Integrated Security=True");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("DELETE FROM [dbo].[Table_1] WHERE studentId = '" + textBox12.Text + "' ", con);
                da.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Inregistrare stearsa cu succes");
                textBox12.Clear();

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format("Nume Like '%{0}%'", textBox3.Text);
            dataGridView1.DataSource = DV;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void time_lbl_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {


        }
        private void button6_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=SMARA\SQLEXPRESS;Initial Catalog=ProblemaCatalin;Integrated Security=True");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da = new SqlDataAdapter("SELECT Varsta FROM  [dbo].[Table_1] ", con);

            da.Fill(dt);
            chart1.DataSource = da;
            table1BindingSource2.DataSource = da;
            //   chart1.DataBind();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "MS Excel (*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox13.Text = openfile.FileName;
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string path = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox13.Text + ";Extended Properties=" + "\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
            OleDbConnection conn = new OleDbConnection(path);
            OleDbDataAdapter myDt = new OleDbDataAdapter("Select * From [Sheet1$]", conn);
            DataTable DT = new DataTable();
            myDt.Fill(DT);
            dataGridView2.DataSource = DT;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
            pdfTable.DefaultCell.Padding = 10;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {

                    if (cell.Value != null)
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                    }
                }
            }
            string folderPath = @"C:\Users\popes\Desktop\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "DataGridViewExport.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A1);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
                MessageBox.Show("Fisierul a fost exportat cu succes");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            Process.Start("IExplore", "https://www.facebook.com/popescu.george.12");
        }
        private void button10_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dataGridView2.Columns.Count);
            pdfTable.DefaultCell.Padding = 20;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {

                    if (cell.Value != null)
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                    }
                }
            }
            string folderPath = @"C:\Users\popes\Desktop\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
                MessageBox.Show("Fisierul a fost exportat cu succes");
            }
        }

        private void UpdateClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString());
        }
    }
}

    

