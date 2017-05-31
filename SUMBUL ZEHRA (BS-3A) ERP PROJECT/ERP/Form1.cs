using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.label3.BackColor = Color.LightSlateGray;
            this.label3.ForeColor = Color.White;
            this.Text = "LOGIN";
            this.BackColor = Color.PaleTurquoise;
            this.ControlBox = false;
            
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.CancelButton = this.button2;
            this.textBox2.MaxLength = 4;
            this.textBox2.PasswordChar = '*';
            this.AcceptButton = this.button1;

            this.label1.BackColor = Color.LightSlateGray;
            this.label1.ForeColor = Color.White;
            this.label1.Text = "USER NAME";

            this.label2.Text = "PASSWORD";
            this.label2.BackColor = Color.LightSlateGray;
            this.label2.ForeColor = Color.White;

            this.button1.Text = "LOGIN";
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.BackColor = Color.LightSlateGray;
            this.button1.ForeColor = Color.White;

            this.button2.Text = "EXIT";
            this.button2.FlatStyle = FlatStyle.Popup;
            this.button2.BackColor = Color.LightSlateGray;
            this.button2.ForeColor = Color.White;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "bs3a" || textBox2.Text == "BS3A")
            {
                Form5 f5 = new Form5();
                f5.Show();

                this.Hide();
            }

            else
            {
                MessageBox.Show("Incorrect Password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }


}
    

