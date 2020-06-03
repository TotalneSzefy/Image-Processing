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
        Bitmap obrazAsync;

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
        {//JPG|*.jpg|PNG|*.png|BMP|*.bmp
            obrazek = pictureBox1.Image;
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
                
            }
            
        }

        private void ZmienJasnosci(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            obrazAsync = (Bitmap) obrazek.Clone();
            byte[] LUT = new byte[256];
            int b = (int) e.Argument;

            for (int i = 0; i < LUT.Length; i++)
            {
                if ((b + i) > 255)
                {
                    LUT[i] = 255;
                }
                else if ((b + i) < 0)
                {
                    LUT[i] = 0;
                }
                else
                {
                    LUT[i] = (byte)(b + i);
                }
            }

            Bitmap bitmap = (Bitmap)obrazAsync.Clone();
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            byte[] pixels = new byte[Math.Abs(bmpData.Stride) * bitmap.Height];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixels, 0, pixels.Length);
            for (int i = 1; i < pixels.Length; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else{
                    pixels[i] = LUT[pixels[i]];
                    if (i % 1000 == 0)
                    {
                        worker.ReportProgress(i * 100 / pixels.Length);
                        System.Threading.Thread.Sleep(5);
                    }
                }
            }

            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                System.Runtime.InteropServices.Marshal.Copy(pixels, 0, bmpData.Scan0, pixels.Length);
                bitmap.UnlockBits(bmpData);
                obrazAsync = bitmap;
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void RunWorkerComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                progressBar1.Value = 0;
            }
            else
            {
                obrazek = obrazAsync;
                pictureBox1.Image = obrazAsync;
                progressBar1.Value = 100;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!PracownikWsteczny.IsBusy)
            {
                //Bitmap bitmapa = (Bitmap) pictureBox1.Image;
                PracownikWsteczny.RunWorkerAsync(argument: trackBar1.Value);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PracownikWsteczny.IsBusy)
            {
                PracownikWsteczny.CancelAsync();
            }
        }
    }
}
