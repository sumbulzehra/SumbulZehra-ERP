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
    public partial class Form10 : Form
    {
        myconnection mc = new myconnection();
        public Form10()
        {
            InitializeComponent();
        }



        private void Form10_Load(object sender, EventArgs e)
        {

            this.button1.Cursor = Cursors.Hand;
            this.button2.Cursor = Cursors.Hand;
            this.button3.Cursor = Cursors.Hand;
        

            // TODO: This line of code loads data into the 'pC_DBDataSet.POProducts' table. You can move, or remove it, as needed.
            this.pOProductsTableAdapter.Fill(this.pC_DBDataSet.POProducts);


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

            this.Text = "Purchase Order Approval";
            this.label1.Text = "PurcHase Order ID";
            this.label2.Text = "Vendor ID";
            this.label3.Text = "Vendor Name";
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

            OleDbCommand cmd = new OleDbCommand("select POID from PO WHERE [Approve]='Not Approved'", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["POID"]);
            }
            mc.conn.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from PO where POID='" + comboBox1.Text + "'", mc.conn);


            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr["VID"].ToString();
                textBox2.Text = dr["Vname"].ToString();
                textBox3.Text = dr["DCDate"].ToString();
                comboBox2.Text = dr["Approve"].ToString();

            }



            mc.conn.Close();

            mc.conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select PModel,PQty,PCost from POProducts where POID='" + comboBox1.Text + "'", mc.conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            mc.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mc.conn.Open();

            OleDbCommand cmd = new OleDbCommand("UPDATE PO SET   Approve = '" + comboBox2.Text + "' WHERE POID ='" + comboBox1.Text + "' ", mc.conn);
            cmd.ExecuteReader();
            mc.conn.Close();
            MessageBox.Show("Purchase Order Approved !!");


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

       
        //private void button4_Click(object sender, EventArgs e)
        //{
        // int sum = 0;
        //      for (int i = 0; i < dataGridView1.Rows.Count; ++i)
        //        {
        //            sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
        //        }
        //        textBox4.Text = sum.ToString();
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    int a = 0;
        //    foreach (DataGridViewRow r in dataGridView1.Rows)
        //    {
        //        {int c;
        //            a += Convert.ToInt32(r.Cells[0].Value);
        //        }
        //    }

            //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            //{
            //    int sum = 0;
            //    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            //    {
            //        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[i].Value);
            //    }
            //    textBox4.Text = sum.ToString();

            //}










        }
    }

