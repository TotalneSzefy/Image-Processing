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
        int jasnosc = 0 ;

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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if(obrazek != null)
            {
                JAS_LABEL.Text = trackBar1.Value.ToString(); //ustawianie labelka z wartoscia
                pictureBox1.Image = zmienJasnosc((Bitmap)obrazek, trackBar1.Value); //zmiana jasonsci
            }
            
        }

        private Bitmap zmienJasnosc(Bitmap obraz, int wartosc)
        {
           
            Bitmap temporaryBitMap = obraz; //kopia na stary obrazek
            float FinalValue = (float)wartosc / 255.0f;
            Bitmap newBitmap = new Bitmap(temporaryBitMap.Width, temporaryBitMap.Height); // kopia na nowy obrazek
            Graphics nowaGrafika = Graphics.FromImage(newBitmap);
            //poczatek magicznych rzeczy
            float[][] FloatColorMatrix ={

                    new float[] {1, 0, 0, 0, 0},

                    new float[] {0, 1, 0, 0, 0},

                    new float[] {0, 0, 1, 0, 0},

                    new float[] {0, 0, 0, 1, 0},

                    new float[] {FinalValue, FinalValue, FinalValue, 1, 1}
                };
            ColorMatrix NewColorMatrix = new ColorMatrix(FloatColorMatrix);

            ImageAttributes Attributes = new ImageAttributes();

            Attributes.SetColorMatrix(NewColorMatrix);

            nowaGrafika.DrawImage(temporaryBitMap, new Rectangle(0, 0, temporaryBitMap.Width, temporaryBitMap.Height), 0, 0, temporaryBitMap.Width, temporaryBitMap.Height, GraphicsUnit.Pixel, Attributes);

            Attributes.Dispose();

            nowaGrafika.Dispose();

            return newBitmap;
            //koniec magicznych rzeczy
        }
    }
}
