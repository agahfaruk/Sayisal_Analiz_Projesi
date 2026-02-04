using System;

namespace UrunFiyatiOptimizasyonu
{
    class Program
    {
        static void Main(string[] args)
        {
            // ÖDEV KONUSU: 8. Ürün Fiyatını Bulma (Kâr Optimizasyonu)
            // YÖNTEM: Newton-Raphson (Polinom Model)

            Console.WriteLine("--- Kâr Optimizasyonu ---");
            Console.WriteLine("Model: Polinom Talep Fonksiyonu (D = 20000 - 5P - 0.01P^2)");
            Console.WriteLine(new string('-', 70));

            // Başlangıç Tahmini
            // Not: Optimum fiyatın 800-900 civarı çıkmasını bekliyoruz.
            // Başlangıcı uzaktan verelim ki iterasyonları görelim.
            double p_onceki = 500;

            double p_yeni = 0;
            double hata = 100;
            double tolerans = 0.001;
            int iterasyon = 0;
            int maxIterasyon = 100;

            Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-15}", "İterasyon", "Fiyat (P)", "f(P) Değeri", "Hata (%)");
            Console.WriteLine(new string('-', 70));

            while (hata > tolerans && iterasyon < maxIterasyon)
            {
                iterasyon++;

                // 1. Fonksiyonu Hesapla (Türev Denklemi)
                // f(P) = -0.03P^2 - 2P + 22000
                double f_P = (-0.03 * Math.Pow(p_onceki, 2)) - (2 * p_onceki) + 22000;

                // 2. Türevi Hesapla (Newton için eğim)
                // f'(P) = -0.06P - 2
                double f_turev_P = (-0.06 * p_onceki) - 2;

                // 3. Newton-Raphson Formülü
                if (Math.Abs(f_turev_P) < 0.0001) // Sıfıra bölünme hatası önlemi
                {
                    Console.WriteLine("Türev sıfıra çok yakın, işlem durduruldu.");
                    break;
                }

                p_yeni = p_onceki - (f_P / f_turev_P);

                // 4. Hata Hesabı
                if (p_yeni != 0)
                    hata = Math.Abs((p_yeni - p_onceki) / p_yeni) * 100;

                Console.WriteLine("{0,-10} {1,-15:F4} {2,-15:F4} {3,-15:F4}", iterasyon, p_onceki, f_P, hata);

                p_onceki = p_yeni;
            }

            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"\nSONUÇ: Optimum Satış Fiyatı: {p_yeni:F2} TL");
            Console.WriteLine("Bu fiyatta maksimum kâr sağlanmaktadır.");

            // Konsol kapanmasın
            Console.ReadLine();
        }
    }
}