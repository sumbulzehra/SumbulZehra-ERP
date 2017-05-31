using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Form12 : Form
    {
        myconnection mc = new myconnection();

        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {

            this.button1.Cursor = Cursors.Hand;
            this.button2.Cursor = Cursors.Hand;
            this.button3.Cursor = Cursors.Hand;
            this.button4.Cursor = Cursors.Hand;
          
            this.button1.Text = "CREATE INVOICE";
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.BackColor = Color.LightSlateGray;
            this.button1.ForeColor = Color.White;
            this.button4.Text = ">>";
            this.button4.FlatStyle = FlatStyle.Popup;
            this.button4.BackColor = Color.LightSlateGray;
            this.button4.ForeColor = Color.White;
            this.button2.Text = "BACK TO HOME SCREEN";
            this.button2.FlatStyle = FlatStyle.Popup;
            this.button2.BackColor = Color.LightSlateGray;
            this.button2.ForeColor = Color.White;
            this.button3.Text = "EXIT";
            this.button3.FlatStyle = FlatStyle.Popup;
            this.button3.BackColor = Color.LightSlateGray;
            this.button3.ForeColor = Color.White;
            this.label1.BackColor = Color.LightSlateGray;
            this.label1.ForeColor = Color.White;

            this.label2.BackColor = Color.LightSlateGray;
            this.label2.ForeColor = Color.White;

            this.label3.BackColor = Color.LightSlateGray;
            this.label3.ForeColor = Color.White;

            this.label4.BackColor = Color.LightSlateGray;
            this.label4.ForeColor = Color.White;

            this.label5.BackColor = Color.LightSlateGray;
            this.label5.ForeColor = Color.White;

            this.label6.BackColor = Color.LightSlateGray;
            this.label6.ForeColor = Color.White;

            this.label7.BackColor = Color.LightSlateGray;
            this.label7.ForeColor = Color.White;

            this.label8.BackColor = Color.LightSlateGray;
            this.label8.ForeColor = Color.White;

            this.label9.BackColor = Color.LightSlateGray;
            this.label9.ForeColor = Color.White;

            this.label10.BackColor = Color.LightSlateGray;
            this.label10.ForeColor = Color.White;


            this.label11.BackColor = Color.LightSlateGray;
            this.label11.ForeColor = Color.White;



            mc.conn.Open();
            OleDbCommand cmd1 = new OleDbCommand("select GRNID from GRN where Status='Open';", mc.conn);
            OleDbDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["GRNID"]);

            }
            mc.conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from GRN where GRNID= '" + comboBox1.Text + "';", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                this.textBox9.Text = dr["POID"].ToString();

                this.textBox2.Text = dr["DDate"].ToString();
                this.textBox3.Text = dr["GRDate"].ToString();
                this.textBox4.Text = dr["VID"].ToString();
                this.textBox5.Text = dr["VName"].ToString();
                this.textBox6.Text = dr["VCP"].ToString();
                this.textBox7.Text = dr["VCPPH"].ToString();
            }
            mc.conn.Close();

            mc.conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select PModel,PQty,PCost from POProducts where POID='" + textBox9.Text + "'", mc.conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            mc.conn.Close();


        }



        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            this.textBox8.Text = "INVOICE_" + comboBox1.Text;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {


        }

        private void button4_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
            }
            textBox1.Text = sum.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mc.conn.Open();

            OleDbCommand cmd = new OleDbCommand("insert into Invoice(GRNID,AmountPayable,DDate,GRDate,IVDate,VendorID,VendorName,ContectPerson,CPPH,POID,InvoiceNo)values(@GRNID,@AmountPayable,@DDate,@GRDate,@IVDate,@VendorID,@VendorName,@ContectPerson,@CPPH,@POID,@InvoiceNo);", mc.conn);
            cmd.Parameters.AddWithValue("@GRNID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@AmountPayable", textBox1.Text);
            cmd.Parameters.AddWithValue("@DDate", textBox2.Text);
            cmd.Parameters.AddWithValue("@GRDate", textBox3.Text);
            cmd.Parameters.AddWithValue("@IVDate", textBox10.Text);
            cmd.Parameters.AddWithValue("@VendorID", textBox4.Text);
            cmd.Parameters.AddWithValue("@VendorName", textBox5.Text);
            cmd.Parameters.AddWithValue("@ContectPerson", textBox6.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox7.Text);
            cmd.Parameters.AddWithValue("@POID", textBox9.Text);
            cmd.Parameters.AddWithValue("@InvoiceNo", textBox8.Text);


            cmd.ExecuteNonQuery();
            mc.conn.Close();

            mc.conn.Open();
            OleDbCommand cmd1 = new OleDbCommand("UPDATE GRN SET  [Status]='Close'  WHERE GRNID ='" + comboBox1.Text + "' ", mc.conn);
            cmd1.ExecuteReader();
            mc.conn.Close();
            MessageBox.Show("Invoice has been Created..!!");
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox10.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}