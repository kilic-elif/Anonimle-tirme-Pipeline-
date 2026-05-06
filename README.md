Veri Anonimleştirme ve Maskeleme Hattı (Anonymization Pipeline)
Bu proje, hassas verilerin gizliliğini korumak ve KVKK/GDPR gibi veri koruma standartlarına uyum sağlamak amacıyla geliştirilmiş kapsamlı bir Anonimleştirme ve Sözde Anonimleştirme (Pseudonymization) sistemidir. SQL Server tabanlı veritabanı yönetimini, modern bir ASP.NET Core MVC arayüzüyle birleştirir.

📑 Proje Genel Bakış
Sistem, veritabanındaki duyarlı bilgilerin (isim, kimlik no, iletişim bilgileri vb.) güvenli bir şekilde dönüştürülmesini sağlar. Sadece basit maskeleme değil, profesyonel düzeyde geri döndürülebilir veya geri döndürülemez dönüşüm tekniklerini içerir.

✨ Temel Özellikler
Gelişmiş Sözde Anonimleştirme: Verilerin geri döndürülebilir şekilde hash'lenmesi veya token'laştırılması.

Dinamik Veri Maskeleme: SQL Server fonksiyonları ve tetikleyicileri (triggers) kullanılarak verilerin anlık olarak gizlenmesi.

Normalizasyon ve Veri Bütünlüğü: Veritabanı mimarisi, yüksek performans ve veri tutarlılığı için 3. Normal Form (3NF) kurallarına uygun tasarlanmıştır.

Yönetim Paneli: ASP.NET Core MVC tabanlı kullanıcı dostu arayüz ile anonimleştirme kurallarının yönetimi.

🛠️ Teknik Mimari
Proje, katmanlı bir yapı üzerine inşa edilmiştir:

Veritabanı Katmanı: SQL Server üzerinde geliştirilen ER diyagramları, normalizasyon süreçleri ve gelişmiş SQL trigger sistemleri.

Uygulama Katmanı: İş mantığını yürüten ve veritabanı ile güvenli iletişimi sağlayan ASP.NET Core MVC yapısı.

Güvenlik Katmanı: Profesyonel düzeyde hashing, tokenization ve veri maskeleme algoritmaları.
Kullanılan TekniklerTeknikAçıklamaMaskeleme (Masking)Verinin bir kısmının karakterlerle kapatılması (örn: 532****12).Hashleme (Hashing)Verinin geri döndürülemez şekilde benzersiz bir kod dizisine dönüştürülmesi.TokenizasyonHassas verinin, veriyi temsil eden rastgele bir değerle (token) değiştirilmesi.
Kurulum ve Yapılandırma
Veritabanı Hazırlığı: Scripts/ klasöründeki SQL dosyalarını SQL Server üzerinde çalıştırarak tabloları, trigger'ları ve fonksiyonları oluşturun.

Uygulama Ayarları: appsettings.json dosyasındaki Connection String bilgisini kendi veritabanınıza göre güncelleyin.

Çalıştırma: Projeyi Visual Studio üzerinden başlatın veya terminalde dotnet run komutunu kullanın.
