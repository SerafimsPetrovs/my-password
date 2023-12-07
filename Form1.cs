using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace manager
{
    public partial class mane_panel : Form
    {
        private Point lastPoint;

        public mane_panel()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            citata_TextChanged(this, EventArgs.Empty);
            timer1.Start();
        }

        private void citata_TextChanged(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 11);

            string selectedQuote = "";

            switch (randomNumber)
            {
                case 1:
                    selectedQuote = "\"Neviens cits neizdarīs tavu darbu tāpat labi kā tu pats.\" - Jānis Čakste";
                    break;

                case 2:
                    selectedQuote = "\"Mācies visu laiku, jo tas ir tikai iespēja. Rītdien var būt jau par vēlu.\" - Juris Kaukulis";// //
                    break;

                case 3:
                    selectedQuote = "\"Doma bez darba ir kā putns bez spārniem.\" - Jānis Zālītis";//
                    break;

                case 4:
                    selectedQuote = "\"Dzīvot iespējams dažādi. Bet visi dzīvo mūžīgo leģendu paliekamību.\" - Andrejs Pumpurs";// 
                    break;

                case 5:
                    selectedQuote = "\"Vēlējumos ir slēpjas jūsu nākotne. Ja jums ir griba, jums ir viss, kas nepieciešams.\" - Māris Riekstiņš";
                    break;

                case 6:
                    selectedQuote = "\"Dzīve ir tāda, kāda ir mūsu domas.\" - Māris Čaklais";//
                    break;

                case 7:
                    selectedQuote = "\"Dzīve ir piedzīvojums, kuram jābūt dzīvam, nevis jāsapņo.\" - Māris Čaklais";//
                    break;

                case 8:
                    selectedQuote = "\"Dzīve bez mērķa ir kā ceļojums bez galamērķa.\" - Artis Pabriks";
                    break;
                case 9:
                    selectedQuote = "\"Dzīve nav par to, kā sagaidīt vētru, bet kā dejot lietū.\" - Senā latviešu sakāmvārds";
                    break;
                case 10:
                    selectedQuote = "\"Dzīve ir mācību process, un izglītība dara mūs bagātākus.\" - Māris Čaklais";//
                    break;
                case 11:
                    selectedQuote = "\"Izglītība ir tas, kas paliek pēc tam, kad aiziet visi citi.\" - Elīna Garanča";
                    break;


            }

            citata.Text = selectedQuote;
        }

        private void phonenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            if (phonenumber.Text.Length == 6 && e.KeyChar != (char)Keys.Back)
            {
                phonenumber.Text += "-";
                phonenumber.SelectionStart = phonenumber.Text.Length;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exit_MouseHover(object sender, EventArgs e)
        {
            exit.ForeColor = Color.Green;
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.ForeColor = Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string FindInformationByPhoneNumber(string phoneNumber)
        {
            string fileName = "stud.txt";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, fileName);

            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        if (line.Contains(phoneNumber))
                        {
                            int index = line.IndexOf(phoneNumber);
                            if (index >= 0)
                            {
                                return line.Substring(index + phoneNumber.Length);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Файл не найден по пути: " + filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при чтении файла: " + ex.Message);
            }

            return "Error";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string phoneNumber = phonenumber.Text;

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                string information = FindInformationByPhoneNumber(phoneNumber);
                if (information != "Error")
                {
                    password.Text = "Parole: " + information;
                }
                else
                {
                    password.Text = "Šāds personas kods nav atrasts.";
                }
            }
            else
            {
                password.Text = "Lūdzu, ievadiet savu personas kodu.";
            }
        }

        private void phonenumber_TextChanged(object sender, EventArgs e)
        {
            if (phonenumber.Text.Length == 6)
            {
                phonenumber.Text += "-";
                phonenumber.SelectionStart = phonenumber.Text.Length;
            }
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Green;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void exit_MouseEnter(object sender, EventArgs e)
        {
            exit.ForeColor = Color.Red;
        }

        private void exit_MouseLeave_1(object sender, EventArgs e)
        {
            exit.ForeColor = Color.White;
        }

        private void mane_panel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void mane_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}