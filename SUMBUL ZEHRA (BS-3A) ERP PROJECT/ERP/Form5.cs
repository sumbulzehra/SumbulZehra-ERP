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
    public partial class Form5 : Form
    {
        myconnection mc = new myconnection();

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.PaleTurquoise;

            this.FormBorderStyle = FormBorderStyle.Fixed3D;


            this.button1.Cursor = Cursors.Hand;
            this.button2.Cursor = Cursors.Hand;
            this.button3.Cursor = Cursors.Hand;
            this.button4.Cursor = Cursors.Hand;
            this.button5.Cursor = Cursors.Hand;


            this.button6.Cursor = Cursors.Hand;
            this.button7.Cursor = Cursors.Hand;
            this.button8.Cursor = Cursors.Hand;
            this.button9.Cursor = Cursors.Hand;
            this.button10.Cursor = Cursors.Hand;

            this.button16.Cursor = Cursors.Hand;
            this.button17.Cursor = Cursors.Hand;
            this.button18.Cursor = Cursors.Hand;
            this.button19.Cursor = Cursors.Hand;
            this.button20.Cursor = Cursors.Hand;

            this.button11.Cursor = Cursors.Hand;
            this.button12.Cursor = Cursors.Hand;
            this.button13.Cursor = Cursors.Hand;
            this.button14.Cursor = Cursors.Hand;
            this.button15.Cursor = Cursors.Hand;

            this.Text = "HOME SCREEN";
            this.button13.Text = "EXIT";
            this.button13.FlatStyle = FlatStyle.Popup;
            this.button13.BackColor = Color.LightSlateGray;
            this.button13.ForeColor = Color.White;
            this.Text = "HOME SCREEN";
            this.button3.Text = "CUSTOMER";
            this.button3.FlatStyle = FlatStyle.Popup;
            this.button3.BackColor = Color.LightSlateGray;
            this.button3.ForeColor = Color.White;

            this.button4.Text = "VENDOR";
            this.button4.FlatStyle = FlatStyle.Popup;
            this.button4.BackColor = Color.LightSlateGray;
            this.button4.ForeColor = Color.White;

            this.button1.Text = "BUSINESS PARTNER";
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.BackColor = Color.LightSlateGray;
            this.button1.ForeColor = Color.White;


            this.button2.Text = "PURCHASE ORDER";
            this.button2.FlatStyle = FlatStyle.Popup;
            this.button2.BackColor = Color.LightSlateGray;
            this.button2.ForeColor = Color.White;

            this.button20.FlatStyle = FlatStyle.Popup;
            this.button20.BackColor = Color.LightSlateGray;
            this.button20.ForeColor = Color.White;



            this.button5.Text = "INSERT NEW RECORD";
            this.button5.FlatStyle = FlatStyle.Popup;
            this.button5.BackColor = Color.LightSlateGray;
            this.button5.ForeColor = Color.White;

            this.button14.Text = "GOODS RECEIVING NOTES";
            this.button14.FlatStyle = FlatStyle.Popup;
            this.button14.BackColor = Color.LightSlateGray;
            this.button14.ForeColor = Color.White;

            this.button15.Text = "INVOICE";
            this.button15.FlatStyle = FlatStyle.Popup;
            this.button15.BackColor = Color.LightSlateGray;
            this.button15.ForeColor = Color.White;


            this.button6.Text = "SEARChING OF RECORD";
            this.button6.FlatStyle = FlatStyle.Popup;
            this.button6.BackColor = Color.LightSlateGray;
            this.button6.ForeColor = Color.White;

            this.button7.Text = "CHANGE STATUS";
            this.button7.FlatStyle = FlatStyle.Popup;
            this.button7.BackColor = Color.LightSlateGray;
            this.button7.ForeColor = Color.White;

            this.button8.Text = "INSERT NEW RECORD";
            this.button8.FlatStyle = FlatStyle.Popup;
            this.button8.BackColor = Color.LightSlateGray;
            this.button8.ForeColor = Color.White;


            this.button9.Text = "SEARChING OF RECORD";
            this.button9.FlatStyle = FlatStyle.Popup;
            this.button9.BackColor = Color.LightSlateGray;
            this.button9.ForeColor = Color.White;

            this.button10.Text = "CHANGE STATUS";
            this.button10.FlatStyle = FlatStyle.Popup;
            this.button10.BackColor = Color.LightSlateGray;
            this.button10.ForeColor = Color.White;

            this.button11.Text = "PURCHASE ORDER CREATION";
            this.button11.FlatStyle = FlatStyle.Popup;
            this.button11.BackColor = Color.LightSlateGray;
            this.button11.ForeColor = Color.White;

            this.button12.Text = "PURCHASE ORDER APPROVAL";
            this.button12.FlatStyle = FlatStyle.Popup;
            this.button12.BackColor = Color.LightSlateGray;
            this.button12.ForeColor = Color.White;

            this.button13.FlatStyle = FlatStyle.Popup;
            this.button13.BackColor = Color.LightSlateGray;
            this.button13.ForeColor = Color.White;
            this.button14.FlatStyle = FlatStyle.Popup;
            this.button14.BackColor = Color.LightSlateGray;
            this.button14.ForeColor = Color.White;
            this.button15.FlatStyle = FlatStyle.Popup;
            this.button15.BackColor = Color.LightSlateGray;
            this.button15.ForeColor = Color.White;
            this.button16.FlatStyle = FlatStyle.Popup;
            this.button16.BackColor = Color.LightSlateGray;
            this.button16.ForeColor = Color.White;
            this.button17.FlatStyle = FlatStyle.Popup;
            this.button17.BackColor = Color.LightSlateGray;
            this.button17.ForeColor = Color.White;
            this.button18.FlatStyle = FlatStyle.Popup;
            this.button18.BackColor = Color.LightSlateGray;
            this.button18.ForeColor = Color.White;

            this.button19.FlatStyle = FlatStyle.Popup;
            this.button19.BackColor = Color.LightSlateGray;
            this.button19.ForeColor = Color.White;
            this.button3.Visible = false;
            this.button4.Visible = false;
            this.button5.Visible = false;
            this.button6.Visible = false;
            this.button7.Visible =false;
            this.button8.Visible = false;
            this.button9.Visible = false;
            this.button10.Visible = false;
            this.button11.Visible = false;
            this.button12.Visible = false;
            this.Text = "HOME SCREEN";
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button3.Visible = true;
            this.button4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.button5.Visible = true;
            this.button6.Visible = true;
            this.button7.Visible = true;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.button8.Visible = true;
            this.button9.Visible = true;
            this.button10.Visible = true;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show(); this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Form4 f4 = new Form4();
            f4.Show(); this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show(); this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show(); this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show(); this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button11.Visible = true;
            this.button12.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

        private void button14_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
            this.Hide();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            button17.Visible = true;
            button19.Visible = true;

        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.Show();
            this.Hide();

        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            f14.Show();
            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Form15 f15 = new Form15();
            f15.Show();
            this.Hide();
        
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Show();
            this.Hide();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            Form12 F12 = new Form12();
            F12.Show();
            this.Hide();
        }
    }
}
