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
    public partial class Form14 : Form
    {
        myconnection mc = new myconnection();
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {

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

            this.Text = "Sales Order Approval";
            this.label1.Text = "Sales Order ID";
            this.label2.Text = "Customer ID";
            this.label3.Text = "Customer Name";
            this.label4.Text = "Delivery Date";
            this.label5.Text = "Approval";


            this.button1.Text = "APPROVE";
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




            mc.conn.Open();

            OleDbCommand cmd = new OleDbCommand("select SOID from SO WHERE [Approve]='DisApproved'", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["SOID"]);
            }
            mc.conn.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from SO where SOID='" + comboBox1.Text + "'", mc.conn);


            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr["cid"].ToString();
                textBox2.Text = dr["cname"].ToString();
                textBox3.Text = dr["Sdate"].ToString();
                comboBox2.Text = dr["approve"].ToString();

            }



            mc.conn.Close();

            mc.conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select Pid,PQty,PCost from SOPro where SOID='" + comboBox1.Text + "'", mc.conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            mc.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mc.conn.Open();

            OleDbCommand cmd = new OleDbCommand("UPDATE SO SET   approve = '" + comboBox2.Text + "' WHERE SOID ='" + comboBox1.Text + "' ", mc.conn);
            cmd.ExecuteReader();
            mc.conn.Close();
            MessageBox.Show("Sales Order Approved !!");
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
    }
}
