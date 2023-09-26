# LibraryBook
 Tugas CRUD Console Library Book BY Rizki Atoilah
 
1. Buat class 'Book' dengan properti berikut:
    - Title (string)
    - Author (string)
    - PublicationYear (int)

2. Buat class 'LibraryCatalog' dengan salah satu collection yang dapat mengelola objek 'Book'. Kelas ini harus mencakup method's berikut:
    - AddBook(Book book): Menambahkan buku ke dalam katalog.
    - RemoveBook(Book book): Menghapus buku dari katalog.
    - FindBook(string title): Mencari buku berdasarkan judul dan mengembalikan buku jika ditemukan, atau null jika tidak ditemukan.
    - ListBooks(): Menampilkan daftar semua buku dalam katalog.

3. Buat class 'LibraryApp' dengan method Main untuk berinteraksi dengan katalog perpustakaan. Gunakan pendekatan berbasis menu untuk memungkinkan pengguna melakukan actions berikut:
    - Menambahkan buku ke dalam katalog.
    - Menghapus buku dari katalog.
    - Mencari buku berdasarkan judul.
    - Menampilkan semua buku dalam katalog.
    - Keluar dari aplikasi.

4. Implementasikan error handling untuk menangani kasus ketika pengguna memasukkan input yang salah atau ketika mencoba menghapus/mencari buku yang tidak ada. semua error handling dapat di buat dalam class 'ErrorHandler'
