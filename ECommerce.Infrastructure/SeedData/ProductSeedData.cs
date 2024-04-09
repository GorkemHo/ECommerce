using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.SeedData
{
    public static class ProductSeedData
    {
        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Çakmak",
                    Color = "Kırmızı",
                    Price = 100,
                    Quantity = 10,
                    Description = "• Kaplama: Red Matte\r\n• Eşsiz Zippo \"klik\" sesine sahip orijinal Zippo rüzgar geçirmez çakmak.\r\n• Özel hediyelik kutusunda paketlenmiş olarak gelir.\r\n• Tamamı metalden oluşan iç aksam; neredeyse her yerde çalışan rüzgar geçirmez tasarım",
                    ImagePath = "../../images/cakmak/cakmak-kirmizi.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Çakmak",
                    Color = "Mavi",
                    Price = 150,
                    Quantity = 5,
                    Description = "• Kaplama: Indigo\r\n• Eşsiz Zippo \"klik\" sesine sahip orijinal Zippo rüzgar geçirmez çakmak.\r\n• Özel hediyelik kutusunda paketlenmiş olarak gelir.\r\n• Tamamı metalden oluşan iç aksam; neredeyse her yerde çalışan rüzgar geçirmez tasarım",
                    ImagePath = "../../images/cakmak/cakmak-mavi.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Çakmak",
                    Color = "Yeşil",
                    Price = 200,
                    Quantity = 8,
                    Description = "• Kaplama: Green Matte\r\n• Eşsiz Zippo \"klik\" sesine sahip orijinal Zippo rüzgar geçirmez çakmak.\r\n• Özel hediyelik kutusunda paketlenmiş olarak gelir.\r\n• Tamamı metalden oluşan iç aksam; neredeyse her yerde çalışan rüzgar geçirmez tasarım",
                    ImagePath = "../../images/cakmak/cakmak-yesil.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 4,
                    Name = "Çakmak",
                    Color = "Siyah",
                    Price = 120,
                    Quantity = 12,
                    Description = "• Kaplama: Black Matte\r\n• Eşsiz Zippo \"klik\" sesine sahip orijinal Zippo rüzgar geçirmez çakmak.\r\n• Özel hediyelik kutusunda paketlenmiş olarak gelir.\r\n• Tamamı metalden oluşan iç aksam; neredeyse her yerde çalışan rüzgar geçirmez tasarım",
                    ImagePath = "../../images/cakmak/cakmak-siyah.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 5,
                    Name = "Çakmak",
                    Color = "Beyaz",
                    Price = 180,
                    Quantity = 6,
                    Description = "• Kaplama: White Matte\r\n• Eşsiz Zippo \"klik\" sesine sahip orijinal Zippo rüzgar geçirmez çakmak.\r\n• Özel hediyelik kutusunda paketlenmiş olarak gelir.\r\n• Tamamı metalden oluşan iç aksam; neredeyse her yerde çalışan rüzgar geçirmez tasarım",
                    ImagePath = "../../images/cakmak/cakmak-beyaz.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 6,
                    Name = "Çakmak",
                    Color = "Siyah",
                    Price = 180,
                    Quantity = 6,
                    Description = "Romantik bir akşam yemeği için mumlar hazır mı? Güzel bir akşam yemeğinde mumları yakmayı Zippo Mum Çakmağına bırakın. Fırçalanmış krom renkli Mum çakmağı yumuşak bir dokunmayla yanmaya hazır sistemi, ayarlanilir alev çıkışı, patentli çocuk-resistans kilidi ve baştan uca 16,5 cm uzunluğunda. Fırçalanmış krom rengine sahip mum çakmağı 3-yıl garantiye sahiptir. Optimum yanma performansı için Zippo Premium Bütan gazı kullanılması önerilir.Romantik bir akşam yemeği için mumlar hazır mı? Güzel bir akşam yemeğinde mumları yakmayı Zippo Mum Çakmağına bırakın. Fırçalanmış krom renkli Mum çakmağı yumuşak bir dokunmayla yanmaya hazır sistemi, ayarlanilir alev çıkışı, patentli çocuk-resistans kilidi ve baştan uca 16,5 cm uzunluğunda. Fırçalanmış krom rengine sahip mum çakmağı 3-yıl garantiye sahiptir. Optimum yanma performansı için Zippo Premium Bütan gazı kullanılması önerilir.",
                    ImagePath = "../../images/cakmak/mum-icin-cakmak.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 7,
                    Name = "Cüzdan",
                    Color = "Mavi",
                    Price = 150,
                    Quantity = 5,
                    Description = "Zippo'nun yepyeni Denim serisinin bir parçası. Cebinizde tarz yaratın! Orijinal Zippo logosuna ve ihtiyacınız olan her şeye uyacak çeşitli bölmelere sahip bir deri-denim Kredi Kartı Tutucu.\r\n\r\nDeri ve Denim Kot Kumaşından Üretilmiştir\r\nKot ve Ten Rengi\r\nYatay biçimli İki Katlı Kredi Kartı Cüzdanı",
                    ImagePath = "../../images/cuzdan/cuzdan-mavi.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 8,
                    Name = "Cüzdan",
                    Color = "Siyah",
                    Price = 120,
                    Quantity = 5,
                    Description = "Zippo'nun yepyeni Saffiano serisinin bir parçası. Orijinal Zippo logosuna sahip, Saffiano kabartmalı ve çeşitli bölmelere sahip yüksek kaliteli deriden yapılmış bir deri cüzdan, ihtiyacınız olan her şeye uyacak şekilde.\r\n\r\nSafiano Deriden yapılmıştır\r\nYatay formatlı Fermuarlı Cüzdan\r\nBoyutlar: 9cm x 11cm x 2cm\r\nRFID özelliğine sahip\r\nSiyah",
                    ImagePath = "../../images/cuzdan/cuzdan-siyah1.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 9,
                    Name = "Cüzdan",
                    Color = "Siyah",
                    Price = 100,
                    Quantity = 5,
                    Description = "Zippo'nun yepyeni Saffiano serisinin bir parçası. Orijinal Zippo logosuna sahip, Saffiano kabartmalı ve çeşitli bölmelere sahip yüksek kaliteli deriden yapılmış bir deri cüzdan, ihtiyacınız olan her şeye uyacak şekilde.\r\n\r\nSafiano Deriden yapılmıştır\r\nYatay biçim Üç bölmeli Cüzdan\r\nBoyutlar: 10,5cm x 9cm x 3,5cm\r\nRFID özelliğine sahip\r\nSiyah",
                    ImagePath = "../../images/cuzdan/cuzdan-siyah2.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 10,
                    Name = "Cüzdan",
                    Color = "Siyah",
                    Price = 100,
                    Quantity = 5,
                    Description = "Renk: Yeşil.\r\nBoyutlar: 10,5 x 8 x 1 cm.\r\nHakiki Deri\r\n6 Kart, 2 İç göz,1 Kimlik gözü\r\nÇevre dostu bir hediye kutusunda paketlenmiştir. Zippo kalitesine uygun olarak Hindistan'da üretilmiştir.Renk: Yeşil.\r\nBoyutlar: 10,5 x 8 x 1 cm.\r\nHakiki Deri\r\n6 Kart, 2 İç göz,1 Kimlik gözü\r\nÇevre dostu bir hediye kutusunda paketlenmiştir. Zippo kalitesine uygun olarak Hindistan'da üretilmiştir.",
                    ImagePath = "../../images/cuzdan/cuzdan-yesil.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 11,
                    Name = "Gözlük",
                    Color = "Kırmızı",
                    Price = 150,
                    Quantity = 5,
                    Description = "G:55mm Y:44mm K:17mm\r\nPolikarbon alaşım\r\nOptik Sınıf: 1\r\n\r\nMaksimum UV koruması\r\n\r\nMikrofiber kılıf\r\nÜcretsiz yanında: Sert karton koruma kabı ve mikrofiber bezPolikarbon alaşım\r\nOptik Sınıf: 1\r\n\r\nMaksimum UV koruması",
                    ImagePath = "../../images/gozluk/gozluk-kirmizi.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 4
                },
                new Product
                {
                    Id = 12,
                    Name = "Gözlük",
                    Color = "Mavi",
                    Price = 150,
                    Quantity = 5,
                    Description = "G:58mm Y:50mm K:17mm\r\nMetal alaşım\r\nOptik Sınıf: 1\r\nMaksimum UV koruması\r\n\r\nMikrofiber kılıf\r\nÜcretsiz yanında: Sert karton koruma kabı ve mikrofiber bezMetal alaşım\r\nOptik Sınıf: 1\r\nMaksimum UV koruması",
                    ImagePath = "../../images/gozluk/gozluk-mavi.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 4
                },
                new Product
                {
                    Id = 13,
                    Name = "Gözlük",
                    Color = "Siyah",
                    Price = 150,
                    Quantity = 5,
                    Description = "G:58mm Y:50mm K:17mm\r\nÖn Genişlik: 138mm\r\nSap Uzunluğu: 140mm\r\nMetal alaşım\r\nOptik Sınıf: 1\r\nMaksimum UV korumasıMetal alaşım\r\nOptik Sınıf: 1\r\nMaksimum UV koruması",
                    ImagePath = "../../images/gozluk/gozluk-siyah.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 4
                },
                new Product
                {
                    Id = 14,
                    Name = "Kalem",
                    Color = "Siyah",
                    Price = 150,
                    Quantity = 5,
                    Description = "Zippo'nun parlak siyah tükenmez kalemi (Ballpoint) çift yönlü açılabilme, Zippo logolu metal klipsli ve orta kalınlıkta siyah uç. Zippo'nun bu kalemi hediye edilmeye uygun özel doğa dostu karton kutusunda iki yıl garanti kapsamındadır.\r\n•Çift Yönlü Açılma\r\n•Tükenmez Kalem (Ball Point)\r\n•Özel doğa dostu karton kutusunda\r\n•Garanti",
                    ImagePath = "../../images/kalem/kalem-siyah.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 5
                },
                new Product
                {
                    Id = 15,
                    Name = "Kalem",
                    Color = "Mavi",
                    Price = 150,
                    Quantity = 5,
                    Description = "Zippo'nun gümüş rengi fırçalanmış görünümlü krom tükenmez kalemi (Ballpoint) pürüzsüz ve şık bir görünüm sunuyor. Çift yönlü açma ve kapama, Zippo logolu sabit metal klips ve orta kalınlıkta siyah uç. Zippo'nun gümüş rengi fırçalanmış krom tükenmez kalemi hediye edilmeye uygun özel doğa dostu karton kutusunda iki yıl garanti kapsamındadır.\r\n•Çift Yönlü Açılma\r\n•Tükenmez Kalem (Ball Point)\r\n•Özel doğa dostu karton kutusunda\r\n•Garanti",
                    ImagePath = "../../images/kalem/kalem-mavi1.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 5
                },
                new Product
                {
                    Id = 16,
                    Name = "Kalem",
                    Color = "Mavi",
                    Price = 150,
                    Quantity = 5,
                    Description = "Zippo'nun gümüş rengi fırçalanmış görünümlü krom ince tükenmez kalemi (Rollerball) pürüzsüz ve şık bir görünüm sunuyor. Aç-kapa kapak özellikli Zippo logolu metal klips ve siyah ucuyla Zippo'nun bu kalemi hediye edilmeye uygun özel doğa dostu karton kutusunda iki yıl garanti kapsamındadır.\r\n•Aç-Kapa Kapak\r\n•İnce Tükenmez Kalem (Roller Ball)\r\n•Özel doğa dostu karton kutusunda\r\n•Garanti",
                    ImagePath = "../../images/kalem/kalem-mavi2.jpg",
                    CreateDate = DateTime.Now,
                    Status = Status.Active,
                    CategoryId = 5
                }
            );
        }
    }
}
