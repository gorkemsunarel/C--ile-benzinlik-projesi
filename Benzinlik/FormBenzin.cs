using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Benzinlik
{
    public partial class FormGidis1 : Form
    {
        public FormGidis1()
        {
            InitializeComponent();
        }
        int benzinLitreFiyati = 38;
        int motorinLitreFiyatı = 37;
        int lpgLitreFiyatı = 17;
        //int saniye;
        //int benzinLitreToplam;
        //int motorinLitreToplam;
        //int toplam = 0;





        //int lpgLitreToplam;

        int pompa1Sol = 136;
        int pompa2Sol = 318;
        int pompa3Sol = 478;
        int pompa1Ust = 150;
        int pompa2Ust = 200;
        int pompa3Ust = 250;
        bool pompa1Bos = true;
        bool pompa2Bos = true;
        bool pompa3Bos = true;
        int pompa1Litre = 0;
        int pompa2Litre = 0;
        int pompa3Litre = 0;
        int pompa1Saniye = 0;
        int pompa2Saniye = 0;
        int pompa3Saniye = 0;
        DateTime pompa1Baslama;
        DateTime pompa2Baslama;
        DateTime pompa3Baslama;

        int arabaFormSonuLeft = 670;
        PictureBox yeniAraba1 = new PictureBox();
        PictureBox yeniAraba2 = new PictureBox();
        PictureBox yeniAraba3 = new PictureBox();
        bool yeniAraba1Gonderildi = false;
        bool yeniAraba2Gonderildi = false;
        bool yeniAraba3Gonderildi = false;
        bool yeniAraba1DepoDoldu = false;
        bool yeniAraba2DepoDoldu = false;
        bool yeniAraba3DepoDoldu = false;



        private void FormGidis1_Load(object sender, EventArgs e)
        {

            tmrPompa1.Enabled = false;
            tmrPompa2.Enabled = false;
            tmrSari.Enabled = false;

            tmrAraba.Enabled = false;


            BtnPompa2.Text = "Boş";
            pompa2Bos = true;
            BtnPompa2.BackColor = Color.Yellow;

            btnPompa3.Text = "Boş";
            pompa3Bos = true;
            btnPompa3.BackColor = Color.Yellow;

            btnPompa1.Text = "Boş";
            pompa1Bos = true;
            btnPompa1.BackColor = Color.Yellow;

            progressBar1.MarqueeAnimationSpeed = 0;

        }

        private void btnPompa1_Click(object sender, EventArgs e)
        {
            if (btnPompa1.Text == "Başla")
            {
                pompa1Baslama = DateTime.Now;
                pompa1Litre = 0;

                btnPompa1.Text = "Bitir";
                btnPompa1.BackColor = Color.Red;

                tmrPompa1.Enabled = true;

                LblLitre1.Text = 0.ToString();
                progressBar1.Value = 0;
                LblFiyat1.Text = 0.ToString();
            }
            else if (btnPompa1.Text == "Bitir")
            {
                tmrPompa1.Stop();
                pompa1Saniye = 0;

                TimeSpan ts = DateTime.Now - pompa1Baslama;
                double gecenzaman = ts.TotalSeconds;
                double tutar = gecenzaman * benzinLitreFiyati;

                LblFiyat1.Text = tutar.ToString("0.00");
                LblLitre1.Text = gecenzaman.ToString("0.00");

                yeniAraba1DepoDoldu = true;

                btnPompa1.Text = "Boş";
                btnPompa1.BackColor = Color.Yellow;
            }
        }
        private void BtnPompa2_Click(object sender, EventArgs e)

        {
            if (BtnPompa2.Text == "Başla")
            {
                pompa2Baslama = DateTime.Now;
                pompa2Litre = 0;

                BtnPompa2.Text = "Bitir";
                BtnPompa2.BackColor = Color.Red;

                tmrPompa2.Enabled = true;

                LblLitre2.Text = 0.ToString();
                progressBar2.Value = 0;
                LblFiyat2.Text = 0.ToString();
            }
            else if (BtnPompa2.Text == "Bitir")
            {
                tmrPompa2.Stop();
                pompa2Saniye = 0;

                TimeSpan ts = DateTime.Now - pompa2Baslama;
                double gecenzaman = ts.TotalSeconds;
                double tutar = gecenzaman * motorinLitreFiyatı;

                LblFiyat2.Text = tutar.ToString("0.00");
                LblLitre2.Text = gecenzaman.ToString("0.00");

                yeniAraba2DepoDoldu = true;

                BtnPompa2.Text = "Boş";
                BtnPompa2.BackColor = Color.Yellow;
            }
        }
        private void BtnPompa3_Click(object sender, EventArgs e)
        {
            if (btnPompa3.Text == "Başla")
            {
                pompa3Baslama = DateTime.Now;
                pompa3Litre = 0;

                btnPompa3.Text = "Bitir";
                btnPompa3.BackColor = Color.Red;

                tmrSari.Enabled = true;

                LblLitre3.Text = 0.ToString();
                progressBar3.Value = 0;
                LblFiyat3.Text = 0.ToString();
            }
            else if (btnPompa3.Text == "Bitir")
            {
                tmrSari.Stop();
                pompa3Saniye = 0;

                TimeSpan ts = DateTime.Now - pompa3Baslama;
                double gecenzaman = ts.TotalSeconds;
                double tutar = gecenzaman * lpgLitreFiyatı;

                LblFiyat3.Text = tutar.ToString("0.00");
                LblLitre3.Text = gecenzaman.ToString("0.00");

                yeniAraba3DepoDoldu = true;

                btnPompa3.Text = "Boş";
                btnPompa3.BackColor = Color.Yellow;
            }
        }

        private void BtnYön1_Click(object sender, EventArgs e)
        {
            picAraba.Left = pompa1Sol;
        }
        private void BtnYön2_Click(object sender, EventArgs e)
        {
            picAraba.Left = pompa2Sol;
        }
        private void BtnYön3_Click(object sender, EventArgs e)
        {
            picAraba.Left = pompa3Sol;
        }



        private void tmrPompa2_Tick(object sender, EventArgs e)
        {
            pompa2Saniye++;
            pompa2Litre++;
            LblLitre2.Text = pompa2Saniye.ToString();
            LblFiyat2.Text = (pompa2Litre * motorinLitreFiyatı).ToString("0.00");
            progressBar2.Value = pompa2Litre;
        }

        private void tmrPompa3_Tick(object sender, EventArgs e)
        {
            pompa3Saniye++;
            pompa3Litre++;
            LblLitre3.Text = pompa3Saniye.ToString();
            LblFiyat3.Text = (pompa3Litre * lpgLitreFiyatı).ToString("0.00");
            progressBar3.Value = pompa3Litre;

        }
        private void tmrPompa1_Tick(object sender, EventArgs e)
        {
            pompa1Saniye++;
            pompa1Litre++;
            LblLitre1.Text = pompa1Saniye.ToString();
            LblFiyat1.Text = (pompa1Litre * benzinLitreFiyati).ToString("0.00");
            progressBar1.Value = pompa1Litre;
        }



        private void picAraba_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.SkyBlue;
            if (pompa1Bos)
            {
                yeniAraba1.Image = picAraba.Image;
                yeniAraba1.Location = new System.Drawing.Point(9, 200);
                yeniAraba1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
                yeniAraba1.Name = "pbYeniAraba1";
                yeniAraba1.Size = new System.Drawing.Size(109, 33);
                yeniAraba1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.Controls.Add(yeniAraba1);
                yeniAraba1.SendToBack();

                pompa1Bos = false;
                yeniAraba1Gonderildi = true;

                // pompa değerlerini sıfırla
            }
            else if (pompa2Bos)
            {
                yeniAraba2.Image = picAraba.Image;
                yeniAraba2.Location = new System.Drawing.Point(9, 200);
                yeniAraba2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
                yeniAraba2.Name = "pbYeniAraba2";
                yeniAraba2.Size = new System.Drawing.Size(109, 33);
                yeniAraba2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.Controls.Add(yeniAraba2);
                yeniAraba2.SendToBack();

                pompa2Bos = false;
                yeniAraba2Gonderildi = true;
            }
            else if (pompa3Bos)
            {
                yeniAraba3.Image = picAraba.Image;
                yeniAraba3.Location = new System.Drawing.Point(9, 200);
                yeniAraba3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
                yeniAraba3.Name = "pbYeniAraba3";
                yeniAraba3.Size = new System.Drawing.Size(109, 33);
                yeniAraba3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.Controls.Add(yeniAraba3);
                yeniAraba3.SendToBack();

                pompa3Bos = false;
                yeniAraba3Gonderildi = true;
            }

            if (tmrAraba.Enabled == false)
                tmrAraba.Enabled = true;

        }

        private void tmrAraba_Tick(object sender, EventArgs e)
        {
            if (yeniAraba1Gonderildi)
            {
                if (yeniAraba1.Left < pompa1Sol)
                    yeniAraba1.Left += 1;
                if (yeniAraba1.Top > pompa1Ust)
                    yeniAraba1.Top -= 1;
                if (yeniAraba1.Left >= pompa1Sol && btnPompa1.Text == "Boş" && yeniAraba1DepoDoldu == false)
                {
                    btnPompa1.Text = "Başla";
                    btnPompa1.BackColor = Color.Aqua;
                }
            }
            if (yeniAraba1DepoDoldu)
            {
                if (yeniAraba1.Left < arabaFormSonuLeft)
                    yeniAraba1.Left += 1;
                else
                {
                    pompa1Bos = true;
                    yeniAraba1Gonderildi = false;
                    yeniAraba1DepoDoldu = false;
                }
            }
            if (yeniAraba2Gonderildi)
            {
                if (yeniAraba2.Left < pompa2Sol)
                    yeniAraba2.Left += 1;
                if (yeniAraba2.Top > pompa2Ust)
                    yeniAraba2.Top -= 1;
                if (yeniAraba2.Left >= pompa2Sol && BtnPompa2.Text=="Boş" && yeniAraba2DepoDoldu==false)
                {
                    // BtnPompa.Enabled = true;
                    BtnPompa2.Text = "Başla";
                    BtnPompa2.BackColor = Color.Aqua;
                }
            }

            if (yeniAraba2DepoDoldu)
            {

                if (yeniAraba2.Left < arabaFormSonuLeft)
                    yeniAraba2.Left += 1;
                else
                {
                    pompa2Bos = true;
                    yeniAraba2Gonderildi = false;
                    yeniAraba2DepoDoldu = false;
                }
            }
            if (yeniAraba3Gonderildi)
            {
                if (yeniAraba3.Left < pompa3Sol)
                    yeniAraba3.Left += 1;
                if (yeniAraba3.Top < pompa3Ust)
                    yeniAraba3.Top += 1;
                if (yeniAraba3.Left >= pompa3Sol && btnPompa3.Text=="Boş" && yeniAraba3DepoDoldu==false)
                {
                    // BtnPompa3.Enabled = true;
                    btnPompa3.Text = "Başla";
                    btnPompa3.BackColor = Color.Aqua;
                }
            }
            if (yeniAraba3DepoDoldu)
            {
                if (yeniAraba3.Left < arabaFormSonuLeft)
                    yeniAraba3.Left += 1;

                else
                {
                    pompa3Bos = true;
                    yeniAraba3Gonderildi = false;
                    yeniAraba3DepoDoldu = false;
                }

            }
        }

       
        
    }
}

