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
    public partial class Form2 : Form
    {
        myconnection mc = new myconnection();


        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            this.button1.Cursor = Cursors.Hand;
           
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
            
            this.button1.Text = "INSERT";
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.BackColor = Color.LightSlateGray;
            this.button1.ForeColor = Color.White;

            this.button3.Text = "BACK TO HOME SCREEN";
            this.button3.FlatStyle = FlatStyle.Popup;
            this.button3.BackColor = Color.LightSlateGray;
            this.button3.ForeColor = Color.White;

            this.button4.Text = "EXIT";
            this.button4.FlatStyle = FlatStyle.Popup;
            this.button4.BackColor = Color.LightSlateGray;
            this.button4.ForeColor = Color.White;

            this.comboBox2.Enabled = false;
            this.comboBox2.Text = "InActive";

            //this.button2.FlatStyle = FlatStyle.Popup;
            //this.button2.BackColor = Color.LightSlateGray;
            //this.button2.ForeColor = Color.White;
            //this.button2.Visible = false;
            //this.button2.Text = "APPROVE";


            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select GrpName from CusGroup", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["GrpName"]);
               
            }
            mc.conn.Close();
            comboBox3.Items.Add("Consumer");
            comboBox3.Items.Add("HR");
            comboBox3.Items.Add("Marketing");
            comboBox3.Items.Add("Sales");
            



        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            mc = new myconnection();
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Customer(CID,Cname,CAddress,City,PH1,PH2,ContectPerson,CPPH,CEmail,CreditLimit,CStatus,CGroup) values(@CID,@Cname,@Address,@City,@PH1,@PH2,@ContectPerson,@CPPH,@CEmail,@CreditLimit,@CStatus,@CGroup)", mc.conn);
            cmd.Parameters.AddWithValue("@CID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Cname", textBox2.Text);
            cmd.Parameters.AddWithValue("@Caddress", textBox3.Text);
            cmd.Parameters.AddWithValue("@City", textBox4.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox5.Text);
            cmd.Parameters.AddWithValue("@PH2", textBox6.Text);
            cmd.Parameters.AddWithValue("@ContectPerson", textBox7.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox8.Text);
            cmd.Parameters.AddWithValue("@CEmail", textBox9.Text);
            cmd.Parameters.AddWithValue("@CCreditLimit", textBox10.Text);
            cmd.Parameters.AddWithValue("@CStatus", comboBox2.Text);
            cmd.Parameters.AddWithValue("@CGroup", comboBox1.Text);
           

            cmd.ExecuteNonQuery();
            mc.conn.Close();
            MessageBox.Show("Record has been added !");
            


            
           
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    this.button1.Visible = false;
        //    this.button2.Visible = true;
        //    this.comboBox2.Enabled = true;
            
        //    this.textBox2.ReadOnly = true;
        //    this.textBox3.ReadOnly = true;
        //    this.textBox4.ReadOnly = true;
        //    this.textBox5.ReadOnly = true;
        //    this.textBox6.ReadOnly = true;
        //    this.textBox7.ReadOnly = true;
        //    this.textBox8.ReadOnly = true;
        //    this.textBox9.ReadOnly = true;
        //    this.textBox10.ReadOnly = true;
        //    this.button5.Visible = true;
        //}

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

     

       

        //private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //}

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            int c = 11;
            mc.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select count(CID) from Customer '" + comboBox3.Text + "'", mc.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]); c++;
            }

            if (comboBox3.Text == "Consumer")
            {
                textBox1.Text = "CUS-CON-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }


            if (comboBox3.Text == "HR")
            {
                textBox1.Text = "CUS-HR-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }

            if (comboBox3.Text == "Marketing")
            {
                textBox1.Text = "CUS-MAR-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }


            if (comboBox3.Text == "Sales")
            {
                textBox1.Text = "CUS-SAL-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }

            mc.conn.Close();

        }

     
}

     

    
        
    }


