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
    public partial class Form4 : Form
    {
        myconnection mc = new myconnection();

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            this.button1.Cursor = Cursors.Hand;
            this.button2.Cursor = Cursors.Hand;
            this.button3.Cursor = Cursors.Hand;
            this.button4.Cursor = Cursors.Hand;
       
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

            this.label12.BackColor = Color.LightSlateGray;
            this.label12.ForeColor = Color.White;

            this.label13.BackColor = Color.LightSlateGray;
            this.label13.ForeColor = Color.White;
            this.Text = "CUSTOMER MASTER STATUS CHANGE";
            this.label1.Text = "Customer ID";
            this.label2.Text = "Customer Name";
            this.label3.Text = "Address";
            this.label4.Text = "City";
            this.label5.Text = "Phone Number";
            this.label6.Text = "Phone Number 2";
            this.label7.Text = "Contact Person";
            this.label8.Text = "Contact Person Phone Number";
            this.label9.Text = "E-mail";
            this.label10.Text = "Credit Limit";
            this.label11.Text = "Group";
            this.label12.Text = "Status";

            this.button1.Text = "CHANGE STATUS";
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.BackColor = Color.LightSlateGray;
            this.button1.ForeColor = Color.White;

            this.button2.Text = "UPDATE";
            this.button2.FlatStyle = FlatStyle.Popup;
            this.button2.BackColor = Color.LightSlateGray;
            this.button2.ForeColor = Color.White;



            this.button3.Text = "BACK TO HOME SCREEN";
            this.button3.FlatStyle = FlatStyle.Popup;
            this.button3.BackColor = Color.LightSlateGray;
            this.button3.ForeColor = Color.White;

            this.button4.Text = "EXIT";
            this.button4.FlatStyle = FlatStyle.Popup;
            this.button4.BackColor = Color.LightSlateGray;
            this.button4.ForeColor = Color.White;


            this.textBox1.ReadOnly = true;
            this.textBox2.ReadOnly = true;
            this.textBox3.ReadOnly = true;
            this.textBox4.ReadOnly = true;
            this.textBox5.ReadOnly = true;
            this.textBox6.ReadOnly = true;
            this.textBox7.ReadOnly = true;
            this.textBox8.ReadOnly = true;
            this.textBox9.ReadOnly = true;
            this.textBox10.ReadOnly = true;
            comboBox2.Enabled = false;

            mc.conn.Open();

            OleDbCommand cmd = new OleDbCommand("select CID from Customer", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CID"]);
            }
            mc.conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Customer where CID='" + comboBox1.Text + "'", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {


                textBox1.Text = dr["Cname"].ToString();
                textBox2.Text = dr["Caddress"].ToString();
                textBox3.Text = dr["City"].ToString();
                textBox4.Text = dr["PH1"].ToString();
                textBox5.Text = dr["PH2"].ToString();
                textBox6.Text = dr["ContectPerson"].ToString();
                textBox7.Text = dr["CPPH"].ToString();
                textBox8.Text = dr["CEmail"].ToString();
                textBox9.Text = dr["CreditLimit"].ToString();
                textBox10.Text = dr["CGroup"].ToString();
                comboBox2.Text = dr["CStatus"].ToString();

            }
            mc.conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mc.conn.Open();


            OleDbCommand cmd = new OleDbCommand("UPDATE Customer SET   CStatus = '" +comboBox2.Text+ "' WHERE CID = @CID", mc.conn);

            cmd.Parameters.AddWithValue("@CID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@CStatus",comboBox2. Text);

            cmd.ExecuteNonQuery();
            mc.conn.Close();
            MessageBox.Show("Status Changed !");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form5 f5 = new Form5();
            f5.Show();

            this.Hide();
        }


    }
}