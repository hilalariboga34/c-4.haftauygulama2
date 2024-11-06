using System;

public class Urun
{
    // Özellikler
    public string Ad { get; private set; }
    public decimal Fiyat { get; private set; }
    private decimal indirim;

    // Indirim Özelliği (0-50% arasında sınırlandırılmış)
    public decimal Indirim
    {
        get { return indirim; }
        set
        {
            if (value >= 0 && value <= 50)
            {
                indirim = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("İndirim değeri 0 ile 50 arasında olmalıdır.");
            }
        }
    }

    // Yapıcı Metot
    public Urun(string ad, decimal fiyat)
    {
        Ad = ad;
        Fiyat = fiyat;
        Indirim = 0; // Varsayılan indirim %0
    }

    // İndirimli Fiyat Metodu
    public decimal IndirimliFiyat()
    {
        return Fiyat * (1 - Indirim / 100);
    }
}

// Kullanım örneği
class Program
{
    static void Main(string[] args)
    {
        // Ürün oluşturma
        Urun urun = new Urun("Telefon", 3000);

        // İndirim uygulama
        urun.Indirim = 20; // %20 indirim

        // İndirimli fiyatı göster
        Console.WriteLine($"Ürün: {urun.Ad}");
        Console.WriteLine($"Orijinal Fiyat: {urun.Fiyat} TL");
        Console.WriteLine($"İndirimli Fiyat: {urun.IndirimliFiyat()} TL");

        // Yanlış bir indirim değeri ayarlamayı deneyin (örneğin 60), hata fırlatacaktır.
        // urun.Indirim = 60;
    }
}
