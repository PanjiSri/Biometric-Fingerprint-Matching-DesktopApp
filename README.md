# Pemanfaatan Pattern Matching dalam Membangun Sistem Deteksi Individu Berbasis Biometrik Melalui Citra Sidik Jari
> Tugas Besar 3 IF2211 Strategi Algoritma

## Daftar Isi

- [Deskripsi](#deskripsi)
- [Requirement](#requirement)
- [Setup Program](#setup-program)
- [Pemakaian](#pemakaian)
- [Kontributor](#kontributor)

## Deskripsi

Pattern matching merupakan teknik penting dalam sistem identifikasi sidik jari. Pada program ini, kami mengimplementasikan sistem yang dapat melakukan identifikasi individu berbasis biometrik dengan menggunakan sidik jari. Metode yang digunakan untuk melakukan deteksi sidik jari adalah Boyer-Moore dan Knuth-Morris-Pratt. Selain itu, sistem ini akan dihubungkan dengan identitas sebuah individu melalui basis data sehingga harapannya terbentuk sebuah sistem yang dapat mengenali identitas seseorang secara lengkap hanya dengan menggunakan sidik jari. Karena terdapat kemungkinan adanya korup pada data di biodata, maka program akan menggunakan algoritma Regex untuk melakukan pencocokan

## Requirement

- Microsoft .NET Framework
- MySQL

## Setup Program

1. Clone repository ini
>
    git clone https://github.com/ibrahim-rasyid/Tubes3_let-me-seedik

2. Lakukan dump SQL dengan memasukkan dataset sidik jari ke dalam sebuah database (ikuti langkah pada laman [berikut](https://dev.mysql.com/doc/refman/8.4/en/mysqldump-sql-format.html))

3. Ubah file .env dengan username, password, nama database, dan port yang sesuai dengan setup pada MySQL

4. Buka command prompt (pada windows) atau shell (pada linux), lalu jalankan perintah ```dotnet run```

## Pemakaian

1. Pada tampilan antarmuka, tekan tombol “Pilih Citra” dan masukkan gambar sidik jari yang diinginkan

2. Pilih algoritma yang diinginkan (default adalah KMP)

3. Tekan tombol Search untuk melakukan pencarian

4. Hasil akan ditampilkan di antarmuka pengguna.

## Kontributor

1. [Ibrahim Ihsan Rasyid](https://github.com/ibrahim-rasyid) - 13522018
2. [Panji Sri Kuncara Wisma](https://github.com/PanjiSri) - 13522028
3. [Imam Hanif Mulyarahman](https://github.com/HanifIHM) - 13522030