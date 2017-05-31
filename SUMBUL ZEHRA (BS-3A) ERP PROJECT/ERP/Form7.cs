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
    public partial class Form7 : Form
    { 
        myconnection mc = new myconnection();

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            this.button1.Cursor = Cursors.Hand;
            this.button2.Cursor = Cursors.Hand;
            this.button3.Cursor = Cursors.Hand;
            this.button4.Cursor = Cursors.Hand;
       
            this.label1.BackColor = Color.LightSlateGray;
            this.label1.ForeColor = Color.White;
            this.label14.BackColor = Color.LightSlateGray;
            this.label14.ForeColor = Color.White;

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
            
            this.Text = "VENDOR MASTER CHANGE STATUS";
            this.label1.Text = "Vendor ID";
            this.label2.Text = "Vendor Name";
            this.label3.Text = "Vendor Code";
            this.label4.Text = "Vendor City";
            this.label5.Text = "Vendor Address";
            this.label6.Text = "Phone Number 1";
            this.label7.Text = "Phone Number 2";
            this.label8.Text = "Contact Person";
            this.label9.Text = "Contact Person Phone Number";
            this.label10.Text = "Vendor E-mail";
            this.label11.Text = "Vendor Fax";
            this.label12.Text = "Vendor Group";
            this.label13.Text = "Vendor Status";

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
            this.textBox11.ReadOnly = true;

            comboBox2.Enabled = false;

            mc.conn.Open();

            OleDbCommand cmd = new OleDbCommand("select VID from Vendor", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["VID"]);
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


            OleDbCommand cmd = new OleDbCommand("UPDATE Vendor SET  VStatus = '" +comboBox2.Text+ "' WHERE VID = @VID", mc.conn);

            cmd.Parameters.AddWithValue("@VID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@VStatus", comboBox2.Text);

            cmd.ExecuteNonQuery();
            mc.conn.Close();
            MessageBox.Show("Status Changed !");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form5 f5 = new Form5();
            f5.Show();

            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Vendor where VID='" + comboBox1.Text + "'", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr["Vname"].ToString();
                textBox2.Text = dr["VCode"].ToString();
                textBox3.Text = dr["VCity"].ToString();
                textBox4.Text = dr["VAddress"].ToString();
                textBox5.Text = dr["PH1"].ToString();
                textBox6.Text = dr["PH2"].ToString();
                textBox7.Text = dr["CPName"].ToString();
                textBox8.Text = dr["CPPH"].ToString();
                textBox9.Text = dr["VEmail"].ToString();
                textBox10.Text = dr["VFax"].ToString();
                textBox11.Text = dr["VGroup"].ToString();
               comboBox2.Text= dr["VStatus"].ToString();

            }
            mc.conn.Close();
        }
    }
}
