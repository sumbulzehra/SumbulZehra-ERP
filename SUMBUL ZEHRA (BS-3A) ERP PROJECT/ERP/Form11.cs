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
    public partial class Form11 : Form
    {
        myconnection mc = new myconnection();

        public Form11()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form11_Load(object sender, EventArgs e)
        {

            this.button1.Cursor = Cursors.Hand;
            this.button2.Cursor = Cursors.Hand;
            this.button3.Cursor = Cursors.Hand;
         
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select POID from PO WHERE [Approve]='Approved' and [Status]='Open' ", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["POID"]);

            }
            mc.conn.Close();
            this.button1.Text = "CREATE GRN";
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

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        //private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        //{
        //    this.textBox7.Text = "GRN_" + comboBox1.Text;
        //}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select PModel,PQty,PCost from POProducts where POID='" + comboBox1.Text + "'", mc.conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            mc.conn.Close();

            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from PO where POID='" + comboBox1.Text + "'", mc.conn);


            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr["VID"].ToString();
                textBox2.Text = dr["Vname"].ToString();
                textBox3.Text = dr["VDept"].ToString();
                textBox4.Text = dr["VContectPerson"].ToString();
                textBox5.Text = dr["VCPPH"].ToString();
                textBox6.Text = dr ["DCDate"].ToString();

            }



            mc.conn.Close();
        }

        //private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        //{
            
        //}

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            this.textBox7.Text = "GRN_" + comboBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into GRN(POID,VID,VName,VDept,VCP,VCPPH,Status,DDate,DCDate,GRDate,GRNID) values(@POID,@VID,@VName,@VDept,@VCP,@VCPPH,@Status,@DDate,@DCDate,@GRDate,@GRNID)", mc.conn);
            cmd.Parameters.AddWithValue("@POID",comboBox1.Text);
            cmd.Parameters.AddWithValue("@VID", textBox1.Text);
            cmd.Parameters.AddWithValue("@VName", textBox2.Text);
            cmd.Parameters.AddWithValue("@VDept", textBox3.Text);
            cmd.Parameters.AddWithValue("@VCP", textBox4.Text);
            cmd.Parameters.AddWithValue("@VCPPH", textBox5.Text);
            cmd.Parameters.AddWithValue("@Status", "Open");
            cmd.Parameters.AddWithValue("@DDate", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@DCDate", textBox6.Text);
            cmd.Parameters.AddWithValue("@GRDate", textBox8.Text);
            cmd.Parameters.AddWithValue("@GRNID", textBox7.Text);
            cmd.ExecuteNonQuery();
            mc.conn.Close();

            mc.conn.Open();

            OleDbCommand cmd1 = new OleDbCommand("UPDATE PO SET  [Status]='Close'  WHERE POID ='" + comboBox1.Text + "' ", mc.conn);
            cmd1.ExecuteReader();
            mc.conn.Close();
            MessageBox.Show("GRN Created !");
            

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox8.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

      
    }
}
