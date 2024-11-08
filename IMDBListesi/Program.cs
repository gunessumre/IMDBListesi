using System;
using System.Collections.Generic;
using System.Linq;

class Film
{
    // Film propertyleri
    public string Isim { get; set; }
    public double ImdbPuani { get; set; }
}

class Program
{
    static void Main()
    {
        // Sinema filmlerini listeleyeceğimiz liste
        List<Film> filmListesi = new List<Film>();

        while (true)
        {
            // Kullanıcıdan film adı ve Imdb puanı alma
            Console.Write("Film ismini giriniz: ");
            string isim = Console.ReadLine();

            Console.Write("Imdb puanını giriniz: ");
            double imdbPuani;
            while (!double.TryParse(Console.ReadLine(), out imdbPuani) || imdbPuani < 0 || imdbPuani > 10)
            {
                Console.WriteLine("Lütfen 0 ile 10 arasında geçerli bir puan giriniz.");
            }

            // Film nesnesi oluşturulup listeye ekleniyor
            Film yeniFilm = new Film { Isim = isim, ImdbPuani = imdbPuani };
            filmListesi.Add(yeniFilm);

            // Kullanıcıya yeni bir film eklemek isteyip istemediği soruluyor
            Console.Write("Yeni bir film eklemek istiyor musunuz? (evet/hayır): ");
            string cevap = Console.ReadLine().Trim().ToLower();
            if (cevap != "evet")
            {
                break;
            }
        }

        // 1. Bütün filmler listelensin
        Console.WriteLine("\nTüm Filmler:");
        foreach (var film in filmListesi)
        {
            Console.WriteLine($"Film: {film.Isim}, Imdb Puanı: {film.ImdbPuani}");
        }

        // 2. Imdb puanı 4 ile 9 arasında olan filmler
        Console.WriteLine("\nImdb puanı 4 ile 9 arasında olan filmler:");
        foreach (var film in filmListesi.Where(f => f.ImdbPuani >= 4 && f.ImdbPuani <= 9))
        {
            Console.WriteLine($"Film: {film.Isim}, Imdb Puanı: {film.ImdbPuani}");
        }

        // 3. İsmi 'A' ile başlayan filmler
        Console.WriteLine("\nİsmi 'A' ile başlayan filmler:");
        foreach (var film in filmListesi.Where(f => f.Isim.StartsWith("A", StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"Film: {film.Isim}, Imdb Puanı: {film.ImdbPuani}");
        }
    }
}