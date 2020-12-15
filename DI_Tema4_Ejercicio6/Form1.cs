using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI_Tema4_Ejercicio6
{
    public partial class Form1 : Form
    {
        public Button btn;
        public string numbers = "123456789*0#";
        public int count = 0;
        public int x = 15;
        public int y = 15;

        //==========================================================================================

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(127, 120, 121);
            this.Text = "Contacts";
        }

        private void GenerateButtons(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    btn = new System.Windows.Forms.Button();
                    btn.Width = 50;
                    btn.Height = 50;
                    btn.Location = new Point(x, y);
                    btn.Text = "" + numbers[count];
                    btn.FlatStyle = FlatStyle.Standard;
                    btn.Font = new System.Drawing.Font("Console", 10, FontStyle.Regular);
                    btn.BackColor = Color.FromArgb(238, 232, 226);
                    btn.MouseEnter += new System.EventHandler(this.BUttonCursorEnter);
                    btn.MouseLeave += new System.EventHandler(this.ButtonCursorLeave);
                    btn.Click += new System.EventHandler(this.ButtonClick);
                    this.panel1.Controls.Add(btn);
                    if (j == 2)
                    {
                        x = 15;
                    }
                    else
                    {
                        x = x + 50 + 15;
                    }
                    count++;
                }
                y = y + 50 + 15;
            }

        }

        private void BUttonCursorEnter(object sender, EventArgs e)
        {
            Button btnEnter = (Button)sender;
            btnEnter.BackColor = Color.FromArgb(232, 212, 205);
           
        }

        private void ButtonCursorLeave(object sender, EventArgs e)
        {
            Button btnLeave = (Button)sender;
           
                btnLeave.BackColor = Color.FromArgb(238, 232, 226);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button btnClick = (Button)sender;
            btnClick.BackColor = Color.FromArgb(217, 195, 189);
        }
    }
}
