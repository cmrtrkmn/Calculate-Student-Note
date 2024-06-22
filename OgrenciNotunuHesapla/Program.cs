using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OgrenciNotunuHesapla
{
    class Ogrenci
    {
        public string Ad { get; private set; }
        public int Numara { get; private set; }
        private double VizeNotu { get; set; }
        private double FinalNotu { get; set; }
        public double Notu { get; set; }

        public Ogrenci(string ad, int numara, double vizeNotu, double finalNotu)
        {
            Ad = ad;
            Numara = numara;
            VizeNotu = vizeNotu;
            FinalNotu = finalNotu;
            NotHesapla();
        }
        // Dışarıya kapalı not hesaplama fonksiyonu
        private void NotHesapla()
        {
            Notu = VizeNotu * 0.4 + FinalNotu * 0.6;
        }

        // Dışarıya açık öğrenci bilgilerini yazdırma metodu
        public void OgrenciYazdir()
        {
            Console.WriteLine($"Öğrenci Bilgileri: {Ad} adında  {Numara} numarasında not ortalaması da {Notu} dir \n");
        }

    }
    class Program
    {
        static void Main()
        {
            // Dosya okuma işlemi
            try
            {
                string[] lines = File.ReadAllLines("ogrenciler.txt");
                foreach (string line in lines)
                {
                    string[] values = line.Split(' ');

                    if (values.Length > 0)
                    {
                        string ad = values[0].Trim();
                        int numara = int.Parse(values[1].Trim());
                        double vizeNotu = double.Parse(values[2].Trim());
                        double finalNotu = double.Parse(values[3].Trim());

                        Ogrenci ogrenci = new Ogrenci(ad, numara, vizeNotu, finalNotu);
                        ogrenci.OgrenciYazdir();
                    }
                    else
                    {
                        Console.WriteLine("Hatalı satır formatı: " + line);
                    }
                }
                Console.ReadLine();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Dosya bulunamadı.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }
        }
    }
}
