﻿using EsiniBul.Properties;

namespace EsiniBul
{
    public partial class Form1 : Form
    {
        int boyut = 4;
        int w = 128;
        List<int> resimler;
        List<PictureBox> aciklar;
        int gizlenenAdet;

        public Form1()
        {
            InitializeComponent();
            YeniOyunHazirla();
        }

        private void ResimleriBelirle()
        {
            int toplamKartAdet = boyut * boyut;
            int resimCesitAdet = toplamKartAdet / 2;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 1; j <= resimCesitAdet; j++)
                {
                    resimler.Add(j);
                }
            }
            ListeKaristir(resimler);
        }

        private void ListeKaristir(List<int> resimler)
        {
            Random rnd = new Random();
            int temp, talihliIndeks;

            for (int i = 0; i < resimler.Count - 1; i++)
            {
                talihliIndeks = rnd.Next(i, resimler.Count);
                temp = resimler[i];
                resimler[i] = resimler[talihliIndeks];
                resimler[talihliIndeks] = temp;
            }
        }

        private void KartlariOlustur()
        {
            int no = 0;
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    PictureBox pb = new PictureBox();
                    pb.Size = new Size(w, w);
                    pb.Location = new Point(j * w, i * w);
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Image = Resim(0);
                    pb.Tag = no;
                    pb.Click += Pb_Click;
                    pnlKartlar.Controls.Add(pb);
                    no++;
                }
            }
            pnlKartlar.Size = new Size(boyut * w, boyut * w);
            ClientSize = new Size(boyut * w + 24, boyut * w + 24);
        }

        // hangi picturebox'a tıklandıysa sender'da o vardır
        private void Pb_Click(object sender, EventArgs e)
        {
            PictureBox tiklanan = (PictureBox)sender;
            int tiklananNo = (int)tiklanan.Tag;

            // Eğer tıklanan kart zaten açıksa hiçbir şey yapmadan çık
            if (aciklar.Contains(tiklanan))
                return;

            // Eğer zaten açık 2 kart varsa önce onları kapat
            if (aciklar.Count == 2)
            {
                AciklariKapat();
            }

            aciklar.Add(tiklanan);

            // Eğer açık kart sayısı 2 ise ve bunlar aynıysa onları gizle
            int oncekiNo = (int)aciklar[0].Tag;
            tiklanan.Image = Resim(resimler[tiklananNo]);

            if (aciklar.Count == 2 && resimler[oncekiNo] == resimler[tiklananNo])
            {
                // gizlenmeden önce yarım saniye görme şansı ver
                Update(); // tıklananı hemen göster
                Thread.Sleep(500);
                AciklariGizle();
            }

            // Eğer tüm kartlar gizlendiyse o zaman oyunu bitir
            if (gizlenenAdet == resimler.Count)
            {
                DialogResult cevap = MessageBox.Show(
                    "Oyun Bitti! Tekrar oynamak ister misiniz?", 
                    "Tekrar Oyna?", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question, 
                    MessageBoxDefaultButton.Button1);

                if (cevap == DialogResult.Yes)
                {
                    YeniOyunHazirla();
                }
                else
                {
                    Close(); // pencereyi kapat
                }
            }
        }

        private void YeniOyunHazirla()
        {
            pnlKartlar.Controls.Clear();
            resimler = new List<int>();
            aciklar = new List<PictureBox>();
            gizlenenAdet = 0;
            ResimleriBelirle();
            KartlariOlustur();
        }

        private void AciklariGizle()
        {
            gizlenenAdet += 2;
            foreach (PictureBox pb in aciklar)
            {
                pb.Hide();
            }
            aciklar.Clear();
        }

        private void AciklariKapat()
        {
            foreach (PictureBox pb in aciklar)
            {
                pb.Image = Resim(0);
            }
            aciklar.Clear();
        }

        Bitmap Resim(int no)
        {
            return (Bitmap)Resources.ResourceManager.GetObject(no.ToString());
        }
    }
}