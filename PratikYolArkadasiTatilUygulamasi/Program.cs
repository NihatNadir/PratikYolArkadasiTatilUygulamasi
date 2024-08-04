using System;
using System.Globalization;
namespace PratikYolArkadasiTatilUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hoşgeldiniz!");
            bool restart = true; // Kullanıcı programdan çıkış işlemini doğru yapana kadar program çalışır.
            while (restart)
            {
                Console.WriteLine("\nGitmek istediğiniz lokasyonu giriniz. \n1 - Bodrum (Paket başlangıç fiyatı 4000 TL)\n2 - Marmaris (Paket başlangıç fiyatı 3000 TL)\n3 - Çeşme (Paket başlangıç fiyatı 5000 TL)");
                Console.WriteLine("");

            error: 
                string str = Console.ReadLine().ToLower(); // Kullanıcıdan Büyük-Küçük harf duyarlılığını ortadan kaldırarak ne yazarsa yazsın küçük harfe çeviriyoruz
                string capitalizeStr = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower()); // Kullanıcın girdiği lokasyonu burada baş harfi büyük olacak şekilde ayarlıyoruz.
                int personNumber = 0; // Kişi sayısı için değişken oluşturuyoruz.
                int totalPrize = 0; // Lokasyon ücreti için değişken oluşturuyoruz.
                bool result;

                switch (str) // Kullanıcıdan konum değerini alıyoruz.
                {
                    case "bodrum":
                        Console.WriteLine("Hoşgeldiniz!\n");
                        totalPrize = 4000;
                        break;

                    case "marmaris":
                        Console.WriteLine("Hoşgeldiniz!\n");
                        totalPrize = 3000;
                        break;

                    case "çeşme":
                        Console.WriteLine("Hoşgeldiniz!\n");
                        totalPrize = 5000;
                        break;

                    default: // Kullanıcı yanlış değeri girdiği için hata mesajı gösteriyoruz goto ile kullanıcıdan tekrar konum alması için başa dönüyor.
                        Console.WriteLine("Yanlış giriş yaptınız!");
                        Console.WriteLine("Bu 3 lokasyondan birini seçiniz (Bodrum, Marmaris, Çeşme)");
                        goto error;
                }

            number:
                Console.WriteLine("Kaç kişi için tatil istiyorsunuz?"); // Kullanıcıdan kişi sayısı için değer alıyoruz.
                result = int.TryParse(Console.ReadLine(), out personNumber); // Kullanıcı eğer sayı girerse işleme devam ediyor aksi takdirde hata mesajı gösteriyoruz.

                if (result) // Doğru giriş yapılması halinde özet bir bilgi gösteriyoruz ve şu ana kadar girilen değerleri consol ekranına yazdırıyoruz.
                {
                    Console.WriteLine($"\nTatiliniz için {capitalizeStr} lokasyonunda {personNumber} kişi için devam ediyorsunuz.");
                    Console.WriteLine($"\n{capitalizeStr} lokasyonunda yapabilecekleriniz\n\n1-Plajlar ve Deniz Aktiviteleri\n2-Tarihi ve Kültürel Geziler\n3-Doğa ve Macera\n4-Alışveriş ve Yemek\n5-Festivaller ve Etkinlikler\n6-Diğer Aktiviteler\n");
                }
                else // Kullanıcı sayı girmezse hata mesajı gösterilir ve kişi sayısını doğru almak için goto ile başa döner.
                {
                    Console.WriteLine("Sayı girmediniz!");
                    goto number;
                }

            path:
                int prize = 0; // Kullanıcıdan ulaşım yolu tercihi için ücret değişkeni oluşturuyoruz.
                Console.WriteLine("Hangi ulaşım yolunu tercih edersiniz? (1 / 2) "); 
                Console.WriteLine("1 - Kara yolu ( Kişi başı ulaşım tutarı gidiş-dönüş 1500 TL )\n2 - Hava yolu ( Kişi başı ulaşım tutarı gidiş-dönüş 4000 TL)");

                switch (Console.ReadLine()) // Kullanıcıdan ulaşım yolunu için değer alıyoruz. Kullanıcının girdiği işleme göre switch-case döngüsüne sokuyoruz. 
                {
                    case "1": // Kullanıcı 1 girerse yapılacak işlemler.
                        Console.WriteLine();
                        prize = 1500;
                        Console.WriteLine($"Tatiliniz için {capitalizeStr} lokasyonunda {personNumber} kişi Kara yolunu kullanarak devam ediyorsunuz.\nÖdeyeceğiniz kişi başı tutar = {(prize + totalPrize) } \nÖdeyeceğiniz toplam tutar = {personNumber * (prize + totalPrize)}\n");
                        break;

                    case "2": // Kullanıcı 2 girerse yapılacak işlemler.
                        Console.WriteLine();
                        prize = 4000;
                        Console.WriteLine($"Tatiliniz için {capitalizeStr} lokasyonunda {personNumber} kişi Hava yolunu kullanarak devam ediyorsunuz.\nÖdeyeceğiniz kişi başı tutar = {(prize + totalPrize) }\nÖdeyeceğiniz toplam tutar = {personNumber * (prize + totalPrize)}\n");
                        break;

                    default: // Kullanıcı yanlış değer girerse hata mesajı ile karşılaşır. Ardından goto ile tekrar ulaşım yolu tercihi için veri istenir.
                        Console.WriteLine("\nYanlış giriş yaptınız!!!\nGiriş için '1' yada '2' kullanmalısınız!!!\n");
                        goto path;
                }

            restart:
                Console.WriteLine("Uygulamayı tekrar başlatmak ister misiniz? (y/n)"); // Kullanıcıdan tekrar başlatmak istemesi durumuna göre switch-case döngüsüne sokuyoruz.
                string input = Console.ReadLine().ToLower();

                switch (input) // n seçilirse uygulamadan çıkmak istediğinde İyi Günler Dileriz mesajını ekrande gösterilir.
                {
                    case "n":
                        restart = false;
                        Console.WriteLine("İyi Günler Dileriz...");
                        break;

                    case "y": // y seçilirse uygulama başa döner.
                        restart = true;
                        break;

                    default: // Kullanıcı y / n harici başka bir değer girdiğinde hata mesajı gösterilir goto ile tekrar değer alması için başa döner.
                        Console.WriteLine("Yanlış giriş yaptınız!!!");
                        goto restart;
                }
            }

        }
    }
}