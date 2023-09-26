using System.Globalization;

namespace ManagePustaka;

class Program
{
    static BookService bookService = new BookService();
    static MembersService memberService = new MembersService();
    static LoanService loanService = new LoanService(bookService);
    public static void Main(string[] args)
    {
        // Tambahkan data dummy buku
        bookService.AddBook(new Book { Title = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling", ISBN = "978-0590353403" });
        bookService.AddBook(new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", ISBN = "978-0547928227" });
        bookService.AddBook(new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "978-0743273565" });

        // Tambahkan data dummy anggota
        memberService.AddMember(new Member { Name = "John Doe", Email = "john.doe@example.com", MembershipNumber = "M001" });
        memberService.AddMember(new Member { Name = "Jane Smith", Email = "jane.smith@example.com", MembershipNumber = "M002" });

        // Tambahkan data dummy peminjaman buku
        loanService.BorrowBook(1, 1); // John Doe meminjam Harry Potter
        loanService.BorrowBook(2, 2); // Jane Smith meminjam The Hobbit

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Aplikasi Manajemen Pustaka");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Management Book");
            Console.WriteLine("2. Management Member");
            Console.WriteLine("3. Management Pinjaman");
            Console.WriteLine("0. Keluar");
            Console.Write("Pilih 0-3 : ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    MenuBook();
                    break;
                case "2":
                    MenuMember();
                    break;
                case "3":
                    MenuLoan();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
            }
        }
    }
    
    public static void MenuBook()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Aplikasi Manajemen Book");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Tambah Buku");
            Console.WriteLine("2. Edit Buku");
            Console.WriteLine("3. Hapus Buku");
            Console.WriteLine("4. Lihat Daftar Buku");
            Console.WriteLine("0. Keluar");
            Console.Write("Pilih 0-4 : ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Judul Buku: ");
                    string title = Console.ReadLine();
                    Console.Write("Pengarang: ");
                    string author = Console.ReadLine();
                    Console.Write("ISBN: ");
                    string isbn = Console.ReadLine();
                    Book newBook = new Book { Title = title, Author = author, ISBN = isbn };
                    bookService.AddBook(newBook);
                    break;

                case "2":
                    Console.Write("ID Buku yang akan diubah: ");
                    if (int.TryParse(Console.ReadLine(), out int editBookId))
                    {
                        Console.Write("Judul baru: ");
                        string newTitle = Console.ReadLine();
                        Console.Write("Pengarang baru: ");
                        string newAuthor = Console.ReadLine();
                        Console.Write("ISBN baru: ");
                        string newISBN = Console.ReadLine();
                        Book updatedBook = new Book { Title = newTitle, Author = newAuthor, ISBN = newISBN };
                        bookService.EditBook(editBookId, updatedBook);
                    }
                    else
                    {
                        Console.WriteLine("ID Buku tidak valid.");
                    }
                    break;

                case "3":
                    Console.Write("ID Buku yang akan dihapus: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteBookId))
                    {
                        bookService.DeleteBook(deleteBookId);
                    }
                    else
                    {
                        Console.WriteLine("ID Buku tidak valid.");
                    }
                    break;

                case "4":
                    List<Book> allBooks = bookService.GetAllBooks();
                    Console.WriteLine("Daftar Buku:");
                    foreach (var book in allBooks)
                    {
                        Console.WriteLine($"ID: {book.Id}, Judul: {book.Title}, Pengarang: {book.Author}, ISBN: {book.ISBN}");
                    }
                    break;

                case "0":
                    break;
            }
            Console.Write("Tekan Enter Untuk Kembali !!!");
            Console.ReadLine();
            break;
        }
    }

    public static void MenuMember()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Aplikasi Manajemen Member");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Tambah Member");
            Console.WriteLine("2. Edit Member");
            Console.WriteLine("3. Hapus Member");
            Console.WriteLine("4. Lihat Daftar Member");
            Console.WriteLine("0. Keluar");
            Console.Write("Pilih 0-4 : ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Nama Anggota: ");
                    string name = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Nomor Keanggotaan: ");
                    string membershipNumber = Console.ReadLine();
                    Member newMember = new Member { Name = name, Email = email, MembershipNumber = membershipNumber };
                    memberService.AddMember(newMember);
                    break;

                case "2":
                    Console.Write("ID Anggota yang akan diubah: ");
                    if (int.TryParse(Console.ReadLine(), out int editMemberId))
                    {
                        Console.Write("Nama baru: ");
                        string newName = Console.ReadLine();
                        Console.Write("Email baru: ");
                        string newEmail = Console.ReadLine();
                        Console.Write("Nomor Keanggotaan baru: ");
                        string newMembershipNumber = Console.ReadLine();
                        Member updatedMember = new Member { Name = newName, Email = newEmail, MembershipNumber = newMembershipNumber };
                        memberService.EditMember(editMemberId, updatedMember);
                    }
                    else
                    {
                        Console.WriteLine("ID Anggota tidak valid.");
                    }
                    break;

                case "3":
                    Console.Write("ID Anggota yang akan dihapus: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteMemberId))
                    {
                        memberService.DeleteMember(deleteMemberId);
                    }
                    else
                    {
                        Console.WriteLine("ID Anggota tidak valid.");
                    }
                    break;

                case "4":
                    List<Member> allMembers = memberService.GetAllMembers();
                    Console.WriteLine("Daftar Anggota:");
                    foreach (var member in allMembers)
                    {
                        Console.WriteLine($"ID: {member.Id}, Nama: {member.Name}, Email: {member.Email}, Nomor Keanggotaan: {member.MembershipNumber}");
                    }
                    break;

                case "0":
                    break;
            }
            Console.Write("Tekan Enter Untuk Kembali !!!");
            Console.ReadLine();
            break;
        }
    }

    public static void MenuLoan()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Manajemen Pinjaman Buku");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Pinjam Buku");
            Console.WriteLine("2. Kembalikan Buku");
            Console.WriteLine("3. Edit Status Peminjaman");
            Console.WriteLine("4. Hapus Peminjaman");
            Console.WriteLine("5. Lihat Peminjaman");
            Console.WriteLine("6. Status Peminjaman Buku");
            Console.WriteLine("0. Keluar");
            Console.Write("Pilih 0-4 : ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("ID Anggota: ");
                    if (int.TryParse(Console.ReadLine(), out int memberId))
                    {
                        Console.Write("ID Buku: ");
                        if (int.TryParse(Console.ReadLine(), out int bookId))
                        {
                            loanService.BorrowBook(memberId, bookId);
                        }
                        else
                        {
                            Console.WriteLine("ID Buku tidak valid.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID Anggota tidak valid.");
                    }
                    break;

                case "2":
                    Console.Write("ID Anggota: ");
                    if (int.TryParse(Console.ReadLine(), out int returnMemberId))
                    {
                        Console.Write("ID Buku: ");
                        if (int.TryParse(Console.ReadLine(), out int returnBookId))
                        {
                            loanService.ReturnBook(returnMemberId, returnBookId);
                        }
                        else
                        {
                            Console.WriteLine("ID Buku tidak valid.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID Anggota tidak valid.");
                    }
                    break;

                case "3":
                    // Edit status peminjaman
                    Console.Write("Masukkan ID Peminjaman yang akan diedit: ");
                    if (int.TryParse(Console.ReadLine(), out int editLoanId))
                    {
                        Console.Write("Masukkan Tanggal Pengembalian Baru (yyyy-MM-dd): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime newReturnDate))
                        {
                            loanService.EditLoanStatus(editLoanId, newReturnDate);
                        }
                        else
                        {
                            Console.WriteLine("Tanggal tidak valid.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID Peminjaman tidak valid.");
                    }
                    break;

                case "4":
                    Console.Write("Masukkan ID Peminjaman yang akan dihapus: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteLoanId))
                    {
                        loanService.DeleteLoan(deleteLoanId);
                    }
                    else
                    {
                        Console.WriteLine("ID Peminjaman tidak valid.");
                    }
                    break;

                case "5":
                    loanService.ViewAllLoans();
                    break;

                case "6":
                    loanService.ViewLoanStatus();
                    break;

                case "0":
                    break;
            }
            Console.Write("Tekan Enter Untuk Kembali !!!");
            Console.ReadLine();
            break;
        }
    }
}