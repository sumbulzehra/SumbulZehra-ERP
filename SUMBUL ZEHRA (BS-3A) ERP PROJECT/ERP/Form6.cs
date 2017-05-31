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
    public partial class Form6 : Form
    {
        myconnection mc = new myconnection();

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

            this.button1.Cursor = Cursors.Hand;
            this.button2.Cursor = Cursors.Hand;
            this.button3.Cursor = Cursors.Hand;
          
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
            this.Text = "VENDOR MASTER";
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

            this.button1.Text = "INSERT";
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.BackColor = Color.LightSlateGray;
            this.button1.ForeColor = Color.White;

            this.button2.Text = "BACK TO HOME SCREEN";
            this.button2.FlatStyle = FlatStyle.Popup;
            this.button2.BackColor = Color.LightSlateGray;
            this.button2.ForeColor = Color.White;

            this.button3.Text = "EXIT";
            this.button3.FlatStyle = FlatStyle.Popup;
            this.button3.BackColor = Color.LightSlateGray;
            this.button3.ForeColor = Color.White;

            this.comboBox3.Enabled = false;
            this.comboBox3.Text = "InActive";

            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select GrpName from CusGroup", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["GrpName"]);

            }
            mc.conn.Close();
            comboBox2.Items.Add("Consumer");
            comboBox2.Items.Add("HR");
            comboBox2.Items.Add("Marketing");
            comboBox2.Items.Add("Sales");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form5 f5 = new Form5();
            f5.Show();

            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = 1;
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select count(VID) from Vendor '" + comboBox1.Text + "'", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]); c++;
            }

            if (comboBox1.Text == "Consumer")
            {
                textBox1.Text = "VEN-CON-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }


            if (comboBox1.Text == "HR")
            {
                textBox1.Text = "VEN-HR-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }

            if (comboBox1.Text == "Marketing")
            {
                textBox1.Text = "VEN-MAR-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }


            if (comboBox1.Text == "Sales")
            {
                textBox1.Text = "VEN-SAL-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }

            mc.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mc = new myconnection();
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Vendor(VID,Vname,VCode,VCity,VAddress,PH1,PH2,CPName,CPPH,VEmail,VFax,VGroup,VStatus) values(@VID,@Vname,@VCode,@VCity,@VAddress,@PH1,@PH2,@CPName,@CPPH,@VEmail,@VFax,@VGroup,@VStatus)", mc.conn);
            cmd.Parameters.AddWithValue("@VID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Vname", textBox2.Text);
            cmd.Parameters.AddWithValue("@VCode", textBox3.Text);
            cmd.Parameters.AddWithValue("@VCity", textBox4.Text);
            cmd.Parameters.AddWithValue("@VAddress", textBox5.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox6.Text);
            cmd.Parameters.AddWithValue("@PH2", textBox7.Text);
            cmd.Parameters.AddWithValue("@CPName", textBox8.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox9.Text);
            cmd.Parameters.AddWithValue("@VEmail", textBox10.Text);
            cmd.Parameters.AddWithValue("@VFax", textBox11.Text);
            cmd.Parameters.AddWithValue("@VGroup", comboBox2.Text);
            cmd.Parameters.AddWithValue("@VStatus", comboBox3.Text);
           


            cmd.ExecuteNonQuery();
            mc.conn.Close();
            MessageBox.Show("Record has been added !");
        }
    }
}
