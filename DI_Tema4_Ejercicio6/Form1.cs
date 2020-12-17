using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        List<Button> buttons;

        public string password = "1234";
        public int countPin = 1;

        //==========================================================================================

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(127, 120, 121);
            this.Text = "Contacts";
            this.button1.Tag = false;
            buttons = new List<Button>();

            Form2 form2 = new Form2();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (form2.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (form2.textBox1.Text == password)
                    {
                        MessageBox.Show("Contraseña correcta");
                        form2.Close();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta");
                        if (countPin == 3)
                        {
                            MessageBox.Show("Pusiste mal la contraseña 3 veces.\nEl programa se cerrará");
                            form2.Close();
                            Environment.Exit(0);
                        }
                        else
                        {
                            form2.ShowDialog();
                        }
                        countPin++;
                    }
                }
            }
            //form2.Dispose();


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
                    btn.Tag = false;
                    buttons.Add(btn);
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
            if (!(bool)btnEnter.Tag)
            {
                btnEnter.BackColor = Color.FromArgb(232, 212, 205);
            }

        }

        private void ButtonCursorLeave(object sender, EventArgs e)
        {
            Button btnLeave = (Button)sender;
            if (!(bool)btnLeave.Tag)
            {
                btnLeave.BackColor = Color.FromArgb(238, 232, 226);
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button btnClick = (Button)sender;
            if (btnClick != button1)
            {
                btnClick.BackColor = Color.FromArgb(165, 145, 148);
                textBox1.Text += btnClick.Text;
                btnClick.Tag = true;
            }
            else
            {
                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].BackColor = Color.FromArgb(238, 232, 226);
                    buttons[i].Tag = false;
                }
                textBox1.Text = "";
            }
        }

        private void AboutUs(object sender, EventArgs e)
        {
            MessageBox.Show("Todos sobre mi");
        }

        private void ResetMenu(object sender, EventArgs e)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].BackColor = Color.FromArgb(238, 232, 226);
                buttons[i].Tag = false;
            }
            textBox1.Text = "";
        }

        private void SaveNumber(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.FilterIndex = 2;
                sfd.RestoreDirectory = true;
                sfd.OverwritePrompt = false;//para que no pregunte si queremos reescribir
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName,true))
                    {
                        sw.WriteLine(textBox1.Text);
                    }
                    MessageBox.Show("Guardado");
                }
            }
            else
            {
                MessageBox.Show("No hay nada para grabar");
            }
            
        }

        private void Exit(object sender, EventArgs e)
        {
            //Environment.Exit(0);
            this.Close();
        }
    }


}

