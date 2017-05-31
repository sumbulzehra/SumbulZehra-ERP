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
    public partial class Form13 : Form
    {
        string[] prds = new string[50];
        int[] qty = new int[50];
        int[] amount = new int[50];
        int counter = 0;
        myconnection mc = new myconnection();

        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            this.button1.Cursor = Cursors.Hand;
            this.button2.Cursor = Cursors.Hand;
            this.button3.Cursor = Cursors.Hand;
            this.button4.Cursor = Cursors.Hand;
            this.button5.Cursor = Cursors.Hand;
            this.label1.BackColor = Color.LightSlateGray;
            this.label1.ForeColor = Color.White;
            this.label14.BackColor = Color.LightSlateGray;
            this.label14.ForeColor = Color.White;

            this.label2.BackColor = Color.LightSlateGray;
            this.label2.ForeColor = Color.White;
            this.label16.BackColor = Color.LightSlateGray;
            this.label16.ForeColor = Color.White;

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
            this.button4.Text = "BACK TO HOME SCREEN";
            this.button4.FlatStyle = FlatStyle.Popup;
            this.button4.BackColor = Color.LightSlateGray;
            this.button4.ForeColor = Color.White;

            this.button5.Text = "EXIT";
            this.button5.FlatStyle = FlatStyle.Popup;
            this.button5.BackColor = Color.LightSlateGray;
            this.button5.ForeColor = Color.White;

            this.Text = "Purchase Order";
            this.label1.Text = "Purchase Order ID";
            this.label2.Text = "Delivery Date";
            this.groupBox1.Text = "ID Generation";
            this.groupBox2.Text = "Customer Information";
            this.groupBox3.Text = "Sales Order";
            this.label3.Text = "Customer ID";
            this.label4.Text = "Customer Name";
            this.label5.Text = "Customer Department";
            this.label6.Text = "Contact Person";
            this.label7.Text = "Contact Person\nPhone Number";
            this.button1.Text = "CALCULATE AMOUNT";
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.BackColor = Color.LightSlateGray;
            this.button1.ForeColor = Color.White;

            this.button2.Text = ">>";
            this.button2.FlatStyle = FlatStyle.Popup;
            this.button2.BackColor = Color.LightSlateGray;
            this.button2.ForeColor = Color.White;

            this.button3.Text = "ADD";
            this.button3.FlatStyle = FlatStyle.Popup;
            this.button3.BackColor = Color.LightSlateGray;
            this.button3.ForeColor = Color.White;


            this.textBox2.ReadOnly = true;
            this.textBox3.ReadOnly = true;
            this.textBox4.ReadOnly = true;
            this.textBox5.ReadOnly = true;
            this.textBox1.ReadOnly = true;

            this.textBox6.ReadOnly = true;
            this.textBox7.ReadOnly = true;
            this.textBox9.ReadOnly = true;



            this.label8.Text = "Product ID";
            this.label9.Text = "Product Name";
            this.label10.Text = "Unit Price";
            this.label11.Text = "Quantity";
            this.label12.Text = "Total Amount";
            this.label13.Text = "Product ID";
            this.label14.Text = "Total Amount";




            mc.conn.Open();

            OleDbCommand cmd1 = new OleDbCommand("select Pid from Sproducts", mc.conn);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox3.Items.Add(dr1["Pid"]);
            }
            mc.conn.Close();

            mc.conn.Open();

            OleDbCommand cmd2 = new OleDbCommand("select CID from Customer", mc.conn);
            OleDbDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox2.Items.Add(dr2["CID"]);
            }
            mc.conn.Close();




            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select GrpName from CusGroup", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["GrpName"]);

            }
            mc.conn.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Customer where CID='" + comboBox2.Text + "'", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                textBox2.Text = dr["Cname"].ToString();
                textBox3.Text = dr["CGroup"].ToString();
                textBox4.Text = dr["ContectPerson"].ToString();
                textBox5.Text = dr["CPPH"].ToString();
            }
            mc.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox7.Text);
            double b = Convert.ToDouble(textBox8.Text);
            textBox9.Text = (a * b).ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Sproducts where Pid='" + comboBox3.Text + "'", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox6.Text = dr["Pname"].ToString();
                textBox7.Text = dr["PPrice"].ToString();
            }
            mc.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox17.Text += textBox8.Text + Environment.NewLine;
            textBox10.Text += comboBox3.Text + Environment.NewLine;
            textBox11.Text += textBox9.Text + Environment.NewLine;
            prds[counter] = comboBox3.Text;
            qty[counter] = Convert.ToInt32(textBox8.Text);
            amount[counter] = Convert.ToInt32(textBox9.Text);



            counter++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mc.conn.Open();

            OleDbCommand cmd = new OleDbCommand("insert into SO(SOID,Sdate,status,approve,cdept,cname,cid,CP,CPPH) values(@SOID,@Sdate,@status,@approve,@cdept,@cname,@cid,@CP,@CPPH)", mc.conn);
            cmd.Parameters.AddWithValue("@SOID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Sdate", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@status", "Open");
            cmd.Parameters.AddWithValue("@approve", "DisApproved");
            cmd.Parameters.AddWithValue("@cdept", textBox3.Text);
            cmd.Parameters.AddWithValue("@cname", textBox2.Text);
            cmd.Parameters.AddWithValue("@cid", comboBox2.Text);
            cmd.Parameters.AddWithValue("@CP", textBox4.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox5.Text);
            cmd.ExecuteNonQuery();
            mc.conn.Close();

            mc.conn.Open();
            for (int i = 0; i < counter; i++)
            {
                OleDbCommand cmd1 = new OleDbCommand("insert into SOPro(SOID,Pid,PQty,PCost) values(@SOID,@Pid,@PQty,@PCost)", mc.conn);
                cmd1.Parameters.AddWithValue("@SOID", textBox1.Text);
                cmd1.Parameters.AddWithValue("@Pid", comboBox3.Text);
                cmd1.Parameters.AddWithValue("@PQty", textBox8.Text);
                cmd1.Parameters.AddWithValue("@PCost", textBox9.Text);
                cmd1.ExecuteNonQuery();
            }

            mc.conn.Close();
            MessageBox.Show("Sales Order Created");
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int c = 0;
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select count(SOID) from SO where cdept='" + comboBox1.Text + "'", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }
            if (comboBox1.Text == "Consumer")
            {
                textBox1.Text = "SO-CON-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            if (comboBox1.Text == "HR")
            {
                textBox1.Text = "SO-HR-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }

            if (comboBox1.Text == "Marketing")
            {
                textBox1.Text = "SO-MAR-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }


            if (comboBox1.Text == "Sales")
            {
                textBox1.Text = "SO-SAL-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            mc.conn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();

            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }


}