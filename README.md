# MAT 217 SAYISAL ANALİZ PROJE ÖDEVİ

* [cite_start]**Öğrenci Adı Soyadı:** Agah Faruk Küçük [cite: 2]
* [cite_start]**Öğrenci Numarası:** B241200004 [cite: 3]
* [cite_start]**Bölüm:** Bilişim Sistemleri Mühendisliği [cite: 4]
* [cite_start]**Ders:** MAT 217 Sayısal Analiz [cite: 5]
* [cite_start]**Proje Konusu:** Ürün Fiyatını Bulma (Kâr Optimizasyonu) [cite: 6]

---

## 1. PROBLEMİN TANIMI (İSTER 1)

**Problemin Tanımı ve İlgili Sistem:**
[cite_start]Bu proje kapsamında, rekabetçi bir e-ticaret pazarında satışa sunulacak olan yeni nesil bir **"Gürültü Engelleyici Kablosuz Kulaklık"** için en uygun satış fiyatının belirlenmesi problemi ele alınmıştır. [cite: 8]

Fiyatlandırma stratejisi, bir işletmenin kârlılığı için kritik öneme sahiptir. [cite_start]Fiyatın artması birim başına kârı yükseltirken, pazar talebini (satış adedini) düşürmektedir. [cite: 9] [cite_start]Bu zıt yönlü ilişki, optimum bir denge noktasının bulunmasını zorunlu kılar. [cite: 10]

**Mühendislik Hedefi:**
[cite_start]Projenin temel hedefi, üretim maliyetleri ve pazarın talep esnekliği verileri ışığında, **toplam kârı ($K$)** maksimize edecek **optimum satış fiyatını ($P^*$)** sayısal analiz yöntemleri kullanarak ölçülebilir ve bilimsel bir yaklaşımla tespit etmektir. [cite: 11] [cite_start]Bu süreçte deneme-yanılma yerine, mühendislik disiplinine uygun iteratif bir kök bulma algoritması kullanılacaktır. [cite: 12]

---

## 2. FİZİKSEL MODELİN OLUŞTURULMASI

[cite_start]Gerçek hayat problemini daha hassas modellemek için **"Hızlanan Talep Düşüşü (Polinom)"** modeli benimsenmiştir: [cite: 14]

* **Varsayım 1 (Maliyet - $C$):** Ürünün birim maliyeti $C = 400$ TL olarak güncellenmiştir. [cite: 15]
* **Varsayım 2 (Talep Fonksiyonu - $D(P)$):** Fiyat arttıkça talebin sadece doğrusal değil, karesel bir etkiyle hızlanarak düştüğü varsayılmıştır:
    $$D(P) = 20000 - 5P - 0.01P^2$$
    [cite_start]*(Bu model, fiyat aşırı yükseldiğinde müşterinin üründen kaçış hızının arttığını simüle eder.)* [cite: 16, 17, 18]
* [cite_start]**Kısıtlar:** Fiyat maliyetten büyük olmalıdır ($P > 400$). [cite: 19]

---

## 3. MATEMATİK MODELİN OLUŞTURULMASI

[cite_start]Fiziksel modeldeki varsayımlar kullanılarak problem matematiksel denklemlere dökülmüştür. [cite: 21]

**Kâr Fonksiyonu $K(P)$:**
[cite_start]$$K(P) = (P - 400) \cdot (20000 - 5P - 0.01P^2)$$ [cite: 23]

Bu fonksiyon açıldığında 3. dereceden (kübik) bir denklem elde edilir:
[cite_start]$$K(P) = -0.01P^3 - P^2 + 22000P - 8000000$$ [cite: 25]

**Optimizasyon ve Kök Denklemi $f(P)$:**
[cite_start]Maksimum kâr için türev alınıp sıfıra eşitlenir ($dK/dP = 0$). [cite: 26] Elde edilen kök denklemi ($f(P)$) şudur:
[cite_start]$$f(P) = -0.03P^2 - 2P + 22000 = 0$$ [cite: 28]

**Newton-Raphson İçin Türev $f'(P)$:**
Yöntem gereği, yukarıdaki fonksiyonun da türevi gereklidir:
[cite_start]$$f'(P) = -0.06P - 2$$ [cite: 29]

**Yöntem Seçimi:**
[cite_start]Elde edilen denklemin kökünü bulmak için **Newton-Raphson Yöntemi** seçilmiştir. [cite: 30] [cite_start]Bu yöntemin seçilme nedeni, türev tabanlı olması sayesinde optimizasyon problemlerinde köke hızlı ve kararlı bir şekilde yakınsamasıdır. [cite: 31]

---

## 4. ÇÖZÜMÜN VARLIĞI VE ANALİZİ

[cite_start]Newton-Raphson Yöntemi kullanılacaktır. [cite: 33]

* [cite_start]**Kök Denklemi:** $f(P) = -0.03P^2 - 2P + 22000$ [cite: 34]
* **Denklemin Türevi:** $f'(P) = -0.06P - 2$ [cite: 35]

**Analiz:** Fonksiyonun türevi ($f'(P)$) sabit bir sayı değil, $P$'ye bağlı değişen bir ifadedir. [cite: 36] Bu durum, Newton-Raphson yönteminin tek adımda değil, iteratif adımlarla sonuca yaklaşacağını gösterir. [cite: 37] Yöntem, parabolik eğrinin teğetlerini kullanarak köke (optimum fiyata) adım adım inecektir. [cite: 38]

---

## 5. UYGUN BİR YÖNTEMLE MATEMATİKSEL MODELİN ÇÖZÜMÜ (İSTER 2 & 3)

Seçilen problemin çözümü, **C# programlama dili** kullanılarak kodlanmış ve Newton-Raphson algoritması uygulanmıştır. [cite: 40]

**Algoritma Özeti:**
1.  Başlangıç fiyat tahmini ($P_0$) ve hata toleransı tanımlanır. [cite: 42]
2.  Döngü içerisinde $f(P)$ ve $f'(P)$ değerleri hesaplanır. [cite: 43]
3.  Yeni fiyat değeri ($P_{yeni}$) formül ile bulunur. [cite: 44]
4.  Hata oranı kontrol edilir; toleransın altındaysa döngü sonlandırılır. [cite: 45]

### Kod Çıktısı:

![kod çıkıtısı](kod_çıktısı.png)

## 6. HATA ANALİZİ VE SONUÇ

**Sonuçların Değerlendirilmesi:**
Yapılan sayısal analiz sonucunda, maksimum kârı sağlayan optimum satış fiyatı **$P \approx 823.66$ TL** olarak bulunmuştur.

**Yakınsama Analizi:**
Kök denklemi 2. dereceden (non-lineer) olduğu için Newton-Raphson yöntemi çözüme tek adımda ulaşmamış, **5. iterasyonda** hata payını toleransın altına indirmiştir. Başlangıçta yüksek olan hata oranı, yöntemin kuadratik yakınsama özelliği sayesinde her adımda hızla azalmıştır.

**Doğrulama (Sağlama):**
Bulunan sonucun sağlaması yapıldığında:

* $P = 800$ TL için Kâr $\approx$ **3,840,000 birim**
* $P = 823.66$ TL için Kâr $\approx$ **3,854,334 birim (Maksimum)**
* $P = 850$ TL için Kâr $\approx$ **3,836,250 birim**

Bu analiz, **823.66 TL** noktasının gerçekten de tepe noktası olduğunu doğrulamaktadır.