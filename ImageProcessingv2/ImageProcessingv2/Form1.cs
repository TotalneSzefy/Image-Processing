using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingv2
{
    public partial class Form1 : Form
    {
        Image obrazek; //Globalna zmienna do przechowywania obrazu z dysku
        bool otwarto = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void CLOSE_BUTTON_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OPEN_BUTTON_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog(); //otwarcie okna dialogowego i wybranie obrazu
            if (dr == DialogResult.OK) //sprawdzenie czy wybrano sprawny plik
            {
                obrazek = Image.FromFile(openFileDialog1.FileName); //przypisanie wybranego pliku do zmiennej na obrazek
                pictureBox1.Image = obrazek; //wstawienie obrazka do pictue boxa
                otwarto = true;
            }

        }

        private void ZAP_BUTTON_Click(object sender, EventArgs e)
        {
            if (obrazek != null)
            {
                DialogResult dr = saveFileDialog1.ShowDialog();//wybierasz plik do ktorego masz go zapisac

                if (dr == DialogResult.OK) //sprawdzenie czy wybrano sprawny plik
                {
                    obrazek.Save(saveFileDialog1.FileName, obrazek.RawFormat); // zapisuje plik w wybranym pliku z takim samym rozszerzeniem jak orginal
                }
            }
            else
            {
                MessageBox.Show("Otworz najpierw jakis obrazek!");
            }
        }
       
    }
}
