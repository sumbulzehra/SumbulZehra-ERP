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
    public partial class Form15 : Form
    {
        myconnection mc = new myconnection();

        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select SOID from SO WHERE [approve]='Approved' and [status]='Open' ", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["SOID"]);

            }
            mc.conn.Close();
            this.button1.Text = "CREATE DELIVERY CHALLAN";
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

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select Pid,PQty,PCost from SOPro where SOID='" + comboBox1.Text + "'", mc.conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            mc.conn.Close();

            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from SO where SOID='" + comboBox1.Text + "'", mc.conn);


            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr["cid"].ToString();
                textBox2.Text = dr["cname"].ToString();
                textBox3.Text = dr["cdept"].ToString();
                textBox4.Text = dr["CP"].ToString();
                textBox5.Text = dr["CPPH"].ToString();
                textBox6.Text = dr["Sdate"].ToString();

            }
            mc.conn.Close();

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox8.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            this.textBox7.Text = "DC_" + comboBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into DC(SOID,CID,CName,CDept,CP,CPPH,Status,D_Date,Del_On,DCGeneration,DCID) values(@SOID,@CID,@CName,@CDept,@CP,@CPPH,@Status,@D_Date,@Del_On,@DCGeneration,@DCID)", mc.conn);
            cmd.Parameters.AddWithValue("@SOID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@CID", textBox1.Text);
            cmd.Parameters.AddWithValue("@CName", textBox2.Text);
            cmd.Parameters.AddWithValue("@CDept", textBox3.Text);
            cmd.Parameters.AddWithValue("@CP", textBox4.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox5.Text);
            cmd.Parameters.AddWithValue("@Status", "Open");
            cmd.Parameters.AddWithValue("@D_Date", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@Del_On", textBox6.Text);
            cmd.Parameters.AddWithValue("@DCGeneration", textBox8.Text);
            cmd.Parameters.AddWithValue("@DCID", textBox7.Text);
            cmd.ExecuteNonQuery();
            mc.conn.Close();

            mc.conn.Open();

            OleDbCommand cmd1 = new OleDbCommand("UPDATE SO SET  [Status]='Close'  WHERE SOID ='" + comboBox1.Text + "' ", mc.conn);
            cmd1.ExecuteReader();
            mc.conn.Close();
            MessageBox.Show("Delivery Challan Created !");
            
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
