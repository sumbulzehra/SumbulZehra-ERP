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
    public partial class Form8 : Form
    {
        myconnection mc = new myconnection();

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
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
            this.Text = "VENDOR MASTER SEARCHING";
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

            this.button1.Text = "EDIT";
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.BackColor = Color.LightSlateGray;
            this.button1.ForeColor = Color.White;

            this.button2.Text = "UPDATE";
            this.button2.FlatStyle = FlatStyle.Popup;
            this.button2.BackColor = Color.LightSlateGray;
            this.button2.ForeColor = Color.White;

            this.comboBox2.Visible = false;
        

            this.button3.Text = "BACK TO HOME SCREEN";
            this.button3.FlatStyle = FlatStyle.Popup;
            this.button3.BackColor = Color.LightSlateGray;
            this.button3.ForeColor = Color.White;

            this.button4.Text = "EXIT";
            this.button4.FlatStyle  = FlatStyle.Popup;
            this.button4.BackColor  = Color.LightSlateGray;
            this.button4.ForeColor  = Color.White;
            
            this.textBox1.ReadOnly  = true;
            this.textBox2.ReadOnly  = true;
            this.textBox3.ReadOnly  = true;
            this.textBox4.ReadOnly  = true;
            this.textBox5.ReadOnly  = true;
            this.textBox6.ReadOnly  = true;
            this.textBox7.ReadOnly  = true;
            this.textBox8.ReadOnly  = true;
            this.textBox9.ReadOnly  = true;
            this.textBox10.ReadOnly = true;
            this.textBox12.ReadOnly = true; this.textBox11.ReadOnly = true;


            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select VID from Vendor", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["VID"]);
            }
            mc.conn.Close();
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
               textBox12.Text = dr["VStatus"].ToString();

            }
            mc.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly = false;
            this.textBox2.ReadOnly = false;
            this.textBox3.ReadOnly = false;
            this.textBox4.ReadOnly = false;
            this.textBox5.ReadOnly = false;
            this.textBox6.ReadOnly = false;
            this.textBox7.ReadOnly = false;
            this.textBox8.ReadOnly = false;
            this.textBox9.ReadOnly = false;
            this.textBox10.ReadOnly = false;
            this.textBox12.ReadOnly = true;
            this.textBox11.Visible = false;
           
            this.comboBox2.Visible = true;
       

            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select GrpName from CusGroup", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["GrpName"]);
            }
            mc.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("UPDATE Vendor SET Vname = '" + textBox1.Text + "' ,VCode = '" + textBox2.Text + "',VCity = '" + textBox3.Text + "' ,VAddress = '" + textBox4.Text + "',PH1= '" + textBox5.Text + "',PH2='" + textBox6.Text + "',CPName= '" + textBox7.Text + "',CPPH = '" + textBox8.Text + "',VEmail= '" + textBox9.Text + "',VFax= '" + textBox10.Text + "',VGroup= '" + comboBox2.Text + "',VStatus='" + textBox12.Text + "' WHERE VID = @VID", mc.conn);

            cmd.Parameters.AddWithValue("@VID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Vname", textBox1.Text);
            cmd.Parameters.AddWithValue("@VCode", textBox2.Text);
            cmd.Parameters.AddWithValue("@VCity", textBox3.Text);
            cmd.Parameters.AddWithValue("@VAddress", textBox4.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox5.Text);
            cmd.Parameters.AddWithValue("@PH2", textBox6.Text);
            cmd.Parameters.AddWithValue("@CPName", textBox7.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox8.Text);
            cmd.Parameters.AddWithValue("@VEmail", textBox9.Text);
            cmd.Parameters.AddWithValue("@VFax", textBox10.Text);
            cmd.Parameters.AddWithValue("@VGroup", comboBox2.Text);
            //cmd.Parameters.AddWithValue("@VStatus", comboBox3.Text);

            cmd.ExecuteNonQuery();
            mc.conn.Close();
            MessageBox.Show("Record has been Updated !");
           
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
    }
}
  
