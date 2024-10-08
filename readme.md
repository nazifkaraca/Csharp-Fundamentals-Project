# C# Fundamentals Project

## Proje Özeti

Bu proje, C# programlama diliyle geliştirilen temel bir konsol uygulamasıdır. Uygulama, kullanıcıya üç farklı program seçeneği sunar:

1. **Rastgele Sayı Bulma Oyunu**: Bilgisayarın seçtiği rastgele sayıyı tahmin etme oyunu.
2. **Hesap Makinesi**: Toplama, çıkarma, çarpma ve bölme işlemlerini yapabileceğiniz bir hesap makinesi.
3. **Ortalama Hesaplama**: Girilen üç ders notunun ortalamasını hesaplayarak harf notunu gösteren bir program.

Her program, kullanıcı girdilerine dayalı olarak çalışır ve kullanıcının hata yapma durumlarında gerekli bilgilendirmeleri yapar.

<div align="center">
<img src=https://github.com/user-attachments/assets/940d9be3-d734-4713-9b74-061fdc65aa73 >
</div>

## Kurulum ve Çalıştırma

1. **Gereksinimler**:
   - .NET Core SDK yüklü olmalıdır.
   - Bir C# IDE'si (örneğin, Visual Studio veya Rider) önerilir.

2. **Projenin Çalıştırılması**:
   - Proje dosyasını bilgisayarınıza klonlayın.
   - Proje dizinine gidin.
   - Terminal üzerinden şu komutu çalıştırarak uygulamayı başlatın:
     
     ```bash
     dotnet run
     ```
   - Menü ekranı açılacak ve kullanıcı üç programdan birini seçebilecektir.

## Kullanılan Teknolojiler

- C# Programlama Dili
- .NET Core
- Konsol Uygulaması

## Programlar

### 1. Rastgele Sayı Bulma Oyunu
- Bilgisayar 1 ile 100 arasında rastgele bir sayı seçer.
- Kullanıcı bu sayıyı tahmin etmeye çalışır.
- Her tahminden sonra kullanıcıya, sayının daha yüksek mi yoksa daha düşük mü olduğunu söyleyen bir ipucu verilir.
- Kullanıcının 5 tahmin hakkı vardır ve her tahminden sonra kalan hakları gösterilir.
- Doğru tahmin durumunda oyun biter ve kullanıcı tebrik edilir, aksi halde doğru sayı gösterilir ve oyun sona erer.

### 2. Hesap Makinesi
- Kullanıcı iki sayı girer ve yapmak istediği işlemi seçer:
 ```
  Toplama (+)
  Çıkarma (-)
  Çarpma (*)
  Bölme (/)
 ```
- Seçilen işleme göre sonuç ekrana yazdırılır.
- Bölme işlemi sırasında sıfıra bölme hatası kontrol edilir ve kullanıcıya uygun bir uyarı verilir.

### 3. Ortalama Hesaplama
- Kullanıcıdan üç farklı ders notu girilmesi istenir.
- Girilen notların geçerliliği kontrol edilir (0-100 arasında olmalıdır).
- Geçerli notlar için ortalama hesaplanır ve ekrana yazdırılır.
- Ortalamaya karşılık gelen harf notu gösterilir:
  ```
  90-100: AA
  85-89:  BA
  80-84:  BB
  75-79:  CB
  70-74:  CC
  65-69:  DC
  60-64:  DD
  55-59:  FD
  0-54:   FF
  ```

## Proje İsterleri

Bu proje, **Patika.dev** Full Stack Bootcamp mezuniyet kriterlerinden biri olan C# Fundamentals Project kapsamında geliştirilmiştir. Proje gereksinimlerini ve değerlendirme formundaki isterleri karşılamaktadır.

### Değerlendirme Kriterleri:
- Kodun modüler yapısı.
- Yorum satırlarının kullanımı ve açıklayıcılığı.
- Kullanıcı hatalarıyla başa çıkma becerisi (örn. geçersiz girişlerin yönetimi).
- Kodun genel performansı ve işlevselliği.
