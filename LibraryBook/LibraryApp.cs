using System;

namespace LibraryBook;

class LibraryApp
{
    public static void Main(string[] args)
    {
        ErrorHandler errorHandler = new ErrorHandler();
        //Data Dummy
        LibraryCatalog.catalog.AddBook(new Book("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", 1997));
        LibraryCatalog.catalog.AddBook(new Book("The Hobbit", "J.R.R. Tolkien", 1937));
        LibraryCatalog.catalog.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925));

        string book;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==========================");
            Console.WriteLine("\t MENU \t");
            Console.WriteLine("==========================");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. List Book");
            Console.WriteLine("3. Find Book");
            Console.WriteLine("4. Exit");
            Console.Write("\nMasukkan Pilihan : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("      ADD BOOK");
                    Console.WriteLine("--------------------------"); ;
                    Console.Write("Enter Title Book : ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Author : ");
                    string author = Console.ReadLine();
                    Console.Write("Enter Publication : ");
                    book = Console.ReadLine();
                    if (errorHandler.TryParseInt(book, out int publication))
                    {
                        LibraryCatalog.catalog.AddBook(new Book(title,author,publication));
                    }
                    else
                    {
                        errorHandler.HandleInvalidInput();
                    }
                    Console.Write("Tekan Enter untuk kembali !!! ");
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Clear();
                    LibraryCatalog.catalog.ShowAllBook();
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("      MENU BOOK");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("1. Edit Book");
                    Console.WriteLine("2. Delete Book");
                    Console.WriteLine("3. Back");
                    Console.Write("Masukkan Pilihan : ");
                    string pilih = Console.ReadLine();

                    switch (pilih)
                    {
                        case "1":
                            Console.WriteLine("--------------------------");
                            Console.Write("Masukkan Id yang ingin di edit : ");
                            book = Console.ReadLine();
                            if (errorHandler.TryParseInt(book, out int editId))
                            {
                                Book bookToEdit = LibraryCatalog.catalog.FindBookById(editId);
                                if (bookToEdit != null)
                                {
                                    Console.Write("Masukkan Title Baru : ");
                                    string newTitle = Console.ReadLine();
                                    Console.Write("Masukkan Author Baru : ");
                                    string newAuthor = Console.ReadLine();
                                    Console.Write("Masukkan PublicationYear Baru : ");
                                    book = Console.ReadLine();
                                    if (errorHandler.TryParseInt(book, out int newPublication))
                                    {
                                        LibraryCatalog.catalog.editBook(editId, newTitle, newAuthor, newPublication);

                                    }
                                    else
                                    {
                                        errorHandler.HandleInvalidInput();
                                    }
                                }
                                else
                                {
                                    errorHandler.HandleBookNotFound();
                                }
                            }
                            else
                            {
                                errorHandler.HandleInvalidInput();
                            }
                            Console.Write("Tekan Enter Untuk Kembali !!!");
                            Console.ReadLine();
                            break;

                        case "2":
                            Console.WriteLine("--------------------------");
                            Console.Write("Masukkan Id Book yang ingin di hapus : ");
                            book = Console.ReadLine();
                            if (errorHandler.TryParseInt(book, out int deleteId))
                            {
                                Book bookToDelete = LibraryCatalog.catalog.FindBookById(deleteId); // Anda perlu mencari buku berdasarkan ID atau cara lain sebelumnya
                                LibraryCatalog.catalog.deleteBook(bookToDelete);
                            }
                            else
                            {
                                errorHandler.HandleInvalidInput();
                            }
                            Console.Write("Tekan Enter Untuk Kembali !!!");
                            Console.ReadLine();
                            break;

                        case "3":
                            break;
                    }
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("---------------------------------------------");
                    Console.Write("Masukkan Title Book yang ingin dicari : ");
                    string searchName = Console.ReadLine();
                    List<Book> foundBooks = LibraryCatalog.catalog.FindBooksByKeyword(searchName);
                    if (foundBooks.Count > 0)
                    {
                        // Buku ditemukan, Anda dapat menampilkan detail buku ini.
                        LibraryCatalog.catalog.ShowBook(foundBooks);
                    }
                    else
                    {
                        errorHandler.HandleSearchNotFound();
                    }
                    Console.Write("Tekan Enter Untuk Kembali !!!");
                    Console.ReadLine();
                    break;

                case "4":
                    Environment.Exit(0);
                    break;
            }
        }
        
    }
}